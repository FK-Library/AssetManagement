using AssetManagement.Models;

namespace AssetManagement.Repositories;

public interface IAssetRepository
{
   Task<List<Asset>> GetAllAssets();
}