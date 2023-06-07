using BikeSite.Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BikeSite.Dal;

public class ApplicationDbContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public ApplicationDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sql server with connection string from app settings
        options.UseSqlServer(Configuration.GetConnectionString("BikeTest"));
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        //Move to map file for larger configurations
        builder.Entity<Bike>().Property(bike => bike.Price).HasPrecision(8, 2);
    }
    
    public DbSet<BikeBrand> BikeBrands { get; set; }
    public DbSet<Bike> Bikes { get; set; }
}