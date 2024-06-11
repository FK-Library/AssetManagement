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
        var assets = await _repository.GetAllassets();
        return Ok(assets);
    }

}