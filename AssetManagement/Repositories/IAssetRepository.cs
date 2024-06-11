using AssetManagement.Models;

namespace AssetManagement.Repositories;

public interface IAssetRepository
{
   Task<List<Asset?>> GetAllAssets();
   Task<Asset?> GetAssetById(Guid id);
   Task AddAsset(Asset? asset);
   Task UpdateAsset(Asset asset);
   Task DeleteAsset(Guid id);
}