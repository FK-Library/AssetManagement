using AssetManagement.Models;

namespace AssetManagement.Repositories;

public class AssetRepository:IAssetRepository
{
    public async Task<List<Asset>> GetAllAssets()
    {
        return new List<Asset>
        {
            new Asset { Name = "Microsoft Corporation", Symbol = "MSFT", ISIN = "US5949181045" },
            new Asset { Name = "Apple Inc.", Symbol = "AAPL", ISIN = "US0378331005" },
            new Asset { Name = "Google LLC", Symbol = "GOOGL", ISIN = "US38259P5089" }
        };

    }
}