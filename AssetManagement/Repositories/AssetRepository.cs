using AssetManagement.Models;

namespace AssetManagement.Repositories;

public class AssetRepository:IAssetRepository
{

    private readonly List<Asset?> _assets = new ();
    private readonly List<Price> _prices = new();

    private Guid _assetId = Guid.NewGuid();
    private Guid _priceId = Guid.NewGuid();
    
    // private static readonly List<Asset> _assets = new()
    // {
    //     new Asset{Id = Guid.NewGuid(), Name = "Microsoft Corporation", Symbol = "MSFT", ISIN = "US5949181045"},
    //     new Asset{Id = Guid.NewGuid(), Name = "Apple Inc.", Symbol = "AAPL", ISIN = "US0378331005"},
    //     new Asset{Id = Guid.NewGuid(), Name = "Google LLC", Symbol = "GOOGL", ISIN = "US38259P5089"}
    // };
    
    //private static readonly List<Price> _prices ;
    //     = new List<Price>
    // {
    //     new Price(Guid.NewGuid(), _assets[0].Id, "source1", 100m, DateTime.Now),
    //     new Price(Guid.NewGuid(), _assets[1].Id, "source2", 200m, DateTime.Now),
    //     new Price(Guid.NewGuid(), _assets[2].Id, "source3", 300m, DateTime.Now)
    // };
    
    
    public async Task<List<Asset?>> GetAllAssets() => await Task.FromResult(_assets.ToList());

    public async Task<Asset?> GetAssetById(Guid id)
    {
        var asset = _assets.FirstOrDefault(a => a.Id == id);
        return await Task.FromResult(asset);
    }

    public async Task AddAsset(Asset? asset)
    {
        if (asset is null)
            throw new ArgumentNullException(nameof(asset));
        
        _assets.Add(asset);
        
        await Task.CompletedTask;
    }

    public async Task UpdateAsset(Asset asset)
    {
        if (asset is null)
            throw new ArgumentNullException(nameof(asset));

        var existingAsset = _assets.FirstOrDefault(a => a.Id == asset.Id);

        if (existingAsset is not null)
        {
            _assets.Remove(existingAsset);
            _assets.Add(asset);
        }

        await Task.Delay(100);

    }

    public async Task DeleteAsset(Guid id)
    {
        var assetToRemove = _assets.FirstOrDefault(a => a.Id == id);

        if (assetToRemove is not null)
            _assets.Remove(assetToRemove);

        await Task.Delay(100);
    }

    public async Task<List<Price>> GetAllPrices() => await Task.FromResult(_prices);
    
    public async Task<List<Price>> GetPricesByDate(Guid assetId, DateTime created, string? source = null)
    {
        await Task.Delay(100);
        var prices = _prices.Where(p => p.AssetId == assetId && p.Created == created);

        if (!string.IsNullOrEmpty(source))
            prices = prices.Where(p => p.Source == source);

        return prices.ToList();
    }

    public async Task AddPrice(Price price)
    {
        if (price is null)
            throw new ArgumentNullException(nameof(price));
        
        //price = price with { Id = Guid.NewGuid() };
        
        
        _prices.Add(price);
        
        await Task.Delay(100);
    }

    public async Task UpdatePrice(Price price)
    {
        if (price is null)
            throw new ArgumentNullException(nameof(price));

        var existingPrice = _prices.FirstOrDefault(p => p.Id == price.Id);
        if (existingPrice is not null)
        {
            _prices.Remove(existingPrice);
            _prices.Add(price);
        }

        await Task.Delay(100);
    }
}