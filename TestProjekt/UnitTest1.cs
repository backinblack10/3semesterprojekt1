using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WCFServiceWebRole1;

namespace TestProjekt
{
    [TestClass]
    public class UnitTest1
    {
        //Service1 service = new Service1();
        private Brugere b;
        [TestInitialize]
        public void BeforeTest()
        {
            b = new Brugere("Brugernavn", "Secret12", "email@email.dk");
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPassword()
        {
            b.Password = null;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPassword1()
        {
            b.Password = "1A3";
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPassword2()
        {
            b.Password = "123456789A23456789123";
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPassword3()
        {
            b.Password = "Brugernavn12";
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPassword4()
        {
            b.Password = "jørgen12";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPassword5()
        {
            b.Password = "Jørgenetto";
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestEmail()
        {
            b.Email = "Meile.com";
        }
    }
}
