using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmCollection.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class newFeatures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmCollection_BaseFilmInfo_BaseFilmInfoId",
                table: "FilmCollection");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmCollection_Collection_CollectionId",
                table: "FilmCollection");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmCountry_BaseFilmInfo_BaseFilmInfoId",
                table: "FilmCountry");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmGenre_BaseFilmInfo_BaseFilmInfoId",
                table: "FilmGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmGenre_Genre_GenreId",
                table: "FilmGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genre",
                table: "Genre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmGenre",
                table: "FilmGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmCountry",
                table: "FilmCountry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmCollection",
                table: "FilmCollection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Collection",
                table: "Collection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseFilmInfo",
                table: "BaseFilmInfo");

            migrationBuilder.RenameTable(
                name: "Genre",
                newName: "Genres");

            migrationBuilder.RenameTable(
                name: "FilmGenre",
                newName: "FilmGenres");

            migrationBuilder.RenameTable(
                name: "FilmCountry",
                newName: "FilmCountries");

            migrationBuilder.RenameTable(
                name: "FilmCollection",
                newName: "filmCollections");

            migrationBuilder.RenameTable(
                name: "Collection",
                newName: "Collections");

            migrationBuilder.RenameTable(
                name: "BaseFilmInfo",
                newName: "BaseFilmInfos");

            migrationBuilder.RenameIndex(
                name: "IX_FilmGenre_BaseFilmInfoId",
                table: "FilmGenres",
                newName: "IX_FilmGenres_BaseFilmInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_FilmCountry_BaseFilmInfoId",
                table: "FilmCountries",
                newName: "IX_FilmCountries_BaseFilmInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_FilmCollection_BaseFilmInfoId",
                table: "filmCollections",
                newName: "IX_filmCollections_BaseFilmInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseFilmInfo_Title",
                table: "BaseFilmInfos",
                newName: "IX_BaseFilmInfos_Title");

            migrationBuilder.RenameIndex(
                name: "IX_BaseFilmInfo_ReleaseDate",
                table: "BaseFilmInfos",
                newName: "IX_BaseFilmInfos_ReleaseDate");

            migrationBuilder.RenameIndex(
                name: "IX_BaseFilmInfo_NumberOfRatings",
                table: "BaseFilmInfos",
                newName: "IX_BaseFilmInfos_NumberOfRatings");

            migrationBuilder.RenameIndex(
                name: "IX_BaseFilmInfo_AverageRating",
                table: "BaseFilmInfos",
                newName: "IX_BaseFilmInfos_AverageRating");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmGenres",
                table: "FilmGenres",
                columns: new[] { "GenreId", "BaseFilmInfoId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmCountries",
                table: "FilmCountries",
                columns: new[] { "CountryId", "BaseFilmInfoId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_filmCollections",
                table: "filmCollections",
                columns: new[] { "CollectionId", "BaseFilmInfoId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Collections",
                table: "Collections",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseFilmInfos",
                table: "BaseFilmInfos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_filmCollections_BaseFilmInfos_BaseFilmInfoId",
                table: "filmCollections",
                column: "BaseFilmInfoId",
                principalTable: "BaseFilmInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_filmCollections_Collections_CollectionId",
                table: "filmCollections",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmCountries_BaseFilmInfos_BaseFilmInfoId",
                table: "FilmCountries",
                column: "BaseFilmInfoId",
                principalTable: "BaseFilmInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmGenres_BaseFilmInfos_BaseFilmInfoId",
                table: "FilmGenres",
                column: "BaseFilmInfoId",
                principalTable: "BaseFilmInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmGenres_Genres_GenreId",
                table: "FilmGenres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_filmCollections_BaseFilmInfos_BaseFilmInfoId",
                table: "filmCollections");

            migrationBuilder.DropForeignKey(
                name: "FK_filmCollections_Collections_CollectionId",
                table: "filmCollections");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmCountries_BaseFilmInfos_BaseFilmInfoId",
                table: "FilmCountries");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmGenres_BaseFilmInfos_BaseFilmInfoId",
                table: "FilmGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmGenres_Genres_GenreId",
                table: "FilmGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmGenres",
                table: "FilmGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmCountries",
                table: "FilmCountries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_filmCollections",
                table: "filmCollections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Collections",
                table: "Collections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseFilmInfos",
                table: "BaseFilmInfos");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "Genre");

            migrationBuilder.RenameTable(
                name: "FilmGenres",
                newName: "FilmGenre");

            migrationBuilder.RenameTable(
                name: "FilmCountries",
                newName: "FilmCountry");

            migrationBuilder.RenameTable(
                name: "filmCollections",
                newName: "FilmCollection");

            migrationBuilder.RenameTable(
                name: "Collections",
                newName: "Collection");

            migrationBuilder.RenameTable(
                name: "BaseFilmInfos",
                newName: "BaseFilmInfo");

            migrationBuilder.RenameIndex(
                name: "IX_FilmGenres_BaseFilmInfoId",
                table: "FilmGenre",
                newName: "IX_FilmGenre_BaseFilmInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_FilmCountries_BaseFilmInfoId",
                table: "FilmCountry",
                newName: "IX_FilmCountry_BaseFilmInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_filmCollections_BaseFilmInfoId",
                table: "FilmCollection",
                newName: "IX_FilmCollection_BaseFilmInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseFilmInfos_Title",
                table: "BaseFilmInfo",
                newName: "IX_BaseFilmInfo_Title");

            migrationBuilder.RenameIndex(
                name: "IX_BaseFilmInfos_ReleaseDate",
                table: "BaseFilmInfo",
                newName: "IX_BaseFilmInfo_ReleaseDate");

            migrationBuilder.RenameIndex(
                name: "IX_BaseFilmInfos_NumberOfRatings",
                table: "BaseFilmInfo",
                newName: "IX_BaseFilmInfo_NumberOfRatings");

            migrationBuilder.RenameIndex(
                name: "IX_BaseFilmInfos_AverageRating",
                table: "BaseFilmInfo",
                newName: "IX_BaseFilmInfo_AverageRating");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genre",
                table: "Genre",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmGenre",
                table: "FilmGenre",
                columns: new[] { "GenreId", "BaseFilmInfoId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmCountry",
                table: "FilmCountry",
                columns: new[] { "CountryId", "BaseFilmInfoId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmCollection",
                table: "FilmCollection",
                columns: new[] { "CollectionId", "BaseFilmInfoId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Collection",
                table: "Collection",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseFilmInfo",
                table: "BaseFilmInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmCollection_BaseFilmInfo_BaseFilmInfoId",
                table: "FilmCollection",
                column: "BaseFilmInfoId",
                principalTable: "BaseFilmInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmCollection_Collection_CollectionId",
                table: "FilmCollection",
                column: "CollectionId",
                principalTable: "Collection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmCountry_BaseFilmInfo_BaseFilmInfoId",
                table: "FilmCountry",
                column: "BaseFilmInfoId",
                principalTable: "BaseFilmInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmGenre_BaseFilmInfo_BaseFilmInfoId",
                table: "FilmGenre",
                column: "BaseFilmInfoId",
                principalTable: "BaseFilmInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmGenre_Genre_GenreId",
                table: "FilmGenre",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
