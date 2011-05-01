using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using Media.BE;

namespace Media.BC
{
    public abstract class RegexAppHelper : MarshalByRefObject, IAppHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public abstract AppHelperItem[] LocateItems(AppHelperContext context);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public abstract bool LoadItem(AppHelperItem item, AppHelperContext context);

        public abstract string Name { get; }
        /// <summary>
        /// writes the specified message to a debug log.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="args">The args.</param>
        protected static void Debug(string message, params object[] args)
        {
            // System.Diagnostics.Debug.WriteLine(string.Format(message, args));
            Trace.WriteLine(string.Format(message, args));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expressions"></param>
        /// <param name="context"></param>
        /// <param name="instream"></param>
        protected void ProcessExpressions( List<RegexMatcher> expressions, AppHelperContext context, Stream instream )
        {
            StreamReader sr = new StreamReader(instream);
            string line;
            StringBuilder allLines = new StringBuilder();
            while ((line = sr.ReadLine()) != null)
            {
                line = line.Replace("\r\n", "\n");
                allLines.Append(line).Append("\n");

                foreach (RegexMatcher matcher in expressions)
                {
                    if (! (matcher is EntireStreamRegexMatcher) &&  matcher.IsMatch(line))
                    {
                        Debug("got a match: " + matcher.ToString());
                        matcher.AssignToContext(context);
                    }
                }

            }

            string allLinesStr = allLines.ToString();
            foreach (RegexMatcher matcher in expressions)
            {
                if (matcher is EntireStreamRegexMatcher && matcher.IsMatch(allLinesStr))
                {
                    Debug("got a match: " + matcher.ToString());
                    matcher.AssignToContext(context);
                }
            }
            sr.Close();
        }

        protected class RegexMatcher
        {
            private readonly Regex regex;
            protected Regex Regex
            {
                get { return regex; }
            }

            private readonly Regex subMatchRegex;
            protected Regex SubMatchRegex
            {
                get { return subMatchRegex; }
            }

            private List<string> excludes = new List<string>();

            public List<string> Excludes
            {
                get { return excludes; }
                set { excludes = value; }
            }

            public RegexMatcher(string contextName, string regexPattern)
                : this(contextName, regexPattern, null)
            {

            }

            public RegexMatcher(string contextName, string regexPattern, string subMatchRegex)
            {
                this.ContextName = contextName;
                this.regex = new Regex(regexPattern, RegexOptions.Multiline | RegexOptions.IgnoreCase);
                if (subMatchRegex != null)
                    this.subMatchRegex = new Regex(subMatchRegex, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                else
                    this.subMatchRegex = null;
            }

            public RegexMatcher(string contextName, Regex regex, Regex subMatchRegex)
            {
                this.ContextName = contextName;
                this.regex = regex;
                this.subMatchRegex = subMatchRegex;
            }

            private string contextName;
            public string ContextName
            {
                get { return contextName; }
                set { contextName = value; }
            }

            private string value;
            public string Value
            {
                get { return this.value; }
                set { this.value = value; }
            }

            public virtual void AssignToContext(AppHelperContext context)
            {
                context[ContextName] = Value;
            }

            public virtual bool IsMatch(string line)
            {
                MatchCollection matches = regex.Matches(line);
                if (matches.Count > 0)
                {
                    if (SubMatchRegex != null)
                    {
                        foreach (Match match in matches)
                        {
                            string val = match.Groups[1].Value;
                            ProcessMatches(SubMatchRegex.Matches(val));
                        }
                    }
                    else
                        ProcessMatches(matches);

                    return true;
                }

                return false;
            }

            protected virtual void ProcessMatches(MatchCollection matches)
            {
                List<string> items = new List<string>();
                foreach (Match match in matches)
                {
                    string val = match.Groups[1].Value.Trim();                    
                    if (match.Groups["match"] != null && match.Groups["match"].Value.Trim().Length > 0)
                        val = match.Groups["match"].Value.Trim();  
                    if (!excludes.Contains(val) && val.Length > 0)
                        items.Add(val);
                }
                Value = string.Join(", ", items.ToArray());
            }

            public override string ToString()
            {
                return string.Format("{0}: {1}", ContextName, value);
            }
        }

        protected class EntireStreamRegexMatcher : RegexMatcher
        {
            public EntireStreamRegexMatcher(string contextName, Regex regex, Regex subMatchRegex)
                : base(contextName, regex, subMatchRegex)
            {
            }
        }

        protected class MultiLineRegexMatcher : RegexMatcher
        {
            private bool nextLineMatch = false;
            private Regex secondLineRegex;

            public MultiLineRegexMatcher(string contextName, string firstLineRegex, string secondLineRegex)
                : this(contextName, firstLineRegex, secondLineRegex, null)
            {

            }

            public MultiLineRegexMatcher(string contextName, string firstLineRegex, string secondLineRegex, string subMatchRegex)
                : base(contextName, firstLineRegex, subMatchRegex)
            {
                this.secondLineRegex = new Regex(secondLineRegex, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            }

            public override bool IsMatch(string line)
            {
                if (nextLineMatch)
                {
                    nextLineMatch = false;
                    MatchCollection matches = secondLineRegex.Matches(line);
                    if (matches.Count > 0)
                    {
                        if (SubMatchRegex != null)
                        {
                            foreach (Match match in matches)
                            {
                                string val = match.Groups[1].Value;
                                ProcessMatches(SubMatchRegex.Matches(val));
                            }
                        }
                        else
                            ProcessMatches(matches);

                        return true;
                    }
                    else
                    {
                        Debug("Warning: " + ContextName + ": regex matched but value regex: " + secondLineRegex + " did not match line: " + line);
                    }
                }
                else if (Regex.IsMatch(line))
                {
                    nextLineMatch = true;
                }
                return false;
            }
        }
    }

 
}
