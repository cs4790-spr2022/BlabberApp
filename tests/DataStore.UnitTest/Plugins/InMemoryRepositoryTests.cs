using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlabberApp.DataStore.UnitTests.Plugins;

[TestClass]
public class InMemoryRepositoryTests
{
    [TestMethod]
    public void InMemoryRepository_TypeCheck()
    {
        // Arrange
        var e = new InMemoryRepository();
        // Act
        var a = new InMemoryRepository();
        // Assert
        Assert.IsInstanceOfType(e, a.GetType(), "NOT same types");
    }

    [TestMethod]
    public void InMemoryRepository_Add_Count()
    {
        // Arrange
        var h = new InMemoryRepository();
        var e = 1;
        var u = new User("foobar", "foobar@example.com");
        // Act
        h.Create(u);
        var a = h.Count();
        // Assert
        Assert.AreEqual(e, a);
    }
}