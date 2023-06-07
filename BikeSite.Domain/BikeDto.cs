using BikeSite.Dal.Models;

namespace BikeSite.Domain;

public class BikeDto
{
    public Guid? BikeId { get; set; }
    public string Model { get; set; }
    public int FrameSize { get; set; }
    public decimal Price { get; set; }
    public BikeBrandDto Brand { get; set; }

    public static BikeDto FromModel(Bike model)
    {
        return new()
        {
            BikeId = model.BikeId,
            Model = model.Model,
            FrameSize = model.FrameSize,
            Price = model.Price,
            Brand = BikeBrandDto.FromModel(model.Brand)
        };
    }
}