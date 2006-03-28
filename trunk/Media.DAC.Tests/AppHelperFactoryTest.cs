﻿// The following code was generated by Microsoft Visual Studio 2005.
// The test owner should check each test for validity.
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Collections.Generic;
using Media.BC;
using Media.AppHelpers;

namespace Media.Tests
{
    /// <summary>
    ///This is a test class for Media.BC.AppHelperFactory and is intended
    ///to contain all Media.BC.AppHelperFactory Unit Tests
    ///</summary>
    [TestClass()]
    public class AppHelperFactoryTest
    {

        private const string appHelperFileName = @"C:\Documents and Settings\pauld\My Documents\Visual Studio 2005\Projects\MediaManager\dotnet-Helpers.xml";
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for AppHelperFactory (string)
        ///</summary>
        [TestMethod()]
        public void ConstructorTest()
        {
            string configFile = appHelperFileName;

            AppHelperFactory target = new AppHelperFactory(configFile);

            //Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GetAppHelper (string)
        ///</summary>
        [TestMethod()]
        public void GetAppHelperTest()
        {
            string configFile = appHelperFileName; // TODO: Initialize to an appropriate value

            AppHelperFactory target = new AppHelperFactory(configFile);

            string name = "IMDB"; // TODO: Initialize to an appropriate value

            //AppHelper expected = null;
            AppHelper actual;

            actual = target.GetAppHelper(name);

            Assert.IsTrue(actual is ImdbAppHelper);
            //Assert.AreEqual(expected, actual, "Media.BC.AppHelperFactory.GetAppHelper did not return the expected value.");
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetAppHelperNames ()
        ///</summary>
        [TestMethod()]
        public void GetAppHelperNamesTest()
        {
            string configFile = appHelperFileName; // TODO: Initialize to an appropriate value

            AppHelperFactory target = new AppHelperFactory(configFile);

            System.Collections.Generic.List<string> expected = new List<string>();
            expected.Add("IMDB");
           // expected.Add("Amazon");
           // expected.Add("metacritic-games");
           // expected.Add("nforce-games");
            System.Collections.Generic.List<string> actual;

            actual = target.GetAppHelperNames();

            Assert.AreEqual(expected.Count, actual.Count);
            foreach (string str in expected)
            {
                Assert.IsTrue(actual.Contains(str));
            }
            //Assert.AreEqual(expected, actual, "Media.BC.AppHelperFactory.GetAppHelperNames did not return the expected value.");
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }


}
