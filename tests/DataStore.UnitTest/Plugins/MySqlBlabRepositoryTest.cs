using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BlabberApp.DataStore.UnitTests.Plugins
{

    [TestClass]
    public class MySqlBlabRepositoryTest
    {
        [TestMethod]
        public void MySqlBlabRepository_Instantiate()
        {
            // Arrange
            string dsn = "server=143.110.159.170;uid=donstringham;pwd=letmein;database=donstringham";
            MySqlBlabRepository e = new MySqlBlabRepository(dsn);
            // Act
            MySqlBlabRepository a = new MySqlBlabRepository(dsn);
            // Assert
            Assert.AreEqual(e.ToString(), a.ToString());
        }

        [TestMethod]
        public void MySqlBlabRepository_Connect_NoException()
        {
            // Arrange
            string dsn = "server=143.110.159.170;uid=donstringham;pwd=letmein;database=donstringham";
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
            Assert.ThrowsException<System.Exception>(() => a.Connect());
        }

        [TestMethod]
        public void MySqlBlabRepositoryTest_Insert()
        {
           // Arrange
            string dsn = "server=143.110.159.170;uid=donstringham;pwd=letmein;database=blabber";
            MySqlBlabRepository h = new MySqlBlabRepository(dsn);
            User u = new User("foobar", "foo@bar.com");
            Blab e = new Blab(
                "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                u
            );
           // Act
           h.Connect();
           h.Add(e);
           Blab a = h.GetById(e.Id);
           // Assert
           Assert.AreEqual(e, a);
        }

    }

}