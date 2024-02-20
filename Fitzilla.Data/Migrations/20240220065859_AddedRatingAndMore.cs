using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fitzilla.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedRatingAndMore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1df2e776-8953-4a27-8860-034a1ae67574");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76b6214b-54b2-4cfe-8daf-4fec720e27a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba0762f1-c11b-4e56-b2d5-2914e1e7a0bb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de29e6b6-96ac-4352-942c-dfab0d2a7c11");

            migrationBuilder.RenameColumn(
                name: "DeactivatedAt",
                table: "Sessions",
                newName: "FinishedAt");

            migrationBuilder.AddColumn<double>(
                name: "OneRepMax",
                table: "ExerciseRecords",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "RefreshTokenExpiry",
                table: "AspNetUsers",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExerciseTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_ExerciseTemplates_ExerciseTemplateId",
                        column: x => x.ExerciseTemplateId,
                        principalTable: "ExerciseTemplates",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00e24d80-382c-4be7-8581-ee8af3125314", null, "Manager", "MANAGER" },
                    { "370dac44-2646-42a4-8e52-921ecce0be82", null, "Admin", "ADMIN" },
                    { "86b5e85b-c454-46e0-833c-25194f6574bb", null, "Consumer", "CONSUMER" },
                    { "d3e963f7-aa65-4049-8ea7-f453ef88c33d", null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_CreatorId",
                table: "Ratings",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ExerciseTemplateId",
                table: "Ratings",
                column: "ExerciseTemplateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00e24d80-382c-4be7-8581-ee8af3125314");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "370dac44-2646-42a4-8e52-921ecce0be82");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86b5e85b-c454-46e0-833c-25194f6574bb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3e963f7-aa65-4049-8ea7-f453ef88c33d");

            migrationBuilder.DropColumn(
                name: "OneRepMax",
                table: "ExerciseRecords");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiry",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "FinishedAt",
                table: "Sessions",
                newName: "DeactivatedAt");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1df2e776-8953-4a27-8860-034a1ae67574", null, "Consumer", "CONSUMER" },
                    { "76b6214b-54b2-4cfe-8daf-4fec720e27a6", null, "Manager", "MANAGER" },
                    { "ba0762f1-c11b-4e56-b2d5-2914e1e7a0bb", null, "Employee", "EMPLOYEE" },
                    { "de29e6b6-96ac-4352-942c-dfab0d2a7c11", null, "Admin", "ADMIN" }
                });
        }
    }
}
