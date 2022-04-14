using System;

using DataStore.Plugins;

using Domain.Entities;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStore.UnitTest.Plugins;

[TestClass]
public class MySqlBlabRepositoryTest
{
    private readonly MySqlBlabRepository _blab;
    private readonly string _dsn;

    public MySqlBlabRepositoryTest()
    {
        _dsn = "server=143.110.159.170;uid=donstringham;pwd=letmein;database=donstringham";
        _blab = new MySqlBlabRepository(_dsn);
    }

    [TestMethod]
    public void MySqlBlabRepository_Instantiate()
    {
        // Arrange
        // Act
        MySqlBlabRepository a = new(_dsn);
        // Assert
        Assert.AreEqual(_blab.ToString(), a.ToString());
    }


    [TestMethod]
    public void MySqlBlabRepositoryTest_Insert()
    {
        // Arrange
        Blab e = new(
            "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet",
            "foobar"
        );
        // Act
        _blab.Add(e);
        Blab a = _blab.GetById(e.Id);
        // Assert
        Assert.AreEqual(e.Id.ToString(), a.Id.ToString());
        Assert.AreEqual(e.Content, a.Content);
        Assert.AreEqual(e.Username, a.Username);
    }

    [TestMethod]
    public void MySqlBlabRepositoryTest_InsertTwo()
    {
        // Arrange
        Blab e1 = new(
            "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet",
            "foobar"
        );
        Blab e2 = new(
            "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet",
            "foobar"
        );
        // Act
        _blab.Add(e1);
        _blab.Add(e2);
    }

    [TestMethod]
    public void AddBlabTest()
    {
        Blab blab = new Blab("Testing 123!", "User");
        try
        {
            _blab.Add(blab);
        }
        catch (Exception ex)
        {
            Assert.Fail(ex.Message);
        }
    }

    [TestMethod]
    public void TestUpdate()
    {
        Blab b = new("Some content", "testingUser");
        _blab.Update(b);

        Assert.IsTrue(b.Content == "Some content");
    }

    [TestMethod]
    public void TestRemove()
    {
        ;
        Blab blab = new Blab("Content", "Testing 123user");
        try
        {
            _blab.Remove(blab);
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
            Console.WriteLine(e);
            throw;
        }
    }

    [TestMethod]
    public void TestRemoveAll()
    {
        Blab blab = new Blab("Content", "Testing 123user");
        Blab blab1 = new Blab("Content", "Testing 123user");
        Blab blab2 = new Blab("Content", "Testing 123user");
        Blab blab3 = new Blab("Content", "Testing 123user");
        Blab blab4 = new Blab("Content", "Testing 123user");
        try
        {
            _blab.RemoveAll();
        }
        catch (Exception ex)
        {
            Assert.Fail(ex.Message);
            Console.WriteLine(ex);
            throw;
        }
    }
}