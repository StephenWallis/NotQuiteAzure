using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace NotQuiteAzure.Tests
{
    [TestClass]
    public class RegisterTests
    {
        Mock<DatabaseConnection> databaseConnection = new Mock<DatabaseConnection>();

        [TestMethod]
        public void TestRegister()
        {
            databaseConnection.Setup(d => d.Register(It.IsAny<int>())).Returns(new Customer() { id = "testeroo" });

            NotQuiteAzure notQuiteAzure = new NotQuiteAzure();
            Customer customer = notQuiteAzure.Register(2);

            Assert.AreEqual("testeroo", customer.id);
        }
    }
}
