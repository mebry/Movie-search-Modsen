using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmCollection.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseFilmInfos",
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
                    table.PrimaryKey("PK_BaseFilmInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CollectionModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilmCountries",
                columns: table => new
                {
                    BaseFilmInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmCountries", x => new { x.CountryId, x.BaseFilmInfoId });
                    table.ForeignKey(
                        name: "FK_FilmCountries_BaseFilmInfos_BaseFilmInfoId",
                        column: x => x.BaseFilmInfoId,
                        principalTable: "BaseFilmInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmCollections",
                columns: table => new
                {
                    CollectionModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseFilmInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmCollections", x => new { x.CollectionModelId, x.BaseFilmInfoId });
                    table.ForeignKey(
                        name: "FK_FilmCollections_BaseFilmInfos_BaseFilmInfoId",
                        column: x => x.BaseFilmInfoId,
                        principalTable: "BaseFilmInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmCollections_CollectionModels_CollectionModelId",
                        column: x => x.CollectionModelId,
                        principalTable: "CollectionModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmGenres",
                columns: table => new
                {
                    GenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseFilmInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmGenres", x => new { x.GenreId, x.BaseFilmInfoId });
                    table.ForeignKey(
                        name: "FK_FilmGenres_BaseFilmInfos_BaseFilmInfoId",
                        column: x => x.BaseFilmInfoId,
                        principalTable: "BaseFilmInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseFilmInfos_AverageRating",
                table: "BaseFilmInfos",
                column: "AverageRating",
                filter: "[AverageRating] > 0");

            migrationBuilder.CreateIndex(
                name: "IX_BaseFilmInfos_NumberOfRatings",
                table: "BaseFilmInfos",
                column: "NumberOfRatings",
                filter: "[NumberOfRatings] > 0");

            migrationBuilder.CreateIndex(
                name: "IX_BaseFilmInfos_ReleaseDate",
                table: "BaseFilmInfos",
                column: "ReleaseDate");

            migrationBuilder.CreateIndex(
                name: "IX_BaseFilmInfos_Title",
                table: "BaseFilmInfos",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_FilmCollections_BaseFilmInfoId",
                table: "FilmCollections",
                column: "BaseFilmInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmCountries_BaseFilmInfoId",
                table: "FilmCountries",
                column: "BaseFilmInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmGenres_BaseFilmInfoId",
                table: "FilmGenres",
                column: "BaseFilmInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmCollections");

            migrationBuilder.DropTable(
                name: "FilmCountries");

            migrationBuilder.DropTable(
                name: "FilmGenres");

            migrationBuilder.DropTable(
                name: "CollectionModels");

            migrationBuilder.DropTable(
                name: "BaseFilmInfos");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
