using AssetManagement.Models;

namespace AssetManagement.Repositories;

public class PriceRepository: IPriceRepository
{
    private readonly List<Price> _prices = new();

    private Guid _priceId = Guid.NewGuid();
    
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