using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShelterApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PhotoPropertyAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "FrontPhoto",
                table: "TBL_Sector",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FrontPhoto",
                table: "TBL_Sector");
        }
    }
}
