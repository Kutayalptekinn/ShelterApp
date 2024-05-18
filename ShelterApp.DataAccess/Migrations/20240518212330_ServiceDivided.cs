using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShelterApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ServiceDivided : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_Service");

            migrationBuilder.CreateTable(
                name: "TBL_Privilege",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrivilegeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TextInPicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Privilege", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_Sector",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TextInPicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeaderText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo1 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Photo2 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Photo3 = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Sector", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_Privilege");

            migrationBuilder.DropTable(
                name: "TBL_Sector");

            migrationBuilder.CreateTable(
                name: "TBL_Service",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    HeaderText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TextInPicture = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Service", x => x.ID);
                });
        }
    }
}
