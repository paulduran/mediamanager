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

        public MediaStore()
        {
            Initialise();
            Configuration cfg = new Configuration();
            cfg.AddAssembly("Media.BE");
            factory = cfg.BuildSessionFactory();
            //ISession session = factory.OpenSession();
            //IList<MediaGeneralInformation> items = (IList<MediaGeneralInformation>)session.Find("from MediaGeneralInformation");
        }

        private void Initialise()
        {
            Configuration cfg = new Configuration();
            cfg.AddAssembly("Media.BE");
            string driver = (string)cfg.Properties["hibernate.connection.driver_class"];

            // sqlite specific initialisation
            if (driver.Contains("SQLite"))
            {
                string connStr = (string)cfg.Properties["hibernate.connection.connection_string"];
                // parse connection string, look for datasource.
                Regex regex = new Regex("Data Source=([^;]+)");
                Match match = regex.Match(connStr);
                if (match.Success)
                {
                    string dbName = match.Groups[1].Value;
                    if (File.Exists(dbName))
                    {
                        connStr = connStr + ";New=False";
                        cfg.Properties["hibernate.connection.connection_string"] = connStr;
                    }
                    else
                    {
                        connStr = connStr + ";New=True";
                        cfg.Properties["hibernate.connection.connection_string"] = connStr;
                        new NHibernate.Tool.hbm2ddl.SchemaExport(cfg).Create(true, true);
                    }
                }

            }
        }

        public System.Collections.IList GetAllMedia()
        {
            using( ISession session = factory.OpenSession() )
            {
                return session.CreateCriteria(typeof(MediaItem)).List();
                //return session.Find("from MediaGeneralInformation");
            }
        }

        public void Delete(MediaItem mii)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = factory.OpenSession();
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
            finally
            {
                if (session != null)
                    session.Close();
            }
        }
        public void Save(MediaItem mii)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = factory.OpenSession();
                transaction = session.BeginTransaction();
                session.SaveOrUpdate(mii.GeneralInformation);
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
            finally
            {
                if (session != null)
                    session.Close();
            }
        }
    }
}
