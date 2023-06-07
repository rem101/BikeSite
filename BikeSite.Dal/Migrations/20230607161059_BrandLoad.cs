using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeSite.Dal.Migrations
{
    /// <inheritdoc />
    public partial class BrandLoad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Could truncate table to guarentee a clean table
            // if we care the lookup tables have the same Id's/ExternalId's, set them in a migration 
            migrationBuilder.Sql("SET IDENTITY_INSERT dbo.BikeBrands ON");
            migrationBuilder.Sql(
                "INSERT INTO BikeBrands (Id, BrandId, Brand) values (1, '628D93B1-D0EE-42C5-87C2-E15512F2670B', 'GT')");
            migrationBuilder.Sql(
                "INSERT INTO BikeBrands (Id, BrandId, Brand) values (2, 'A63181CC-8856-401F-BA1A-7F19AD8FF6A6', 'Specialized')");
            migrationBuilder.Sql(
                "INSERT INTO BikeBrands (Id, BrandId, Brand) values (3, 'B88E220B-7F9A-4B30-B083-989718611EC5', 'Canyon')");
            migrationBuilder.Sql(
                "INSERT INTO BikeBrands (Id, BrandId, Brand) values (4, 'E8490B18-F942-4384-9474-FE96F283CE1D', 'Trek')");
            migrationBuilder.Sql("SET IDENTITY_INSERT dbo.BikeBrands OFF");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM BikeBrands where Id < 5");
        }
    }
}
