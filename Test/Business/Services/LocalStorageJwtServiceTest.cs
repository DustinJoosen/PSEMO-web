using Infrastructure.Services;
using Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;

namespace Test.Business.Services;


[TestClass]
public class LocalStorageJwtServiceTests
{
    private Mock<ILocalStorageJwtService> _localStorageJwtService = new Mock<ILocalStorageJwtService>();

    //[TestMethod]
    //public async Task HasReturnsTrue()
    //{
    //    // Arrange.
    //    ILocalStorageJwtService service = this._localStorageJwtService.Object;
    //    //await service.Remove();
    //    await service.Set("XXX");

    //    // Act.
    //    var has = await service.Has();

    //    Console.WriteLine(service);
    //    Console.WriteLine(has);

    //    // Assert.
    //    Assert.IsTrue(has);
    //}

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
