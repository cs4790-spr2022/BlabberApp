using BlabberApp.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlabberApp.Domain.UnitTests.Entities
{

    [TestClass]
    public class BlabTests
    {
        [TestMethod]
        public void NewBlabShouldReturnCorrectValues()
        {
            // Arrange
            var u = new User("foobar", "foobar@example.com");
            var e = new Blab("Lorem ipsum voluptate proident ut ut irure ex ex aliqua in esse non eiusmod adipisicing exercitation consequat in quis est.", u);
            // Act
            var a = new Blab("Lorem ipsum voluptate proident ut ut irure ex ex aliqua in esse non eiusmod adipisicing exercitation consequat in quis est.", u);
            // Assert
            Assert.AreNotEqual(e.Id, a.Id, "ID's are equal");
            Assert.AreEqual(e.Author, a.Author, "User are NOT equal");
            Assert.AreEqual(e.Content, a.Content, "Content is NOT equal");
        }
    }
}