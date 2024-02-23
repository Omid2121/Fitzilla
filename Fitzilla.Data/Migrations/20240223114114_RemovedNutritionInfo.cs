using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fitzilla.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemovedNutritionInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Macros_NutritionInfos_NutritionInfoId",
                table: "Macros");

            migrationBuilder.DropTable(
                name: "NutritionInfos");

            migrationBuilder.DropIndex(
                name: "IX_Macros_NutritionInfoId",
                table: "Macros");

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
                name: "NutritionInfoId",
                table: "Macros");

            migrationBuilder.AddColumn<double>(
                name: "Calorie",
                table: "Macros",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CarbohydrateAmount",
                table: "Macros",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "CarbohydratePercentage",
                table: "Macros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "FatAmount",
                table: "Macros",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "FatPercentage",
                table: "Macros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "ProteinAmount",
                table: "Macros",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ProteinPercentage",
                table: "Macros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f6c8c1c-becc-45b6-aff8-922cc2c66633", null, "Manager", "MANAGER" },
                    { "122d7164-7274-480b-b5b7-477ebed0164f", null, "Admin", "ADMIN" },
                    { "5eedee9d-be6c-4ec1-8bfd-0ad4919bbc08", null, "Employee", "EMPLOYEE" },
                    { "f846c593-0bb1-4275-8cbd-32cbf499b6f7", null, "Consumer", "CONSUMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6c8c1c-becc-45b6-aff8-922cc2c66633");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "122d7164-7274-480b-b5b7-477ebed0164f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5eedee9d-be6c-4ec1-8bfd-0ad4919bbc08");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f846c593-0bb1-4275-8cbd-32cbf499b6f7");

            migrationBuilder.DropColumn(
                name: "Calorie",
                table: "Macros");

            migrationBuilder.DropColumn(
                name: "CarbohydrateAmount",
                table: "Macros");

            migrationBuilder.DropColumn(
                name: "CarbohydratePercentage",
                table: "Macros");

            migrationBuilder.DropColumn(
                name: "FatAmount",
                table: "Macros");

            migrationBuilder.DropColumn(
                name: "FatPercentage",
                table: "Macros");

            migrationBuilder.DropColumn(
                name: "ProteinAmount",
                table: "Macros");

            migrationBuilder.DropColumn(
                name: "ProteinPercentage",
                table: "Macros");

            migrationBuilder.AddColumn<Guid>(
                name: "NutritionInfoId",
                table: "Macros",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "NutritionInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Calorie = table.Column<double>(type: "float", nullable: false),
                    CarbohydrateAmount = table.Column<double>(type: "float", nullable: false),
                    CarbohydratePercentage = table.Column<int>(type: "int", nullable: false),
                    FatAmount = table.Column<double>(type: "float", nullable: false),
                    FatPercentage = table.Column<int>(type: "int", nullable: false),
                    MacroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProteinAmount = table.Column<double>(type: "float", nullable: false),
                    ProteinPercentage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionInfos", x => x.Id);
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
                name: "IX_Macros_NutritionInfoId",
                table: "Macros",
                column: "NutritionInfoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Macros_NutritionInfos_NutritionInfoId",
                table: "Macros",
                column: "NutritionInfoId",
                principalTable: "NutritionInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
