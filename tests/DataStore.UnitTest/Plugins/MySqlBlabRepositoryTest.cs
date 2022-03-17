using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BlabberApp.DataStore.UnitTests.Plugins
{

    [TestClass]
    public class MySqlBlabRepositoryTest
    {
        public MySqlBlabRepository h;
        private string dsn = "server=143.110.159.170;uid=donstringham;pwd=letmein;database=donstringham";

        [TestInitialize]
        public void Setup()
        {
            h = new MySqlBlabRepository(dsn);
        }

        [TestCleanup]
        public void TearDown()
        {
            h.RemoveAll();
        }

        [TestMethod]
        public void MySqlBlabRepository_Instantiate()
        {
            // Arrange
            // Act
            MySqlBlabRepository a = new MySqlBlabRepository(dsn);
            // Assert
            Assert.AreEqual(h.ToString(), a.ToString());
        }

        [TestMethod]
        public void MySqlBlabRepository_Connect_NoException()
        {
            // Arrange
            MySqlBlabRepository a = new MySqlBlabRepository(dsn);
            // Act and Assert
            try
            {
                a.Connect();
            }
            catch (System.Exception ex)
            {
                Assert.Fail("Expected NO exception, but got: " + ex.Message);
            }
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void MySqlBlabRepositoryTest_Connect_Exception()
        {
            // Arrange
            string dsn = "server=143.110.159.170;uid=donstringham;pwd=letmein;database=blabber";
            MySqlBlabRepository a = new MySqlBlabRepository(dsn);
            // Act and Assert
            Assert.ThrowsException<MySql.Data.MySqlClient.MySqlException>(() => a.Connect());
        }

        [TestMethod]
        public void MySqlBlabRepositoryTest_Insert()
        {
           // Arrange
            Blab e = new Blab(
                "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet",
                "foobar"
            );
           // Act
           h.Add(e);
           Blab a = h.GetById(e.Id);
           // Assert
           Assert.AreEqual(e.Id.ToString(), a.Id.ToString());
           Assert.AreEqual(e.Content, a.Content);
           Assert.AreEqual(e.Username, a.Username);
        }
    }
}