using AssetManagement.Controllers;
using AssetManagement.Models;
using AssetManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AssetManagement.Test;

public class PriceControllerTests
{
    [Fact]
    public async Task GetPrice_ExistingPrice_ReturnsOKObjectResult()
    {
        // Arrange
        var mockRepo = new Mock<IPriceRepository>();
        var controller = new PriceController(mockRepo.Object);
        var assetId = Guid.NewGuid();
        var created = DateTime.Today;

        mockRepo.Setup(repo => repo.GetPricesByDate(assetId, created, null))
            .ReturnsAsync(new List<Price>
            {
                new Price
                {
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

    [Fact]
    public async Task AddOrUpdatePrice_NewPrice_ReturnsOKResult()
    {
        // Arrange
        var mockRepo = new Mock<IPriceRepository>();
        var controller = new PriceController(mockRepo.Object);
        var price = new Price
        {
            Id = Guid.NewGuid(),
            AssetId = Guid.NewGuid(),
            Source = "X",
            Value = 100.0m,
            Created = DateTime.Today
        };

        mockRepo.Setup(repo => repo.GetPricesByDate(price.AssetId, price.Created, price.Source))
            .ReturnsAsync(new List<Price>());

        mockRepo.Setup(repo => repo.AddPrice(price)).Returns(Task.CompletedTask);

        // Act
        var result = await controller.AddOrUpdatePrice(price);

        // Assert
        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task GetPrices_ExistingPrices_ReturnsOKObjectResult()
    {
        // Arrange
        var mockRepo = new Mock<IPriceRepository>();
        var controller = new PriceController(mockRepo.Object);
        var assetId = Guid.NewGuid();

        mockRepo.Setup(repo => repo.GetPricesByAsset(assetId, null))
            .ReturnsAsync(new List<Price>
            {
                new Price
                {
                    Id = Guid.NewGuid(),
                    AssetId = assetId,
                    Source = "X",
                    Value = 100.0m,
                    Created = DateTime.Today
                }
            });

        // Act
        var result = await controller.GetPrices(assetId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<Price>>(okResult.Value);
        Assert.Single(returnValue);
    }

    private List<Price> GetTestPrices()
    {
        return new List<Price>
        {
            new Price
            {
                Id = Guid.NewGuid(),
                AssetId = Guid.NewGuid(),
                Source = "Reuters",
                Value = 150.0m,
                Created = DateTime.Today
            },
            new Price
            {
                Id = Guid.NewGuid(),
                AssetId = Guid.NewGuid(),
                Source = "Bloomberg",
                Value = 160.0m,
                Created = DateTime.Today
            }
        };
    }
}

