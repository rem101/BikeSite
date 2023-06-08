using BikeSite.Dal;
using BikeSite.Domain;
using Microsoft.EntityFrameworkCore;

namespace BikeSite.Service;

public interface ILookupService
{
    Task<OperationResult<List<BikeBrandDto>>> GetBrands();
}

public class LookupService : ILookupService
{
    private readonly ApplicationDbContext _dbContext;

    public LookupService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<OperationResult<List<BikeBrandDto>>> GetBrands()
    {
        try
        {
            var brands = _dbContext.BikeBrands.AsNoTracking();
            return new OperationResult<List<BikeBrandDto>>()
            {
                Success = true,
                Value = await brands.Select(x => BikeBrandDto.FromModel(x)).ToListAsync()
            };
        }
        catch (Exception e)
        {
            return new OperationResult<List<BikeBrandDto>>()
            {
                Success = false,
                Error = e.ToString()
            };
        }
    }
}