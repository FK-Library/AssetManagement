using AssetManagement.Models;

namespace AssetManagement.Repositories;

public class AssetRepository:IAssetRepository
{

    private static readonly List<Asset> _assets = new List<Asset>
    {
        new Asset(Guid.NewGuid(), "Microsoft Corporation", "MSFT", "US5949181045"),
        new Asset(Guid.NewGuid(), "Apple Inc.", "AAPL", "US0378331005"),
        new Asset(Guid.NewGuid(), "Google LLC", "GOOGL", "US38259P5089")
    };

    private static readonly List<Price> _prices = new List<Price>
    {
        new Price(Guid.NewGuid(), _assets[0].Id, "source1", 100m, DateTime.Now),
        new Price(Guid.NewGuid(), _assets[1].Id, "source2", 200m, DateTime.Now),
        new Price(Guid.NewGuid(), _assets[2].Id, "source3", 300m, DateTime.Now)
    };
    
    
    public async Task<List<Asset>> GetAllAssets() => await Task.FromResult(_assets);

    public Task<Asset> GetAssetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsset(Asset asset)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsset(Asset asset)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsset(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Price>> GetAllPrices() => await Task.FromResult(_prices);
    
    public Task<List<Price>> GetPricesByDate(Guid assetId, DateTime created, string? source = null)
    {
        throw new NotImplementedException();
    }

    public Task AddPrice(Price price)
    {
        throw new NotImplementedException();
    }

    public Task UpdatePrice(Price price)
    {
        throw new NotImplementedException();
    }
}