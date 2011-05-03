using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Net;
using System.Xml.Linq;

namespace Media.CO
{
    public class IOUtil
    {
        public static byte[] LoadUrl(string url)
        {
            WebClient client = new WebClient();
            client.Proxy = WebRequest.GetSystemWebProxy();
            client.Proxy.Credentials = CredentialCache.DefaultCredentials;
            Trace.WriteLine("opening connection to: " + url);
            Stream dataStream = client.OpenRead(url);
            return ReadStreamFully(dataStream);
        }

        public static XDocument LoadXml(string url)
        {
            var request = WebRequest.Create(url);
            request.Proxy = WebRequest.GetSystemWebProxy();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            XDocument doc = XDocument.Load(response.GetResponseStream());
            return doc;
        }

        public static byte[] ReadStreamFully(Stream dataStream)
        {
            Trace.WriteLine("reading data stream");
            byte[] buffer = new byte[32768];
            using (MemoryStream ms = new MemoryStream())
            {
                while (true)
                {
                    int read = dataStream.Read(buffer, 0, buffer.Length);
                    if (read <= 0)
                    {
                        dataStream.Close();
                        return ms.ToArray();
                    }
                    Trace.WriteLine("read: " + read + " bytes");
                    ms.Write(buffer, 0, read);
                }
            }
        }
        public static string LoadUrlAsString(string url)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            return encoding.GetString(LoadUrl(url));
        }
    }
}
