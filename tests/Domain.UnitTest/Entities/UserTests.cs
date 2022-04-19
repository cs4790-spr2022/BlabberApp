using Domain.Entities;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.UnitTest.Entities;

[TestClass]
public class UserTests
{
    [TestMethod]
    public void NewUserShouldReturnCorrectValues()
    {
        // Arrange
        User e = new("foobar", "foobar@example.com");
        // Act
        User a = new("foobar", "foobar@example.com");
        // Assert
        Assert.AreEqual(e.Username, a.Username, "Username's are NOT equal");
        Assert.AreEqual(e.Email?.Address, a.Email?.Address, "Email's are NOT equal");
        Assert.AreNotEqual(e.Id.ToString(), a.Id.ToString(), "ID's are equal");
    }
}