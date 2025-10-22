using Infrastructure.Services;
using Infrastructure.Services.Interfaces;

namespace Test.Infrastructure.Services;


[TestClass]
public class PasswordPolicyServiceTests
{

    [TestMethod]
    public void HappyPath1()
    {
        // Arrange.
        IPasswordPolicyService passwordPolicyService = new PasswordPolicyService();
        string validationMessage = string.Empty;

        // Act.
        bool succeeded = passwordPolicyService.IsPasswordValid("Password1!", out validationMessage);

        // Assert.
        Assert.AreEqual(succeeded, true);
        Assert.AreEqual(validationMessage, string.Empty);
    }

    [TestMethod]
    public void HappyPath2()
    {
        // Arrange.
        IPasswordPolicyService passwordPolicyService = new PasswordPolicyService();
        string validationMessage = string.Empty;

        // Act.
        bool succeeded = passwordPolicyService.IsPasswordValid("R@ot5!", out validationMessage);

        // Assert.
        Assert.AreEqual(succeeded, true);
        Assert.AreEqual(validationMessage, string.Empty);
    }

    [TestMethod]
    public void EmptyPassword()
    {
        // Arrange.
        IPasswordPolicyService passwordPolicyService = new PasswordPolicyService();
        string validationMessage = string.Empty;

        // Act.
        bool succeeded = passwordPolicyService.IsPasswordValid("", out validationMessage);

        // Assert.
        Assert.AreEqual(succeeded, false);
        Assert.AreEqual(validationMessage, "Wachtwoord moet tenminste 6 tekens lang zijn");
    }

    [TestMethod]
    public void ShortPassword()
    {
        // Arrange.
        IPasswordPolicyService passwordPolicyService = new PasswordPolicyService();
        string validationMessage = string.Empty;

        // Act.
        bool succeeded = passwordPolicyService.IsPasswordValid("Short", out validationMessage);

        // Assert.
        Assert.AreEqual(succeeded, false);
        Assert.AreEqual(validationMessage, "Wachtwoord moet tenminste 6 tekens lang zijn");
    }

    [TestMethod]
    public void NoCapitals()
    {
        // Arrange.
        IPasswordPolicyService passwordPolicyService = new PasswordPolicyService();
        string validationMessage = string.Empty;

        // Act.
        bool succeeded = passwordPolicyService.IsPasswordValid("tooshort", out validationMessage);

        // Assert.
        Assert.AreEqual(succeeded, false);
        Assert.AreEqual(validationMessage, "Wachtwoord moet tenminste 1 hoofdletters hebben");
    }

    [TestMethod]
    public void NoNumbers()
    {
        // Arrange.
        IPasswordPolicyService passwordPolicyService = new PasswordPolicyService();
        string validationMessage = string.Empty;

        // Act.
        bool succeeded = passwordPolicyService.IsPasswordValid("TooShort", out validationMessage);

        // Assert.
        Assert.AreEqual(succeeded, false);
        Assert.AreEqual(validationMessage, "Wachtwoord moet tenminste 1 nummers hebben");
    }

    [TestMethod]
    public void NoSpecChar()
    {
        // Arrange.
        IPasswordPolicyService passwordPolicyService = new PasswordPolicyService();
        string validationMessage = string.Empty;

        // Act.
        bool succeeded = passwordPolicyService.IsPasswordValid("TooShort1", out validationMessage);

        // Assert.
        Assert.AreEqual(succeeded, false);
        Assert.AreEqual(validationMessage, "Wachtwoord moet tenminste 1 speciale characters hebben");
    }

}