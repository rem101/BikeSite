using BikeSite.Dal.Models;

namespace BikeSite.Domain;

public class BikeBrandDto
{
    public Guid BikeBrandId { get; set; }
    public string Brand { get; set; }

    public static BikeBrandDto FromModel(BikeBrand model)
    {
        return new()
        {
            BikeBrandId = model.BrandId,
            Brand = model.Brand
        };
    }
}