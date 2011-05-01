using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Media.DAC;

namespace Media.DAC.Tests
{
    /// <summary>
    /// Summary description for DBManagerTest
    /// </summary>
    [TestClass]
    public class DBManagerTest
    {
        private const string TESTFILE = "testfile.db";

        public DBManagerTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private DBManager dbManager;

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize() 
        {
            dbManager = new DBManager(TESTFILE);
        }
        //
        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup() 
        {
            dbManager.Dispose();
            System.IO.File.Delete(TESTFILE);
        }
        
        #endregion

        [TestMethod]
        public void TestTableExists()
        {
            Assert.IsFalse( dbManager.TableExists("testtable") );
            dbManager.ExecuteNonQuery("CREATE TABLE testtable ( pk int primary key, name varchar(50) )");
            Assert.IsTrue(dbManager.TableExists("testtable"));
        }
    }
}
