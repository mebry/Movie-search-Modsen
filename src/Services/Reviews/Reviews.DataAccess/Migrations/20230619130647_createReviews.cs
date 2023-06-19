using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Reviews.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class createReviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Critics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Critics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypesOfReview",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfReview", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CriticId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeOfReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTimeOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Critics_CriticId",
                        column: x => x.CriticId,
                        principalTable: "Critics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_TypesOfReview_TypeOfReviewId",
                        column: x => x.TypeOfReviewId,
                        principalTable: "TypesOfReview",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TypesOfReview",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("095492e4-3f57-432b-91e1-a632cc2a13f0"), "Negative" },
                    { new Guid("10451ef2-59bd-4e80-a314-d34f679d2f0c"), "Neutral" },
                    { new Guid("9de81a67-83e0-4356-ae0f-b76e03962b00"), "Positive" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CriticId",
                table: "Reviews",
                column: "CriticId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_TypeOfReviewId",
                table: "Reviews",
                column: "TypeOfReviewId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Critics");

            migrationBuilder.DropTable(
                name: "TypesOfReview");
        }
    }
}
