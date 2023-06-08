using BikeSite.Domain;
using BikeSite.Service;
using Microsoft.AspNetCore.Mvc;

namespace BikeSite.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BikeController : ControllerBase
{
    private readonly ILogger<BikeController> _logger;
    private readonly IBikeService _bikeService;

    public BikeController(ILogger<BikeController> logger, IBikeService bikeService)
    {
        _logger = logger;
        _bikeService = bikeService;
    }

    [HttpGet]
    public async Task<OperationResult<List<BikeDto>>> Get()
    {
        return await _bikeService.GetBikes();
    }
    
    [HttpPost]
    public async Task<OperationResult<List<BikeDto>>> Create([FromBody] BikeDto bike)
    {
        return await _bikeService.CreateOrUpdateBike(bike);
    }
    
    [HttpPut]
    public async Task<OperationResult<List<BikeDto>>> Update([FromBody] BikeDto bike)
    {
        return await _bikeService.CreateOrUpdateBike(bike);
    }

    [HttpDelete]
    [Route("{bikeId}")]
    public async Task<OperationResult<List<BikeDto>>> Delete(Guid bikeId)
    {
        return await _bikeService.RemoveBike(bikeId);
    }
}
