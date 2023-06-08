namespace BikeSite.Dal.Models;

public class BikeBrand
{
    public int Id { get; set; }
    public Guid BrandId { get; set; }
    //remove nullable suggestion
    #pragma warning disable CS8618
    public string Brand { get; set; }
    #pragma warning restore CS8618
}