using System.Reflection;
using AssetManagement.Models;
using AssetManagement.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PriceController: ControllerBase
{
    private readonly IAssetRepository _repository;

    public PriceController(IAssetRepository repository)
    {
        _repository = repository;
    }

//     [HttpGet]
//     public async Task<ActionResult<IEnumerable<Asset>>> GetAssets()
//     {
//         var assets = await _repository.GetAllAssets();
//         return Ok(assets);
//     }
//
//     [HttpGet("{id}")]
//     public async Task<ActionResult<Asset>> GetAsset(Guid id)
//     {
//         var asset = await _repository.GetAssetById(id);
//         if (asset is null)
//             return NotFound();
//         return Ok(asset);
//     }
//
//     [HttpPost]
//     public async Task<CreatedAtActionResult> AddAsset(Asset asset)
//     {
//         await _repository.AddAsset(asset);
//         return CreatedAtAction(nameof(GetAsset), new { id = asset.Id }, asset);
//     }
//
// [HttpPut("{id}")]
//     public async Task<object?> UpdateAsset(Guid id, Asset asset)
//     {
//         if (id != asset.Id)
//             return BadRequest();
//
//         var existingAsset = await _repository.GetAssetById(id);
//         
//         if (existingAsset is null)
//             return NotFound();
//         
//         await _repository.UpdateAsset(asset);
//         
//         return NoContent();
//     }
//     
//     [HttpDelete]
//     public async Task<IActionResult> DeleteAsset(Guid id)
//     {
//         var existingAsset = await _repository.GetAssetById(id);
//
//         if (existingAsset is null)
//             return NotFound();
//         
//         await _repository.DeleteAsset(id);
//         
//         return NoContent();
//     }
}