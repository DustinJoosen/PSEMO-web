using Frontend.Components.Pages.Auth;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;

namespace Test.Frontend.Components.Auth;


[TestClass]
public class RegisterTests
{

    [TestMethod]
    public void EmailValidationHappyPath1()
    {
        // Arrange.
        Register registerPage = new();

        // Act.
        var succeeded = registerPage.EmailInCorrectFormat("dustin@gmail.com");

        // Assert.
        Assert.AreEqual(succeeded, true);
    }

    [TestMethod]
    public void EmailValidationHappyPath2()
    {
        // Arrange.
        Register registerPage = new();

        // Act.
        var succeeded = registerPage.EmailInCorrectFormat("m@g.co");

        // Assert.
        Assert.AreEqual(succeeded, true);
    }

    [TestMethod]
    public void EmailValidationMissingAt()
    {
        // Arrange.
        Register registerPage = new();

        // Act.
        var succeeded = registerPage.EmailInCorrectFormat("dustin.com");

        // Assert.
        Assert.AreEqual(succeeded, false);
    }

    [TestMethod]
    public void EmailValidationMissingDot()
    {
        // Arrange.
        Register registerPage = new();

        // Act.
        var succeeded = registerPage.EmailInCorrectFormat("dustin@gmail");

        // Assert.
        Assert.AreEqual(succeeded, false);
    }

    [TestMethod]
    public void EmailValidationMissingTLD()
    {
        // Arrange.
        Register registerPage = new();

        // Act.
        var succeeded = registerPage.EmailInCorrectFormat("dustin@gmail");

        // Assert.
        Assert.AreEqual(succeeded, false);
    }

    [TestMethod]
    public void EmailValidationTooShortTLD()
    {
        // Arrange.
        Register registerPage = new();

        // Act.
        var succeeded = registerPage.EmailInCorrectFormat("dustin@gmail.c");

        // Assert.
        Assert.AreEqual(succeeded, false);
    }

    [TestMethod]
    public void EmailValidationMissingName()
    {
        // Arrange.
        Register registerPage = new();

        // Act.
        var succeeded = registerPage.EmailInCorrectFormat("@gmail.com");

        // Assert.
        Assert.AreEqual(succeeded, false);
    }

    [TestMethod]
    public void EmailValidationMissingDomain()
    {
        // Arrange.
        Register registerPage = new();

        // Act.
        var succeeded = registerPage.EmailInCorrectFormat("dustin@.com");

        // Assert.
        Assert.AreEqual(succeeded, false);
    }

}