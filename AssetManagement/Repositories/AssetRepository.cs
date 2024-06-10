using AssetManagement.Models;

namespace AssetManagement.Repositories;

public class AssetRepository:IAssetRepository
{

    private readonly List<Asset?> _assets = new ();
    private readonly List<Price> _prices = new();

    private Guid _assetId = Guid.NewGuid();
    private Guid _priceId = Guid.NewGuid();
    
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