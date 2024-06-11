using AssetManagement.Models;
using AssetManagement.Repositories;

namespace AssetManagement.Test;

public class AssetManagementTests
{
    [Fact]
    public async Task GetAllAssets_ShouldReturnAssets()
    {
        // Arrange
        var repository = new AssetRepository();
        await repository.AddAsset( new Asset { Id = Guid.NewGuid(), Name = "aName", Symbol = "aSymbol", ISIN = "US12345"});
        await repository.AddAsset( new Asset { Id = Guid.NewGuid(), Name = "aName", Symbol = "aSymbol", ISIN = "US12345"});
        await repository.AddAsset( new Asset { Id = Guid.NewGuid(), Name = "aName", Symbol = "aSymbol", ISIN = "US12345"});
        
        // Act
        var result = await repository.GetAllAssets();
        
        // Assert
        Assert.NotNull(result);
        Assert.IsType<List<Asset>>(result);
        
        Assert.Equal(3,result.Count);
        
    }

    [Fact]
    public async Task AddAsset_ShouldAddsAnAssetAndReturnAsset()
    {
        // Arrange
        var _repository = new AssetRepository();
        
        var asset = new Asset { Id = Guid.NewGuid(), Name = "aName", Symbol = "aSymbol", ISIN = "US12345" };
        
        // Arrange
        await _repository.AddAsset(asset);
        var results = await _repository.GetAssetById(asset.Id); //TODO: could test this separately
        
        // Assert
        Assert.NotNull(results);
        Assert.Equal(asset, results);
    }
    //TODO: add fail scenario
    
    [Fact]
    public async Task UpdateAsset_GivenAValidAsset_ShouldUpdateAsset(){}
    //TODO: add fail scenario
    
    [Fact]
    public async Task DeleteAsset_GivenValidAssetId_ShouldDeleteAsset(){}
    //TODO: add invalid assetId scenario and failed delete - how to handle exceptons?

    [Fact]
    public async Task AddPrice_GivenValidPrice_ShouldAddPrice()
    {
        // Arrange
        var priceId = Guid.NewGuid();
        var assetId = Guid.NewGuid();
        var repository = new PriceRepository();
        var price = new Price(priceId, assetId, "Reuters", 150.00m, DateTime.Today);
        
        // Act
        await repository.AddPrice(price);
        var result = await repository.GetPricesByDate(assetId, DateTime.Today);
        
        // Assert
        Assert.Contains(price, result);
    }
    //TODO: failure scenario

    [Fact]
    public async Task UpdatePrice_GivenValidPrice_ShouldUpdatePrice()
    {
        // Arrange
        var priceId = Guid.NewGuid();
        var assetId = Guid.NewGuid();
        var repository = new PriceRepository();
        var price = new Price(priceId, assetId, "Reuters", 150.00m, DateTime.Today);
        await repository.AddPrice(price);
        
        // Act
        var updatedPrice = price with { Value = 155.00m };
        await repository.UpdatePrice(updatedPrice);

        var result = await repository.GetPricesByDate(assetId, DateTime.Today);
        
        // Assert
        Assert.Contains(updatedPrice, result);
        Assert.DoesNotContain(price,result);
        
    }
    //TODO: failure scenario
    
    [Fact]
    public async Task GetPricesByDate_GivenValidDate_ReturnsPriceWithLastesUpdatedDate(){}
    
    [Fact]
    public async Task GetPricesByDate_GivenValidDateAndSource_ReturnsPriceWithLatestUpdateDate(){}
    
    //TODO: add invalid price options and doesnt find the price
}
