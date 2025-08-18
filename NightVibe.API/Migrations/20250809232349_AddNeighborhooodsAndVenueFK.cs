using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NightVibe.API.Migrations
{
    /// <inheritdoc />
    public partial class AddNeighborhooodsAndVenueFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NeighborhoodId",
                table: "Venues",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Neighborhoods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Neighborhoods", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Venues_NeighborhoodId",
                table: "Venues",
                column: "NeighborhoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Venues_Neighborhoods_NeighborhoodId",
                table: "Venues",
                column: "NeighborhoodId",
                principalTable: "Neighborhoods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venues_Neighborhoods_NeighborhoodId",
                table: "Venues");

            migrationBuilder.DropTable(
                name: "Neighborhoods");

            migrationBuilder.DropIndex(
                name: "IX_Venues_NeighborhoodId",
                table: "Venues");

            migrationBuilder.DropColumn(
                name: "NeighborhoodId",
                table: "Venues");
        }
    }
}
