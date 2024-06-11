using AssetManagement.Repositories;
using Moq;

namespace AssetManagement.Test;

public class AssetsControllerTests
{

    [Fact]
    public async Task GetAssets_ShouldRetunAllAssets()
    {
        // Arrange
        var mockRepo = new Mock<IAssetRepository>();
        mockRepo.Setup(repo => repo.GetAllAssets()).ReturnsAsync(GetTestAssets());
        var controller = new AssetsController(mockRepo.Object);

        // Act
        var result = await controller.GetAssets();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<List<Asset>>(okResult.Value);
        Assert.Equal(3, returnValue.Count);
        
    }
}