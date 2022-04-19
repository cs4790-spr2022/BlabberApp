using System.Linq;

using DataStore.Plugins;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using WebApi.Controllers;
using WebApi.Dto;

namespace WebApi.UnitTest.Controllers;

[TestClass]
public class BlabsControllerTest
{
    [TestMethod]
    public void TestInstantiation()
    {
        // Arrange
        BlabsController e = new(new Mock<ILogger<BlabsController>>().Object, new InMemBlabRepository());
        // Act
        BlabsController a = new(new Mock<ILogger<BlabsController>>().Object, new InMemBlabRepository());
        // Assert
        Assert.AreEqual(e.GetType(), a.GetType());
        Assert.IsInstanceOfType(e, typeof(BlabsController));
    }

    [TestMethod]
    public void TestGetAllEmpty()
    {
        // Arrange
        BlabsController h = new(new Mock<ILogger<BlabsController>>().Object, new InMemBlabRepository());
        // Act
        var a = h.GetAll();
        // Assert
        Assert.AreEqual(0, a.Count());
    }

    [TestMethod]
    public void TestPostAndGetAll()
    {
        // Arrange
        BlabsController h = new(new Mock<ILogger<BlabsController>>().Object, new InMemBlabRepository());
        BlabDto d = new("fubar", "ipsum");
        // Act
        var a = h.Post(d);
        // Assert
        Assert.AreEqual("Microsoft.AspNetCore.Mvc.CreatedAtRouteResult", a.ToString());
        Assert.AreEqual(1, h.GetAll().Count());
    }

    [TestMethod]
    public void TestPostAndGetById()
    {
        // Arrange
        BlabsController h = new(new Mock<ILogger<BlabsController>>().Object, new InMemBlabRepository());
        BlabDto d = new("fubar", "ipsum");
        // Act
        h.Post(d);
        var b = h.GetAll();
        var a = h.GetById(b.First().Id);
        // Assert
        Assert.AreEqual("Microsoft.AspNetCore.Mvc.OkObjectResult", a.ToString());
    }

    [TestMethod]
    public void TestPostAndValidateNoUser()
    {
        // Arrange
        BlabsController blabController = new(new Mock<ILogger<BlabsController>>().Object, new InMemBlabRepository());
        BlabDto blabDto = new("foobar", "ipsum");

        UserController userController = new(new Mock<ILogger<UserController>>().Object, new InMemUserRepository());
        UserDto userDto = new("fubar", "fubar@example.com", "Fu", "Bar");

        userController.Post(userDto);
        // Act
        IActionResult actual = blabController.Post(blabDto);
        // Assert
        Assert.AreEqual(null, actual);
    }
}