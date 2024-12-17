using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Artist.Migrations
{
    /// <inheritdoc />
    public partial class AddFavoriteArtistTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavoriteArtists",
                columns: table => new
                {
                    FavoriteArtistID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistID = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteArtists", x => x.FavoriteArtistID);
                    table.ForeignKey(
                        name: "FK_FavoriteArtists_Artists_ArtistID",
                        column: x => x.ArtistID,
                        principalTable: "Artists",
                        principalColumn: "ArtistID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteArtists_ArtistID",
                table: "FavoriteArtists",
                column: "ArtistID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteArtists");
        }
    }
}
