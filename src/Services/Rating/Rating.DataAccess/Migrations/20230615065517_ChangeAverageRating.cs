using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rating.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAverageRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AverageRaiting",
                table: "Films",
                newName: "AverageRating");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AverageRating",
                table: "Films",
                newName: "AverageRaiting");
        }
    }
}
