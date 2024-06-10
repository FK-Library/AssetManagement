using AssetManagement.Models;

namespace AssetManagement.Repositories;

public class AssetRepository:IAssetRepository
{
    private readonly List<Asset> _assets = new();
    private readonly List<Price> _prices = new();
    private (Guid, Guid, Guid) _assetIds = (Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());
    private (Guid, Guid, Guid) _priceIds = (Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());
    
    
    public async Task<List<Asset>> GetAllAssets()
    {
        return await Task.FromResult( new List<Asset>
        {
            new Asset(Guid.NewGuid(),"Microsoft Corporation", "MSFT", "US5949181045"),
            new Asset(Guid.NewGuid(),"Apple Inc.", "AAPL", "US0378331005"),
            new Asset(Guid.NewGuid(),"Google LLC", "GOOGL", "US38259P5089")
        });

    }

    public async Task<List<Price>> GetAllPrices()
    {
        return await Task.FromResult(new List<Price>
        {
            new Price(Guid.NewGuid(),Guid.NewGuid(), "source1",100m, DateTime.Now ),
            new Price(Guid.NewGuid(),Guid.NewGuid(), "source2",200m, DateTime.Now ),
            new Price(Guid.NewGuid(),Guid.NewGuid(), "source3",300m, DateTime.Now ),

            
            
        });
    }
}