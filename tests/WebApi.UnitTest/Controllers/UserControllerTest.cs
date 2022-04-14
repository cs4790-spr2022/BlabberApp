using System.Linq;

using DataStore.Plugins;

using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using WebApi.Controllers;
using WebApi.Dto;

namespace WebApi.UnitTest.Controllers;

[TestClass]
public class UserControllerTest
{
    [TestMethod]
    public void TestInstantiation()
    {
        // Arrange
        UserController e = new(new Mock<ILogger<UserController>>().Object, new InMemUserRepository());
        // Act
        UserController a = new(new Mock<ILogger<UserController>>().Object, new InMemUserRepository());
        // Assert
        Assert.AreEqual(e.GetType(), a.GetType());
        Assert.IsInstanceOfType(e, typeof(UserController));
    }

    [TestMethod]
    public void TestGetAllEmpty()
    {
        // Arrange
        UserController h = new(new Mock<ILogger<UserController>>().Object, new InMemUserRepository());
        // Act
        var a = h.GetAll();
        // Assert
        Assert.AreEqual(0, a.Count());
    }

    [TestMethod]
    public void TestPostAndGetAll()
    {
        // Arrange
        UserController h = new(new Mock<ILogger<UserController>>().Object, new InMemUserRepository());
        UserDto u = new("fubar", "fubar@example.com", "Fu", "Bar");
        // Act
        var a = h.Post(u);
        // Assert
        Assert.AreEqual("Microsoft.AspNetCore.Mvc.CreatedAtRouteResult", a.ToString());
        Assert.AreEqual(1, h.GetAll().Count());
    }

    [TestMethod]
    public void TestPostAndGetById()
    {
        // Arrange
        UserController h = new(new Mock<ILogger<UserController>>().Object, new InMemUserRepository());
        UserDto u = new("fubar", "fubar@example.com", "Fu", "Bar");
        // Act
        h.Post(u);
        var b = h.GetAll();
        var a = h.GetById(b.First().Id);
        // Assert
        Assert.AreEqual("Microsoft.AspNetCore.Mvc.OkObjectResult", a.ToString());
    }
}