using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmCollection.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseFilmInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PosterURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    AverageRating = table.Column<double>(type: "float", nullable: false),
                    NumberOfRatings = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseFilmInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Collection",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilmCountry",
                columns: table => new
                {
                    BaseFilmInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmCountry", x => new { x.CountryId, x.BaseFilmInfoId });
                    table.ForeignKey(
                        name: "FK_FilmCountry_BaseFilmInfo_BaseFilmInfoId",
                        column: x => x.BaseFilmInfoId,
                        principalTable: "BaseFilmInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmCollection",
                columns: table => new
                {
                    CollectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseFilmInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmCollection", x => new { x.CollectionId, x.BaseFilmInfoId });
                    table.ForeignKey(
                        name: "FK_FilmCollection_BaseFilmInfo_BaseFilmInfoId",
                        column: x => x.BaseFilmInfoId,
                        principalTable: "BaseFilmInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmCollection_Collection_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmGenre",
                columns: table => new
                {
                    GenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseFilmInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmGenre", x => new { x.GenreId, x.BaseFilmInfoId });
                    table.ForeignKey(
                        name: "FK_FilmGenre_BaseFilmInfo_BaseFilmInfoId",
                        column: x => x.BaseFilmInfoId,
                        principalTable: "BaseFilmInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmGenre_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseFilmInfo_AverageRating",
                table: "BaseFilmInfo",
                column: "AverageRating",
                filter: "[AverageRating] > 0");

            migrationBuilder.CreateIndex(
                name: "IX_BaseFilmInfo_NumberOfRatings",
                table: "BaseFilmInfo",
                column: "NumberOfRatings",
                filter: "[NumberOfRatings] > 0");

            migrationBuilder.CreateIndex(
                name: "IX_BaseFilmInfo_ReleaseDate",
                table: "BaseFilmInfo",
                column: "ReleaseDate");

            migrationBuilder.CreateIndex(
                name: "IX_BaseFilmInfo_Title",
                table: "BaseFilmInfo",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_FilmCollection_BaseFilmInfoId",
                table: "FilmCollection",
                column: "BaseFilmInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmCountry_BaseFilmInfoId",
                table: "FilmCountry",
                column: "BaseFilmInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmGenre_BaseFilmInfoId",
                table: "FilmGenre",
                column: "BaseFilmInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmCollection");

            migrationBuilder.DropTable(
                name: "FilmCountry");

            migrationBuilder.DropTable(
                name: "FilmGenre");

            migrationBuilder.DropTable(
                name: "Collection");

            migrationBuilder.DropTable(
                name: "BaseFilmInfo");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
