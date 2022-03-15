using BlabberApp.DataStore.Plugins;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BlabberApp.DataStore.UnitTests.Plugins
{

    [TestClass]
    public class MySqlPluginTest
    {
        [TestMethod]
        public void MySqlPluginTest_Instantiate()
        {
            // Arrange
            string dsn = "server=143.110.159.170;uid=donstringham;pwd=letmein;database=blabber";
            MySqlPlugin e = new MySqlPlugin(dsn);
            // Act
            MySqlPlugin a = new MySqlPlugin(dsn);
            // Assert
            Assert.AreEqual(e.ToString(), a.ToString());
        }

        [TestMethod] public void MySqlPluginTest_Connect_NoException()
        {
            // Arrange
            string dsn = "server=143.110.159.170;uid=donstringham;pwd=letmein;database=donstringham";
            MySqlPlugin a = new MySqlPlugin(dsn);
            // Act and Assert
            try{
                a.Connect();
            } catch (System.Exception ex) {
                Assert.Fail("Expected NO exception, but got: " + ex.Message);
            }
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void MySqlPluginTest_Connect_Exception()
        {
            // Arrange
            string dsn = "server=143.110.159.170;uid=donstringham;pwd=letmein;database=blabber";
            MySqlPlugin a = new MySqlPlugin(dsn);
            // Act and Assert
            Assert.ThrowsException<System.Exception>(() => a.Connect());
        }
    }
}