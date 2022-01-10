using BlabberApp.DataStore.Plugins;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlabberApp.DataStore.UnitTests.Plugins;

[TestClass]
public class MySqlPluginTest
{
    [TestMethod]
    public void MySqlPluginTest_Instantiate()
    {
        // Arrange
        string dsn = "server=143.110.159.179;uid=donstringham;pwd=letmein;database=blabber";
        MySqlPlugin e = new MySqlPlugin(dsn);
        // Act
        MySqlPlugin a = new MySqlPlugin(dsn);
        // Assert
        Assert.AreEqual(e.ToString(), a.ToString());
    }
}