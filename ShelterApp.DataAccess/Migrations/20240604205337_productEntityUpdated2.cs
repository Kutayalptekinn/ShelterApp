using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShelterApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class productEntityUpdated2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Foto",
                table: "TBL_Product",
                newName: "Photo3");

            migrationBuilder.AddColumn<string>(
                name: "FrontPhoto",
                table: "TBL_Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo1",
                table: "TBL_Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo2",
                table: "TBL_Product",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FrontPhoto",
                table: "TBL_Product");

            migrationBuilder.DropColumn(
                name: "Photo1",
                table: "TBL_Product");

            migrationBuilder.DropColumn(
                name: "Photo2",
                table: "TBL_Product");

            migrationBuilder.RenameColumn(
                name: "Photo3",
                table: "TBL_Product",
                newName: "Foto");
        }
    }
}
