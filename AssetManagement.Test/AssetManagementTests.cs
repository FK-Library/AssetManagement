using AssetManagement.Models;
using AssetManagement.Repositories;
using Xunit;

namespace AssetManagement.Test;

public class AssetManagementTests
{
    [Fact]
    public async Task GetAllAssets_ShouldReturnAssets()
    {
        // Arrange
        var repository = new AssetRepository();
        
        // Act
        var assets = await repository.GetAllAssets();
        
        // Assert
        Assert.NotNull(assets);
        Assert.IsType<List<Asset>>(assets);
        Assert.Equal(3,assets.Count);
    }
    
    [Fact]
    public async Task AddAsset_ShouldAddsAnAssetAndReturnAsset(){}
    //TODO: add fail scenario
    
    [Fact]
    public async Task UpdateAsset_GivenAValidAsset_ShouldUpdateAsset(){}
    //TODO: add fail scenario
    
    [Fact]
    public async Task DeleteAsset_GivenValidAssetId_ShouldDeleteAsset(){}
    //TODO: add invalid assetId scenario and failed delete - how to handle exceptons?
    
    [Fact]
    public async Task GetAssetById_GivenAnAssetId_ReturnsAnAsset(){}
    
    [Fact]
    public async Task GetAllPrices_ShouldReturnPrices()
    {
        // Arrange
        var repository = new AssetRepository();
        
        // Act
        var prices = await repository.GetAllPrices();
        
        
        // Assert
        Assert.NotNull(prices);
        
        Assert.IsType<List<Price>>(prices);
        Assert.Equal(3,prices.Count);
    }
    
    [Fact]
    public async Task AddPrice_GivenValidPrice_ShouldAddPrice(){}
    //TODO: failure scenario
    
    [Fact]
    public async Task UpdatePrice_GivenValidPrice_ShouldUpdatePrice(){}
    //TODO: failure scenario
    
    [Fact]
    public async Task GetPricesByDate_GivenValidDate_ReturnsPriceWithLastesUpdatedDate(){}
    
    [Fact]
    public async Task GetPricesByDate_GivenValidDateAndSource_ReturnsPriceWithLatestUpdateDate(){}
    
    //TODO: add invalid price options and doesnt find the price
}
