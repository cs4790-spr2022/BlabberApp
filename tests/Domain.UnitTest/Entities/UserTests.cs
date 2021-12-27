using BlabberApp.Domain.Entities;
using NUnit.Framework;

namespace BlabberApp.Domain.UnitTests.Entities;

public class UserTests
{
    [Test]
    public void NewUserShouldReturnCorrectValues()
    {
        // Arrange
        var e = new User("foobar", "foobar@example.com");
        // Act
        var a = new User("foobar", "foobar@example.com");
        // Assert
        Assert.AreEqual(e.Username, a.Username);
        Assert.AreEqual(e.Email.Address, a.Email.Address);
        Assert.AreNotEqual(e.Id, a.Id);
        Assert.AreEqual(e.registeredDttm, a.registeredDttm);
        Assert.AreEqual(e.lastloginDttm, a.lastloginDttm);
    }
}