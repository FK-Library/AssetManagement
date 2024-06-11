using AssetManagement.Controllers;
using AssetManagement.Models;
using AssetManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AssetManagement.Test;

public class PriceControllerTests
{

    // [Fact]
    // public async Task GetPrice_ExistingPrice_ReturnsOKObjectresult()
    // {
    //     // Arrange
    //     var mockRepo = new Mock<IPriceRepository>();
    //     mockRepo.Setup(repo => repo.GetAllPrices()).ReturnsAsync(GetTestPrices());
    //     var controller = new PriceController(mockRepo.Object);
    //
    //     // Act
    //     var result = await controller.GetPrice();
    //
    //     // Assert
    //     var okResult = Assert.IsType<OkObjectResult>(result.Result);
    //     var returnValue = Assert.IsType<List<Asset>>(okResult.Value);
    //     Assert.Equal(3, returnValue.Count);
    //
    // }

    public async Task GetPrice_ExistingPrice_ReturnsOKObjectresult()
    {
        // Arrange
        var mockRepo = new Mock<IPriceRepository>();
        // mockRepo.Setup(repo => repo.GetAllPrices()).ReturnsAsync(GetTestPrices());
        var controller = new PriceController(mockRepo.Object);
        var assetId = Guid.NewGuid();
        var created = DateTime.Today;
        
        mockRepo.Setup(repo => repo.GetPricesByDate(assetId, created,null))
            .ReturnsAsync(
                new List<Price>
                {
                    new Price{
                        Id = Guid.NewGuid(),
                        AssetId = assetId,
                        Source = "X",
                        Value = 100.0m,
                        Created = created
                    }
                });
        
        // Act
        var result = await controller.GetPricesByDate(assetId, created);
        
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<Price>>(okResult.Value);
        Assert.Single(returnValue);
    } 
    private List<Price> GetTestPrices()
    {
        return new List<Price>
        {
            new Price{
                Id = Guid.NewGuid(),
                AssetId = Guid.NewGuid(),
                Source = "Reuters",
                Value = 150.0m,
                Created = DateTime.Today
            },
            new Price{
                Id = Guid.NewGuid(),
                AssetId = Guid.NewGuid(),
                Source = "Bloomberg",
                Value = 160.0m,
                Created = DateTime.Today
            }
        };
    }
}