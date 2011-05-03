using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using log4net.Config;

namespace MediaManager2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            WebRequest.DefaultWebProxy.Credentials = CredentialCache.DefaultCredentials;
            XmlConfigurator.Configure();
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }
}