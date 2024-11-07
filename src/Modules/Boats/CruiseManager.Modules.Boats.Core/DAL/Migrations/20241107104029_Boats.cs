using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CruiseManager.Modules.Boats.Core.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Boats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "boats");

            migrationBuilder.CreateTable(
                name: "ShipOwner",
                schema: "boats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipOwner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Boats",
                schema: "boats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ShipOwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Banner = table.Column<string>(type: "text", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "text", nullable: false),
                    HomePort = table.Column<string>(type: "text", nullable: false),
                    LOA = table.Column<float>(type: "real", nullable: false),
                    EngineKW = table.Column<float>(type: "real", nullable: false),
                    Cabins = table.Column<byte>(type: "smallint", nullable: false),
                    Berths = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boats_ShipOwner_ShipOwnerId",
                        column: x => x.ShipOwnerId,
                        principalSchema: "boats",
                        principalTable: "ShipOwner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accessory",
                schema: "boats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    BoatId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accessory_Boats_BoatId",
                        column: x => x.BoatId,
                        principalSchema: "boats",
                        principalTable: "Boats",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accessory_BoatId",
                schema: "boats",
                table: "Accessory",
                column: "BoatId");

            migrationBuilder.CreateIndex(
                name: "IX_Boats_ShipOwnerId",
                schema: "boats",
                table: "Boats",
                column: "ShipOwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accessory",
                schema: "boats");

            migrationBuilder.DropTable(
                name: "Boats",
                schema: "boats");

            migrationBuilder.DropTable(
                name: "ShipOwner",
                schema: "boats");
        }
    }
}
