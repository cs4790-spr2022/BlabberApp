using System.Linq;

using DataStore.Plugins;

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
        var e = new BlabsController(new Mock<ILogger<BlabsController>>().Object, new InMemBlabRepository());
        // Act
        var a = new BlabsController(new Mock<ILogger<BlabsController>>().Object, new InMemBlabRepository());
        // Assert
        Assert.AreEqual(e.GetType(), a.GetType());
        Assert.IsInstanceOfType(e, typeof(BlabsController));
    }

    [TestMethod]
    public void TestGetAllEmpty()
    {
        // Arrange
        var h = new BlabsController(new Mock<ILogger<BlabsController>>().Object, new InMemBlabRepository());
        // Act
        var a = h.GetAll();
        // Assert
        Assert.AreEqual(0, a.Count());
    }

    [TestMethod]
    public void TestPostAndGetAll()
    {
        // Arrange
        var h = new BlabsController(new Mock<ILogger<BlabsController>>().Object, new InMemBlabRepository());
        var d = new BlabDto("fubar", "ipsum");
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
        var h = new BlabsController(new Mock<ILogger<BlabsController>>().Object, new InMemBlabRepository());
        var d = new BlabDto("fubar", "ipsum");
        // Act
        h.Post(d);
        var b = h.GetAll();
        var a = h.GetById(b.First().Id);
        // Assert
        Assert.AreEqual("Microsoft.AspNetCore.Mvc.OkObjectResult", a.ToString());
    }
}