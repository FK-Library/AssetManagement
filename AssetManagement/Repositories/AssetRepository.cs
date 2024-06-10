using AssetManagement.Models;

namespace AssetManagement.Repositories;

public class AssetRepository:IAssetRepository
{
    
    
    private static readonly List<Asset> _assets = new()
    {
        new Asset{Id = Guid.NewGuid(), Name = "Microsoft Corporation", Symbol = "MSFT", ISIN = "US5949181045"},
        new Asset{Id = Guid.NewGuid(), Name = "Apple Inc.", Symbol = "AAPL", ISIN = "US0378331005"},
        new Asset{Id = Guid.NewGuid(), Name = "Google LLC", Symbol = "GOOGL", ISIN = "US38259P5089"}
    };
    
    private static readonly List<Price> _prices ;
    //     = new List<Price>
    // {
    //     new Price(Guid.NewGuid(), _assets[0].Id, "source1", 100m, DateTime.Now),
    //     new Price(Guid.NewGuid(), _assets[1].Id, "source2", 200m, DateTime.Now),
    //     new Price(Guid.NewGuid(), _assets[2].Id, "source3", 300m, DateTime.Now)
    // };
    
    
    public async Task<List<Asset>> GetAllAssets() => await Task.FromResult(_assets);

    public async Task<Asset> GetAssetById(Guid id)
    {
        var asset = _assets.FirstOrDefault(a => a.Id == id);
        return await Task.FromResult(asset);
    }

    public async Task AddAsset(Asset asset)
    {
        if (asset is null)
            throw new ArgumentNullException();
        _assets.Add(asset);
        
        await Task.CompletedTask;
    }

    public Task UpdateAsset(Asset asset)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsset(Guid id)
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