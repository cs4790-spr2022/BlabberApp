using BlabberApp.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlabberApp.Domain.UnitTests.Entities;

[TestClass]
public class UserTests
{
    [TestMethod]
    public void NewUserShouldReturnCorrectValues()
    {
        // Arrange
        var e = new User("foobar", "foobar@example.com");
        // Act
        var a = new User("foobar", "foobar@example.com");
        // Assert
        Assert.AreEqual(e.Username, a.Username, "Username's are NOT equal");
        Assert.AreEqual(e.Email.Address, a.Email.Address, "Email's are NOT equal");
        Assert.AreNotEqual(e.Id, a.Id, "ID's are equal");
    }
}