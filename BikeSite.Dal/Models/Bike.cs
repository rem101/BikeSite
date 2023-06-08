namespace BikeSite.Dal.Models;

//Should we have auditing fields (IsDeleted, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn)?
public class Bike
{
    public int Id { get; set; }
    public Guid BikeId { get; set; }
    //remove nullable suggestion
    #pragma warning disable CS8618
    public string Model { get; set; }
    #pragma warning restore CS8618
    public int FrameSize { get; set; }
    public decimal Price { get; set; }
    public int BikeBrandId { get; set; }
    //remove nullable suggestion
    #pragma warning disable CS8618
    public BikeBrand Brand { get; set; }
    #pragma warning restore CS8618
}