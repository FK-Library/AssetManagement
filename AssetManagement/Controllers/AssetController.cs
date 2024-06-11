using AssetManagement.Models;
using AssetManagement.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Controllers;

public class AssetController: ControllerBase
{
    private readonly IAssetRepository _repository;

    public AssetController(IAssetRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Asset>>> GetAssets()
    {
        var assets = await _repository.GetAllAssets();
        return Ok(assets);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Asset>> GetAsset(Guid id)
    {
        var asset = await _repository.GetAssetById(id);
        if (asset is null)
            return NotFound();
        return Ok(asset);
    }
}