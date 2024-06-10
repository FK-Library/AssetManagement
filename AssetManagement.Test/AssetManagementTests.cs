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
