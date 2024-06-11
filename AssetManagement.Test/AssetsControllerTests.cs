using AssetManagement.Controllers;
using AssetManagement.Models;
using AssetManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AssetManagement.Test;

public class AssetsControllerTests
{

    [Fact]
    public async Task GetAssets_ShouldReturnAllAssets()
    {
        // Arrange
        var mockRepo = new Mock<IAssetRepository>();
        mockRepo.Setup(repo => repo.GetAllAssets()).ReturnsAsync(GetTestAssets());
        
        var controller = new AssetController(mockRepo.Object);

        // Act
        var result = await controller.GetAssets();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<List<Asset>>(okResult.Value);
        Assert.Equal(3, returnValue.Count);
        
    }

    [Fact]
    public async Task GetAssetById_ValidAssetId_ReturnAsset()
    {
        // Arrange
        var mockRepo = new Mock<IAssetRepository>();
        mockRepo.Setup(repo => repo.GetAssetById(It.IsAny<Guid>())).ReturnsAsync(GetTestAsset());
        var controller = new AssetController(mockRepo.Object);

        // Act
        var result = await controller.GetAsset(GetTestAsset().Id);
       
        // Asseert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<Asset>(okResult.Value);
        Assert.Equal("Microsoft Corporation", returnValue.Name);
    }
    
    [Fact]
    public async Task GetAssetById_InValidId_ReturnsNotFound()
    {
        // Arrange
        var mockRepo = new Mock<IAssetRepository>();
        mockRepo.Setup(repo => repo.GetAssetById(It.IsAny<Guid>())).ReturnsAsync((Asset)null!);
        var controller = new AssetController(mockRepo.Object);

        // Act
        var result = await controller.GetAsset(Guid.NewGuid());
       
        // Asseert
        Assert.IsType<NotFoundResult>(result.Result);
    }
    
    
    private List<Asset> GetTestAssets()
    {
        return new List<Asset>
        {
            new Asset { Id = Guid.NewGuid(), Name = "Microsoft Corporation", Symbol = "MSFT", ISIN = "US5949181045" },
            new Asset { Id = Guid.NewGuid(), Name = "Apple Inc.", Symbol = "AAPL", ISIN = "US0378331005" },
            new Asset { Id = Guid.NewGuid(), Name = "Amazon.com Inc.", Symbol = "AMZN", ISIN = "US0231351067" }
        };
    }

    private Asset GetTestAsset()
    {
        return new Asset{Id=Guid.NewGuid(),Name = "Microsoft Corporation",Symbol = "MSFT",ISIN = "US5949181045"};
    }
}