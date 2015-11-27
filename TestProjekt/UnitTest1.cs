using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProjekt.ServiceReference1;
using WCFServiceWebRole1;
using WCFServiceWebRole1.Models;

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

        [TestMethod]
        public void Opdateremailintegrationtest()
        {
            Service1Client client = new Service1Client();
            //client.OpdaterEmail("Jari", "dinp67.com");
            Assert.AreEqual("Email er forkert" + " (" + "dinp67.com" + ")", client.OpdaterEmail("Jari", "dinp67.com"));
        }
    }
}
