using AssetManagement.Models;

namespace AssetManagement.Repositories;

public interface IAssetRepository
{
   Task<List<Asset>> GetAllAssets();
   Task<Asset> GetAssetById(int id);
   Task AddAsset(Asset asset);
   Task UpdateAsset(Asset asset);
   Task DeleteAsset(int id); //TODO: By Id?
   
   Task<List<Price>> GetAllPrices(); //TODO: This is not part of requirements and only for my reference and testing prices - should be removed

   /// <summary>
   /// Retrieve the price of one or more assets, for a given date, optionally from a specific source.
   /// Your results should include the timestamp for when each price was last updated (or created).
   /// </summary>
   /// <returns> List<Prices>> </returns>
   Task<List<Price>> GetPricesByDate(Guid assetId, DateTime created, string? source = null);
   Task AddPrice(Price price);
   Task UpdatePrice(Price price);
}