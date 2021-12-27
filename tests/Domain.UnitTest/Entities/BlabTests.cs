using BlabberApp.Domain.Entities;
using NUnit.Framework;

namespace BlabberApp.Domain.UnitTests.Entities;

public class BlabTests
{
    [Test]
    public void NewBlabShouldReturnCorrectValues()
    {
        // Arrange
        var u = new User("foobar", "foobar@example.com");
        var e = new Blab("Lorem ipsum voluptate proident ut ut irure ex ex aliqua in esse non eiusmod adipisicing exercitation consequat in quis est.", u);
        // Act
        var a = new Blab("Lorem ipsum voluptate proident ut ut irure ex ex aliqua in esse non eiusmod adipisicing exercitation consequat in quis est.", u);
        // Assert
        Assert.AreNotEqual(e.Id, a.Id);
        Assert.AreEqual(e.User, a.User);
        Assert.AreEqual(e.Content, a.Content);
    }
}