using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Staff.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AverageRating = table.Column<double>(type: "float", nullable: false),
                    CountOfScores = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Country = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaffPersonPositions",
                columns: table => new
                {
                    StaffPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffPersonPositions", x => new { x.StaffPersonId, x.PositionId, x.FilmId });
                    table.ForeignKey(
                        name: "FK_StaffPersonPositions_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffPersonPositions_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffPersonPositions_Staff_StaffPersonId",
                        column: x => x.StaffPersonId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3890c596-cc11-4dd2-a020-80ec952b985e"), "Composer" },
                    { new Guid("4e24b12c-26e9-4866-9bc9-edcb88f1364a"), "Montage" },
                    { new Guid("5065f5c7-c65e-449f-9bd3-7be5858a5933"), "Artist" },
                    { new Guid("715834a7-a01b-4e04-bc90-122b59c61132"), "Actor" },
                    { new Guid("c20eb5a6-f202-4345-bbde-9520fae6ce44"), "Regisseur" },
                    { new Guid("f3fe6537-75e9-4e37-9cc8-7fb0d58c2931"), "Operator" },
                    { new Guid("f6104cff-2c90-48bf-834a-f817273541bd"), "Producer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StaffPersonPositions_FilmId",
                table: "StaffPersonPositions",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffPersonPositions_PositionId",
                table: "StaffPersonPositions",
                column: "PositionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaffPersonPositions");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Staff");
        }
    }
}
