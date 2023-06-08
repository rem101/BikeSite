using BikeSite.Domain;
using BikeSite.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BikeSite.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LookupController
{
    private readonly ILogger<BikeController> _logger;
    private readonly ILookupService _lookupService;

    public LookupController(ILogger<BikeController> logger, ILookupService lookupService)
    {
        _logger = logger;
        _lookupService = lookupService;
    }
    
    [HttpGet]
    [Route("bike-brands")]
    public async Task<OperationResult<List<BikeBrandDto>>> GetBrands()
    {
        return await _lookupService.GetBrands();
    }
}