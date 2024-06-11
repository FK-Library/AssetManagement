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
    //     mockRepo.Setup(repo => repo.GetAllAssets()).ReturnsAsync(GetTestAssets());
    //
    //     var controller = new AssetController(mockRepo.Object);
    //
    //     // Act
    //     var result = await controller.GetAssets();
    //
    //     // Assert
    //     var okResult = Assert.IsType<OkObjectResult>(result.Result);
    //     var returnValue = Assert.IsType<List<Asset>>(okResult.Value);
    //     Assert.Equal(3, returnValue.Count);
    //
    // }

    // [Fact]
    // public async Task GetAssetById_ValidAssetId_ReturnAsset()
    // {
    //     // Arrange
    //     var mockRepo = new Mock<IAssetRepository>();
    //     mockRepo.Setup(repo => repo.GetAssetById(It.IsAny<Guid>())).ReturnsAsync(GetTestAsset());
    //     var controller = new AssetController(mockRepo.Object);
    //
    //     // Act
    //     var result = await controller.GetAsset(Guid.NewGuid());
    //
    //     // Asseert
    //     var okResult = Assert.IsType<OkObjectResult>(result.Result);
    //     var returnValue = Assert.IsType<Asset>(okResult.Value);
    //     Assert.Equal("Microsoft Corporation", returnValue.Name);
    // }
    //
    // [Fact]
    // public async Task GetAssetById_InValidId_ReturnsNotFound()
    // {
    //     // Arrange
    //     var mockRepo = new Mock<IAssetRepository>();
    //     mockRepo.Setup(repo => repo.GetAssetById(It.IsAny<Guid>())).ReturnsAsync((Asset)null!);
    //     var controller = new AssetController(mockRepo.Object);
    //
    //     // Act
    //     var result = await controller.GetAsset(Guid.NewGuid());
    //
    //     // Asseert
    //     Assert.IsType<NotFoundResult>(result.Result);
    // }
    //
    // [Fact]
    // public async Task AddAsset_ShouldReturnCreatedAtAction()
    // {
    //     // Arrange
    //     var mockRepo = new Mock<IAssetRepository>();
    //     var controller = new AssetController(mockRepo.Object);
    //     var newAsset = new Asset { Id = Guid.NewGuid(), Name = "Apple Inc.", Symbol = "AAPL", ISIN = "US0378331005" };
    //
    //     // Act
    //     var result = await controller.AddAsset(newAsset);
    //
    //     // Asseert
    //     var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
    //     var returnValue = Assert.IsType<Asset>(createdAtActionResult.Value);
    //     Assert.Equal("Apple Inc.", returnValue.Name);
    // }
    //
    // [Fact]
    // public async Task UpdateAsset_ShouldReturnNoContent()
    // {
    //     // Arrange
    //     var mockRepo = new Mock<IAssetRepository>();
    //     var controller = new AssetController(mockRepo.Object);
    //     var updatedAsset = new Asset
    //         { Id = Guid.NewGuid(), Name = "Apple Inc.", Symbol = "AAPL", ISIN = "US0378331005" };
    //
    //     mockRepo.Setup(repo => repo.GetAssetById(updatedAsset.Id)).ReturnsAsync(updatedAsset);
    //     mockRepo.Setup(repo => repo.UpdateAsset(updatedAsset)).Returns(Task.CompletedTask);
    //
    //     // Act
    //     var result = await controller.UpdateAsset(updatedAsset.Id, updatedAsset);
    //
    //     // Asseert
    //     Assert.IsType<NoContentResult>(result);
    //     var noContentResult = result as NoContentResult;
    //     Assert.Equal(204, noContentResult.StatusCode);
    // }
    //
    // [Fact]
    // public async Task UpdateAsset_IdMismatch_ShouldReturnBadRequest()
    // {
    //     // Arrange
    //     var mockRepo = new Mock<IAssetRepository>();
    //     var controller = new AssetController(mockRepo.Object);
    //     var updatedAsset = new Asset
    //         { Id = Guid.NewGuid(), Name = "Apple Inc.", Symbol = "AAPL", ISIN = "US0378331005" };
    //     var differentId = Guid.NewGuid();
    //
    //     // Act
    //     var result = await controller.UpdateAsset(differentId, updatedAsset);
    //
    //     // Asseert
    //     Assert.IsType<BadRequestResult>(result);
    // }
    //
    // [Fact]
    // public async Task UpdateAsset_AssetNotFound_ShouldReturnNotFound()
    // {
    //     // Arrange
    //     var mockRepo = new Mock<IAssetRepository>();
    //     var controller = new AssetController(mockRepo.Object);
    //     var updatedAsset = new Asset
    //         { Id = Guid.NewGuid(), Name = "Apple Inc.", Symbol = "AAPL", ISIN = "US0378331005" };
    //
    //     mockRepo.Setup(repo => repo.GetAssetById(updatedAsset.Id)).ReturnsAsync((Asset)null);
    //
    //     // Act
    //     var result = await controller.UpdateAsset(updatedAsset.Id, updatedAsset);
    //
    //     // Assert
    //     Assert.IsType<NotFoundResult>(result);
    // }
    //
    // [Fact]
    // public async Task DeleteAsset_ShoouldReturnNoContent()
    // {
    //     // Arrange
    //     var mockRepo = new Mock<IAssetRepository>();
    //     var controller = new AssetController(mockRepo.Object);
    //     var assetId = Guid.NewGuid();
    //
    //     mockRepo.Setup(repo => repo.GetAssetById(assetId)).ReturnsAsync(new Asset
    //         { Id = assetId, Name = "Test Asset", Symbol = "TEST", ISIN = "US1234567890" });
    //     mockRepo.Setup(repo => repo.DeleteAsset(assetId)).Returns(Task.CompletedTask);
    //
    //     // Act
    //     var result = await controller.DeleteAsset(assetId);
    //
    //     // Assert
    //     Assert.IsType<NoContentResult>(result);
    //     var noContentResult = result as NoContentResult;
    //     Assert.Equal(204, noContentResult.StatusCode);
    //
    // }
    //
    // [Fact]
    // public async Task DeleteAsset_AssetNotFound_ShouldReturnNotFound()
    // {
    //     // Arrange
    //     var mockRepo = new Mock<IAssetRepository>();
    //     var controller = new AssetController(mockRepo.Object);
    //     var assetId = Guid.NewGuid();
    //
    //     mockRepo.Setup(repo => repo.GetAssetById(assetId)).ReturnsAsync((Asset)null);
    //
    //     // Act
    //     var result = await controller.DeleteAsset(assetId);
    //
    //     // Assert
    //     Assert.IsType<NotFoundResult>(result);
    // }
    //
    // private List<Asset> GetTestAssets()
    // {
    //     return new List<Asset>
    //     {
    //         new Asset { Id = Guid.NewGuid(), Name = "Microsoft Corporation", Symbol = "MSFT", ISIN = "US5949181045" },
    //         new Asset { Id = Guid.NewGuid(), Name = "Apple Inc.", Symbol = "AAPL", ISIN = "US0378331005" },
    //         new Asset { Id = Guid.NewGuid(), Name = "Amazon.com Inc.", Symbol = "AMZN", ISIN = "US0231351067" }
    //     };
    // }
    //
    // private Asset GetTestAsset()
    // {
    //     return new Asset
    //         { Id = Guid.NewGuid(), Name = "Microsoft Corporation", Symbol = "MSFT", ISIN = "US5949181045" };
    // }
}