using AssetManagement.Controllers;
using AssetManagement.Models;
using AssetManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
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
        
        var controller = new AssetController(mockRepo.Object);

        // Act
        var result = await controller.GetAssets();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<List<Asset>>(okResult.Value);
        Assert.Equal(3, returnValue.Count);
        
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