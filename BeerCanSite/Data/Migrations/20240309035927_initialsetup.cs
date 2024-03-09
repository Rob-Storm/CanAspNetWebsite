using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeerCanSite.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialsetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BeerCan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeerCanName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeerBrand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeerCanDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManufactureDate = table.Column<int>(type: "int", nullable: false),
                    TopType = table.Column<int>(type: "int", nullable: false),
                    OpenedStatus = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    ContainerSize = table.Column<int>(type: "int", nullable: false),
                    Circulated = table.Column<bool>(type: "bit", nullable: false),
                    Instructional = table.Column<bool>(type: "bit", nullable: false),
                    Images = table.Column<byte>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeerCan", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeerCan");
        }
    }
}
