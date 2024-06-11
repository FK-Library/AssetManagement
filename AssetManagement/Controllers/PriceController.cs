using System.Reflection;
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
    public async Task<IActionResult> GetPricesByDate(Guid assetId, DateTime date)
    {
        var prices = await _repository.GetPricesByDate(assetId, date);
        if (prices.Count == 0)
            return NotFound();
        
        return Ok();
    }
}