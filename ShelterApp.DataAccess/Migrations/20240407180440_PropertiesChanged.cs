using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShelterApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PropertiesChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_Blog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "NVarChar(250)", maxLength: 250, nullable: false),
                    Konu = table.Column<string>(type: "NVarChar(250)", maxLength: 250, nullable: false),
                    Icerik = table.Column<string>(type: "NVarChar(250)", maxLength: 250, nullable: false),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Yazar = table.Column<string>(type: "NVarChar(250)", maxLength: 250, nullable: false),
                    Tarih = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Blog", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_Blog");
        }
    }
}
