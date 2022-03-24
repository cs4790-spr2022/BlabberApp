using DataStore.Plugins;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStore.UnitTest.Plugins;

[TestClass]
public class MySqlPluginTest
{
    private readonly string _dsn;

    public MySqlPluginTest()
    {
        _dsn = "server=143.110.159.170;uid=donstringham;pwd=letmein;database=donstringham";
    }

    [TestMethod]
    public void MySqlPluginTest_Instantiate()
    {
        // Arrange
        MySqlPlugin e = new(_dsn);
        // Act
        MySqlPlugin a = new(_dsn);
        // Assert
        Assert.AreEqual(e.ToString(), a.ToString());
    }
}