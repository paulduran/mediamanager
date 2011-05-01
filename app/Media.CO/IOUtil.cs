using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Net;

namespace Media.CO
{
    public class IOUtil
    {
        public static byte[] LoadUrl(string url)
        {
            WebClient client = new WebClient();
            Trace.WriteLine("opening connection to: " + url);
            Stream dataStream = client.OpenRead(url);
            return ReadStreamFully(dataStream);
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
