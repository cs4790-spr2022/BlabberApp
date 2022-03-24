using DataStore.Plugins;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStore.UnitTest.Plugins;

[TestClass]
public class MySqlBlabRepositoryTest
{
    private readonly MySqlBlabRepository _h;
    private readonly string _dsn;

    public MySqlBlabRepositoryTest()
    {
        _dsn = "server=143.110.159.170;uid=donstringham;pwd=letmein;database=donstringham";
        _h = new MySqlBlabRepository(_dsn);
    }

    [TestInitialize]
    public void Setup()
    {}

    [TestCleanup]
    public void TearDown()
    {
        _h.RemoveAll();
    }

    [TestMethod]
    public void MySqlBlabRepository_Instantiate()
    {
        // Arrange
        // Act
        MySqlBlabRepository a = new(_dsn);
        // Assert
        Assert.AreEqual(_h.ToString(), a.ToString());
    }

    [TestMethod]
    public void MySqlBlabRepositoryTest_Insert()
    {
        // Arrange
        Blab e = new(
            "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet",
            "foobar"
        );
        // Act
        _h.Add(e);
        Blab a = _h.GetById(e.Id);
        // Assert
        Assert.AreEqual(e.Id.ToString(), a.Id.ToString());
        Assert.AreEqual(e.Content, a.Content);
        Assert.AreEqual(e.Username, a.Username);
    }
    
    [TestMethod]
         public void MySqlBlabRepositoryTest_InsertTwo()
         {
             // Arrange
             Blab e1 = new(
                 "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet",
                 "foobar"
             );
             Blab e2 = new(
                 "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet",
                 "foobar"
             );
             // Act
             _h.Add(e1);
             _h.Add(e2);
         }
}