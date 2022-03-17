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
            var e = new Blab("Lorem ipsum voluptate proident ut ut irure ex ex aliqua in esse non eiusmod adipisicing exercitation consequat in quis est.", "foobar");
            // Act
            var a = new Blab("Lorem ipsum voluptate proident ut ut irure ex ex aliqua in esse non eiusmod adipisicing exercitation consequat in quis est.", "foobar");
            // Assert
            Assert.AreNotEqual(e.Id.ToString(), a.Id.ToString(), "ID's are equal");
            Assert.AreEqual(e.Username, a.Username, "User are NOT equal");
            Assert.AreEqual(e.Content, a.Content, "Content is NOT equal");
        }
    }
}