using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Cfg;

using Media.BE;
using System.IO;
using System.Text.RegularExpressions;

namespace Media.DAC
{
    public class MediaStore
    {
        private readonly ISessionFactory factory;
        private ISession session;

        public MediaStore()
        {
            Initialise();
            Configuration cfg = new Configuration();
            cfg.Configure();
            factory = cfg.BuildSessionFactory();
            //ISession session = factory.OpenSession();
            //IList<MediaGeneralInformation> items = (IList<MediaGeneralInformation>)session.Find("from MediaGeneralInformation");
            session = factory.OpenSession();
        }

        private void Initialise()
        {
            Configuration cfg = new Configuration();
            cfg.Configure();
            string driver = (string)cfg.Properties["connection.driver_class"];

            // sqlite specific initialisation
            if (driver.Contains("SQLite"))
            {
                string connStr = (string)cfg.Properties["connection.connection_string"];
                // parse connection string, look for datasource.
                Regex regex = new Regex("Data Source=([^;]+)");
                Match match = regex.Match(connStr);
                if (match.Success)
                {
                    string dbName = match.Groups[1].Value;
                    if (File.Exists(dbName))
                    {
                        connStr = connStr + ";New=False";
                        cfg.Properties["connection.connection_string"] = connStr;
                    }
                    else
                    {
                        connStr = connStr + ";New=True";
                        cfg.Properties["connection.connection_string"] = connStr;
                        new NHibernate.Tool.hbm2ddl.SchemaExport(cfg).Create(true, true);
                    }
                }

            }            
        }

        public System.Collections.IList GetAllMedia()
        {

                ICriteria criteria = session.CreateCriteria(typeof(MediaItem));
            return session.CreateQuery("from MediaItem m where ParentId = 0 order by m.Title").List();
//                return session.Find("from MediaItem m where ParentId = 0 order by m.Title");
                //return session.CreateCriteria(typeof(MediaItem)).List();
                //return session.Find("from MediaGeneralInformation");
       
        }

        public void Delete(MediaItem mii)
        {
            ITransaction transaction = null;

            try
            {
                transaction = session.BeginTransaction();
                session.Delete(mii);
                transaction.Commit();
            }
            catch
            {
                if (transaction != null)
                    transaction.Rollback(); // Error => we MUST roll back modifications
                throw; // Here, we throw the same exception so that it is handled (printed)
            }
           
        }
        public void Save(MediaItem mii)
        {
            ITransaction transaction = null;

             try
            {
                transaction = session.BeginTransaction();
                DumpMediaItem("", mii);
                //session.SaveOrUpdate(mii.GeneralInformation);
                session.SaveOrUpdate(mii);
                //session.Load(mii, mii.Id);
                
                // Commit modifications (=> Build and execute queries)
                transaction.Commit();
            }
            catch
            {
                if (transaction != null)
                    transaction.Rollback(); // Error => we MUST roll back modifications
                throw; // Here, we throw the same exception so that it is handled (printed)
            }           
        }
        private void DumpMediaItem(string indent, MediaItem mii)
        {
            if (mii == null)
            {
                Console.WriteLine(indent + "ERROR: null media item");
                return;
            }

            Console.WriteLine(string.Format(indent + "MediaItem. id: {0}. parent id: {1}. Type: {2}. Title: {3}. {4} children", mii.Id, mii.ParentId, mii.Type, mii.Title, mii.Children.Count));
            foreach( MediaItem child in mii.Children )
            {
                DumpMediaItem(indent + "    ", child);
            }
        }
    }
}
