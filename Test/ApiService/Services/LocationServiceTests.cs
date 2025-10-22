using Infrastructure.Services;
using Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;

namespace Test.ApiClient.Services;


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
        ILocalStorageJwtService service = this._localStorageJwtService.Object;

        // Act.
        await service.Remove();

        // Assert.
        Assert.AreEqual(await service.Has(), false);
    }


}
