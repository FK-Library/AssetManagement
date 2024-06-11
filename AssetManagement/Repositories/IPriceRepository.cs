using AssetManagement.Models;

namespace AssetManagement.Repositories;

public interface IPriceRepository
{
   Task<List<Price>> GetAllPrices();
   
   /// <summary>
   /// Retrieve the price of one or more assets, for a given date, optionally from a specific source.
   /// Your results should include the timestamp for when each price was last updated (or created).
   /// I added priceId as well
   /// </summary>
   /// <returns> List<Prices>> </returns>
   Task<List<Price>> GetPricesByDate(Guid assetId, DateTime created, string? source = null);
   Task AddPrice(Price price);
   Task UpdatePrice(Price price);
}