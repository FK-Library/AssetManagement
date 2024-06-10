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
}