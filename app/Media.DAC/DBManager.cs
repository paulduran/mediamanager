#define MAIN

using System;
using System.Collections.Generic;
using System.Text;
using Finisar.SQLite;
using System.IO;
using System.Data;

namespace Media.DAC
{
    public class DBManager : IDisposable
    {
        private readonly SQLiteConnection conn;

        public DBManager() : this("database.db")
        {
        }

        public DBManager(string path)
        {
            string connectionStr = string.Format("Data Source={0};Version=3;New={1};Compress=True;", path, ! File.Exists(path));
            conn = new SQLiteConnection(connectionStr);
            conn.Open();

        }

        public DBManager(SQLiteConnection conn)
        {
            this.conn = conn;
        }

        public void Dispose()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        public int ExecuteNonQuery(string sql)
        {
            SQLiteCommand command = conn.CreateCommand();
            command.CommandText = sql;
            return command.ExecuteNonQuery();
        }

        public void ExecuteFile(string fileName)
        {        
            string sql = File.ReadAllText(fileName);
            SQLiteTransaction transaction = conn.BeginTransaction();
            try
            {
                ExecuteNonQuery(sql);
                transaction.Commit();
            }
            catch (SQLiteException e)
            {
                System.Diagnostics.Debug.WriteLine("Exception occurred when executing sql in file: " + fileName + ": " + e.Message);
                transaction.Rollback();
            }
            
        }

        public bool TableExists(string tableName)
        {
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select count(*) from sqlite_master where type='table' and name=?";
            SQLiteParameter param = new SQLiteParameter();
            param.DbType = DbType.String;
            param.Value = tableName;
            cmd.Parameters.Add(param);
            return ((long)cmd.ExecuteScalar() > 0);            
        }


        public DataSet ExecuteDataset(SQLiteCommand cmd)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            da.Dispose();
            return ds;
        }

        public void DumpTable(string tableName)
        {
            try
            {
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from " + tableName;
                DataSet ds = ExecuteDataset(cmd);
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataColumn col in table.Columns)
                    {
                        System.Diagnostics.Debug.Write(col.ColumnName + "\t");
                    }
                    System.Diagnostics.Debug.WriteLine("");
                    foreach (DataRow row in table.Rows)
                    {
                        foreach (DataColumn col in table.Columns)
                        {
                            System.Diagnostics.Debug.Write(row[col] + "\t");
                        }
                    }
                }
            }
            catch (SQLiteException e)
            {
                System.Diagnostics.Debug.Write("Error dumping table: " + tableName + ": " + e.Message);
                conn.Close();
                conn.Open();
            }
            //return ds.Tables[0].Rows.Count > 0;
        }
    }
}
