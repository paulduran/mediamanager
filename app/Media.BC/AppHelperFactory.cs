using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Reflection;
using Media.BE;

namespace Media.BC
{
    public class AppHelperFactory
    {
        private Dictionary<string, AppHelper> appHelpers = new Dictionary<string,AppHelper>();
        private Dictionary<string, SimpleAppHelperContext> contexts = new Dictionary<string,SimpleAppHelperContext>();

        public AppHelperFactory(string configFile)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(configFile);

            foreach (XmlNode appHelperNode in doc.SelectNodes("//AppHelper"))
            {
                string name = appHelperNode.Attributes["name"].Value;
                string className = appHelperNode.Attributes["class"].Value;

                Type appHelperType = Type.GetType(className);
                if (appHelperType != null)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("AppHelperFactory: loaded type: {0}", appHelperType.ToString()));
                    appHelpers[name] = (AppHelper)Activator.CreateInstance(appHelperType);
                    contexts[name] = new SimpleAppHelperContext();
                    List<string> inputFieldNames = new List<string>();
                    foreach (XmlNode inputField in appHelperNode.SelectNodes("inputFields/inputField"))
                    {
                        inputFieldNames.Add(inputField.Attributes["name"].Value);

                    }
                    contexts[name].InputFields = inputFieldNames.ToArray();

                    List<string> outputFieldNames = new List<string>();
                    foreach (XmlNode outputField in appHelperNode.SelectNodes("outputFields/outputField"))
                    {
                        outputFieldNames.Add(outputField.Attributes["name"].Value);

                    }
                    contexts[name].OutputFields = outputFieldNames.ToArray();
                }
            }
        }

        /// <summary>
        /// returns the app helper object with the specified name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public AppHelper GetAppHelper(string name)
        {
            if( appHelpers.ContainsKey(name) )
                return appHelpers[name];
            return null;
        }

        /// <summary>
        /// returns the set of app helper names
        /// </summary>
        /// <returns></returns>
        public List<string> GetAppHelperNames()
        {
            List<string> names = new List<string>();
            names.AddRange(appHelpers.Keys);
            return names;
        }

        public AppHelperContext GetAppHelperContext(string name)
        {
            return contexts[name];
        }
    }
}
