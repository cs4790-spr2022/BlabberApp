using BlabberApp.DataStore.Plugins;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlabberApp.DataStore.UnitTests.Plugins;

[TestClass]
public class InMemoryRepositoryTests
{
    [TestMethod]
    public void NewInMemoryRepositoryShouldInstantiateCorrectly()
    {
        // Arrange
        var e = new InMemoryRepository();
        // Act
        var a = new InMemoryRepository();
        // Assert
        Assert.IsInstanceOfType(e, a.GetType(), "NOT same types");
    }
}