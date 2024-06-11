using AssetManagement.Models;
using AssetManagement.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PriceController : ControllerBase
{
    private readonly IPriceRepository _repository;

    public PriceController(IPriceRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("{assetId}/{date}")]
    public async Task<IActionResult> GetPricesByDate(Guid assetId, DateTime date, string? source = null)
    {
        var prices = await _repository.GetPricesByDate(assetId, date, source);
        if (prices.Count == 0)
            return NotFound();

        return Ok(prices);
    }

    [HttpPost]
    public async Task<IActionResult> AddOrUpdatePrice([FromBody] Price price)
    {
        var existingPrices = await _repository.GetPricesByDate(price.AssetId, price.Created, price.Source);
        if (existingPrices.Count > 0)
        {
            await _repository.UpdatePrice(price);
        }
        else
        {
            await _repository.AddPrice(price);
        }

        return Ok();
    }

    [HttpGet("{assetId}")]
    public async Task<IActionResult> GetPrices(Guid assetId, string? source = null)
    {
        var existingPrices = await _repository.GetPricesByAsset(assetId, source);
        if (existingPrices.Count == 0)
            return NotFound();

        return Ok(existingPrices);
    }
}

    