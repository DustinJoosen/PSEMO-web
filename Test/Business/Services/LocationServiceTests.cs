using Business.Services;
using Business.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;

namespace Test.Business.Services;


/// <summary>
/// Mock LocationService implementation.
/// </summary>


[TestClass]
public class LocationServiceTests
{
    private Mock<ILocalStorageJwtService> _localStorageJwtService = new Mock<ILocalStorageJwtService>();

    [TestMethod]
    public async Task Remove()
    {
        // Arrange.
        ILocalStorageJwtService service = _localStorageJwtService.Object;

        // Act.
        await service.Remove();

        // Assert.
        Assert.AreEqual(await service.Has(), false);
    }


}
