namespace BikeSite.Dal.Models;

//Should we have auditing fields (IsDeleted, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn)?
public class Bike
{
    public int Id { get; set; }
    public Guid BikeId { get; set; }
    public string Model { get; set; }
    public int FrameSize { get; set; }
    public decimal Price { get; set; }
    public int BikeBrandId { get; set; }
    public BikeBrand Brand { get; set; }
}