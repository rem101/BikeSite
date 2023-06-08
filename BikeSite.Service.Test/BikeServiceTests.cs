using BikeSite.Dal;
using BikeSite.Dal.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;

namespace BikeSite.Service.Test;

[TestClass]
public class BikeServiceTests
{
    private const string CANNONDALE = "20DB930A-19C2-4914-9E59-2F72418256D2";
    private const string GARYFISHER = "3BA79388-E637-4334-B9C7-4AD1CDA3A910";
    
    [TestMethod]
    public async Task TestGet()
    {
        var context = getContext();
        var service = new BikeService(context);
        var bikes = await service.GetBikes();
        Assert.AreEqual(true, bikes.Success);
        Assert.AreEqual(2, bikes.Value.Count);
    }
    
    private ApplicationDbContext getContext()
    {
        var brands = new List<BikeBrand>
        {
            new BikeBrand() { Id = 1, BrandId = Guid.Parse(GARYFISHER), Brand = "Gary Fisher" },
            new BikeBrand() { Id = 2, BrandId = Guid.Parse(CANNONDALE), Brand = "Cannondale" },
        }.AsQueryable();

        var bikes = new List<Bike>
        {
            new Bike() { Id = 1, BikeId = Guid.NewGuid(), BikeBrandId = 1, FrameSize = 20, Price = 500, Model = "Old School" },
            new Bike() { Id = 2, BikeId = Guid.NewGuid(), BikeBrandId = 2, FrameSize = 24, Price = 500, Model = "BadBoy 1 Disc" }
        }.AsQueryable();

        var brandSet = new Mock<DbSet<BikeBrand>>();
        brandSet.As<IQueryable<BikeBrand>>().Setup(m => m.Provider).Returns(brands.Provider);
        brandSet.As<IQueryable<BikeBrand>>().Setup(m => m.Expression).Returns(brands.Expression);
        brandSet.As<IQueryable<BikeBrand>>().Setup(m => m.ElementType).Returns(brands.ElementType);
        brandSet.As<IQueryable<BikeBrand>>().Setup(m => m.GetEnumerator()).Returns(() => brands.GetEnumerator());
        
        var bikeSet = new Mock<DbSet<Bike>>();
        bikeSet.As<IQueryable<Bike>>().Setup(m => m.Provider).Returns(bikes.Provider);
        bikeSet.As<IQueryable<Bike>>().Setup(m => m.Expression).Returns(bikes.Expression);
        bikeSet.As<IQueryable<Bike>>().Setup(m => m.ElementType).Returns(bikes.ElementType);
        bikeSet.As<IQueryable<Bike>>().Setup(m => m.GetEnumerator()).Returns(() => bikes.GetEnumerator());
        
        var mockContext = new Mock<ApplicationDbContext>();
        // mockContext.Setup(c => c.BikeBrands).Returns(brandSet.Object);
        // mockContext.Setup(c => c.Bikes).Returns(bikeSet.Object);
        
        return mockContext.Object;
    }
}