using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitzilla.DAL.Migrations
{
    public partial class InitalCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Measurement = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseTemplates_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Macro",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ConsumeType = table.Column<int>(type: "int", nullable: false),
                    Intensity = table.Column<int>(type: "int", nullable: false),
                    Calorie = table.Column<double>(type: "float", nullable: false),
                    Protein = table.Column<double>(type: "float", nullable: false),
                    Carbohydrate = table.Column<double>(type: "float", nullable: false),
                    Fat = table.Column<double>(type: "float", nullable: false),
                    CreationTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Macro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Macro_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetMuscle = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workouts_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Set = table.Column<int>(type: "int", nullable: false),
                    Rep = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    CreationTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WorkoutId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exercises_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c54f3ae2-a005-4733-9f33-bee73901d8a5", "fd94722d-4db3-43e2-990b-fcf980b247ef", "Consumer", "CONSUMER" },
                    { "d4c923cc-920e-4cb4-9128-eb22e31421d8", "a234b20c-bdd6-49da-afd0-41c980470366", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "ExerciseTemplates",
                columns: new[] { "Id", "CreationTime", "CreatorId", "Description", "Image", "LastModifiedTime", "Name" },
                values: new object[,]
                {
                    { new Guid("02b60324-4a5d-4fa2-9862-9e42158b6b95"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The pullup shrug is a bodyweight exercise that primarily targets the traps and to a lesser degree also targets the abs, biceps, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, neck, obliques, outer thighs, quads, shoulders and triceps. The only pullup shrug equipment that you really need is the following: pull-up bar.", "traps.png", null, "Pullup Shrug" },
                    { new Guid("02dee82d-e59e-4601-89b2-9fa85558af72"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The deadlift is a free weights exercise that primarily targets the lower back and to a lesser degree also targets the abs, glutes, hamstrings and quads. The only deadlift equipment that you really need is the following: barbell.", "lat_pulldown.png", null, "Deadlift" },
                    { new Guid("05200579-3f73-40e7-876e-64c347eca912"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The prone dumbbell spider curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only prone dumbbell spider curl equipment that you really need is the following: dumbbells and incline bench.", "biceps.png", null, "Prone Dumbbell Spider Curl" },
                    { new Guid("07cf84a5-a5af-44f4-a8f1-0f243d5be72b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The single-arm t-bar rows is a free weights exercise that primarily targets the middle back and to a lesser degree also targets the biceps, lats, lower back, shoulders and traps. The only single-arm t-bar rows equipment that you really need is the following: t-bar row machine and v-handle attachment.", "lat_pulldown.png", null, "Single-arm T-Bar Rows" },
                    { new Guid("07f83e35-8b65-43c7-89ce-ea58cdfaf533"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The face pull is a free weights exercise that primarily targets the traps and to a lesser degree also targets the abs, biceps, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, neck, obliques, outer thighs, quads, shoulders and triceps. The only face pull equipment that you really need is the following: cable machine.", "traps.png", null, "Face Pull" },
                    { new Guid("0a81e6d2-8cee-4713-8578-03f38c211f92"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The lying leg curl is a exercise machine exercise that primarily targets the hamstrings and to a lesser degree also targets the calves, glutes and lower back. The only lying leg curl equipment that you really need is the following: leg curl machine.", "hamstrings.png", null, "Lying Leg Curl" },
                    { new Guid("0c05c7f1-2306-4e73-9c3e-314cd915b3c4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The hack squat is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only hack squat equipment that you really need is the following: hack squat machine.", "quads.png", null, "Hack Squat" },
                    { new Guid("105dabfc-7d72-4583-aa7f-706356249957"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The single-leg romanian deadlift is a free weights exercise that primarily targets the hamstrings and to a lesser degree also targets the calves, glutes and lower back. The only single-leg romanian deadlift equipment that you really need is the following: dumbbells.", "hamstrings.png", null, "Single-leg Romanian Deadlift" },
                    { new Guid("12f3e77d-83a3-4614-a01a-c5c1e63b6255"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The dumbbell bent-over lateral raise is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the abs, forearms, traps and triceps. The only dumbbell bent-over lateral raise equipment that you really need is the following: dumbbells.", "shoulders.png", null, "Dumbbell Bent-Over Lateral Raise" },
                    { new Guid("14b0dcc2-78ab-4708-96b5-c201b1006c7f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The concentration curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only concentration curl equipment that you really need is the following: dumbbell.", "biceps.png", null, "Concentration Curl" },
                    { new Guid("17d23673-d337-47bb-bb57-a2c079b8a45d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The trap raise is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the abs, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, quads and triceps. The only trap raise equipment that you really need is the following: dumbbells.", "shoulders.png", null, "Trap Raise" },
                    { new Guid("1847fd57-d819-47a0-823f-669db6b66029"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The seated calf raise machine is a exercise machine exercise that primarily targets the calves and to a lesser degree also targets the abs, glutes and hamstrings. The only seated calf raise machine equipment that you really need is the following: calf raise machine.", "calves.png", null, "Seated Calf Raise Machine" },
                    { new Guid("1a6cd36d-dc8d-4e39-8494-1ccacb24d54a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The chest-supported dumbbell row is a free weights exercise that primarily targets the middle back and to a lesser degree also targets the biceps, lats, lower back, shoulders and traps. The only chest-supported dumbbell row equipment that you really need is the following: dumbbells and flat bench.", "lat_pulldown.png", null, "Chest-supported Dumbbell Row" },
                    { new Guid("1c1f08c6-ac67-4854-8a66-4a7c136ea5d9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The dumbbell raise complex is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the abs, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, quads and triceps. The only dumbbell raise complex equipment that you really need is the following: dumbbells.", "shoulders.png", null, "Dumbbell Raise Complex" },
                    { new Guid("1d877e89-770a-4068-b4c5-ca624e65b4e5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The seated dumbbell clean is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the abs, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, quads, traps and triceps. The only seated dumbbell clean equipment that you really need is the following: dumbbells and flat bench.", "shoulders.png", null, "Seated Dumbbell Clean" },
                    { new Guid("1f0b68a6-e8e3-4430-b7dc-68f549b84bdd"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The goblet squat is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and lower back. The only goblet squat equipment that you really need is the following: dumbbell.", "quads.png", null, "Goblet Squat" },
                    { new Guid("2039d281-249a-4698-afee-ff0ecf454495"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The bulgarian split squat is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only bulgarian split squat equipment that you really need is the following: dumbbells and bench.", "quads.png", null, "Bulgarian Split Squat" },
                    { new Guid("20a1e9b2-e677-4436-8cba-161ebfa55ec9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The decline dumbbell fly or decline dumbbell flye is a strength training exercise similar in movement to the decline dumbbell fly. It involves squeezing the arms together in front of the body. The difference is, in the decline dumbbell fly, the force is perpendicular to the body, while in the decline dumbbell fly the force is horizontal to the body.", "bench_press.png", null, "Decline Dumbbell Press Fly" },
                    { new Guid("2208a0e0-e047-4390-b74e-ddd30354f562"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The incline dumbbell fly or incline dumbbell flye is a strength training exercise similar in movement to the incline dumbbell fly. It involves squeezing the arms together in front of the body. The difference is, in the incline dumbbell fly, the force is perpendicular to the body, while in the incline dumbbell fly the force is horizontal to the body.", "bench_press.png", null, "Incline Dumbbell Press Fly" },
                    { new Guid("22ff4dfc-6fcc-4046-8e54-a09ba7ea5e7e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The one-arm overhead extension is a free weights exercise that primarily targets the triceps and to a lesser degree also targets the chest and shoulders. The only one-arm overhead extension equipment that you really need is the following: dumbbell.", "triceps.png", null, "One-Arm Overhead Extension" },
                    { new Guid("27b4838e-c345-4260-a73f-89c84b153281"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The clean and press is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the abs, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, quads and triceps. The only clean and press equipment that you really need is the following: barbell.", "shoulders.png", null, "Clean and Press" },
                    { new Guid("28613fdc-9c6e-4dbb-b73b-b206ef0d04e3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The cable or band pull-through is a exercise machine and alternative exercise that primarily targets the hamstrings and to a lesser degree also targets the calves, glutes and lower back.", "hamstrings.png", null, "Cable or Band Pull-through" },
                    { new Guid("289827e4-1710-480f-8ce0-4278cb0b39be"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The seated single-leg jump squat is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only seated single-leg jump squat equipment that you really need is the following: box.", "quads.png", null, "Seated Single-Leg Jump Squat" },
                    { new Guid("2b1136e2-d9d6-44df-864f-7af0bd669e8d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The dumbbell pull-over is a free weights exercise that primarily targets the lats and to a lesser degree also targets the chest, forearms, lower back, middle back, shoulders and triceps. The only dumbbell pull-over equipment that you really need is the following: dumbbell.", "lat_pulldown.png", null, "Dumbbell Pull-Over" },
                    { new Guid("2b503966-3343-4108-a628-252292384a15"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The grounded russian twist is a exercise machine and pilates exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and lower back. The only grounded russian twist equipment that you really need is the following: exercise ball.", "abs.png", null, "Grounded Russian twist" },
                    { new Guid("2ba10e6d-d902-4344-b50f-284385a82fcf"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The front raise is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the abs, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, quads and triceps. The only front raise equipment that you really need is the following: dumbbells.", "shoulders.png", null, "Front Raise" },
                    { new Guid("2bf1ac2a-08bd-4f45-8287-bc54276f5114"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The weighted jump squat is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only weighted jump squat equipment that you really need is the following: dumbbells.", "quads.png", null, "Weighted Jump Squat" },
                    { new Guid("2c3753ba-628f-457e-a937-c2627c12290e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The shoulder blade squeeze is a bodyweight exercise that primarily targets the traps and to a lesser degree also targets the abs, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, neck, obliques, outer thighs, quads, shoulders and triceps. The only shoulder blade squeeze equipment that you really need is the following: exercise mat.", "traps.png", null, "Shoulder blade squeeze" },
                    { new Guid("2cb65596-7ad8-45da-aff1-b8079d11d483"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The ez bar curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only ez bar curl equipment that you really need is the following: ez curl bar.", "biceps.png", null, "EZ Bar Curl" },
                    { new Guid("2ccc4b7b-04c8-4a8b-a366-ad4cdc685ec6"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The barbell behind-the-back shrug is a free weights exercise that primarily targets the traps and to a lesser degree also targets the abs, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, neck, obliques, outer thighs, quads, shoulders and triceps. The only barbell behind-the-back shrug equipment that you really need is the following: barbell.", "traps.png", null, "Barbell Behind-the-Back Shrug" },
                    { new Guid("2d8aa085-ae6e-4a26-85f2-8753017dff2a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The hip thrust is a free weights exercise that primarily targets the hamstrings and to a lesser degree also targets the calves, glutes and lower back. The only hip thrust equipment that you really need is the following: barbell.", "hamstrings.png", null, "Hip Thrust" },
                    { new Guid("328ae531-1817-49e2-a1fd-5f1fb7dad4ea"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The zottman curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only zottman curl equipment that you really need is the following: dumbbells.", "biceps.png", null, "Zottman Curl" },
                    { new Guid("32a60fdd-f11f-4be2-bc9e-d814d80b0916"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The dip is a strength training exercise used to develop strength and size in triceps. Dips are an advanced bodyweight exercise that is primarily used to develop the triceps muscles. It is also a compound exercise that also involves the chest and shoulders, making it a great exercise for developing overall upper body strength.", "bench_press.png", null, "Dips" },
                    { new Guid("32ca1649-43dc-41f0-b2be-1c7ff1d79d7c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The incline machine press is a machine-based exercise targeting the chest. It is similar to the incline barbell press, but it is performed using a machine. The machine press is a great exercise for beginners to learn the basic movement pattern of the incline press.", "bench_press.png", null, "Incline Machine Press" },
                    { new Guid("32e1ffc9-a042-4ae3-956d-62e2af7792c1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The decline bench press is an exercise which helps you get the complete chest development. It recruits more of the inner pecs, i.e. the sternocostal head of the pectoralis major muscle. It is performed in a very similar manner to the flat bench press, the only difference is that the bench is set to a decline position of 15 to 30 degrees.", "bench_press.png", null, "Decline Bench Press" },
                    { new Guid("36875d3a-0822-4f0e-a28e-6374bcf3e535"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The incline cable fly or incline cable flye is a strength training exercise similar in movement to the incline dumbbell fly. It involves squeezing the arms together in front of the body. The difference is, in the incline dumbbell fly, the force is perpendicular to the body, while in the incline cable fly the force is horizontal to the body.", "bench_press.png", null, "Incline Cable Press Fly" },
                    { new Guid("36a2989d-3f7c-4f10-b074-df85907ea86c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The high pull is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the biceps, calves, forearms, hamstrings, lats, lower back, middle back, quads, traps and triceps. The only high pull equipment that you really need is the following: barbell.", "shoulders.png", null, "High Pull" },
                    { new Guid("3a3727d8-42b2-4328-a88d-ebe6cd873f9d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The pull-up is a bodyweight exercise that primarily targets the lats and to a lesser degree also targets the abs, biceps, forearms, lower back, middle back, shoulders and traps. The only pull-up equipment that you really need is the following: pull-up bar.", "lat_pulldown.png", null, "Pull-Up" },
                    { new Guid("3e38d6e9-5acb-4779-b20a-271a36e98b6e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The decline machine press is a machine-based exercise targeting the chest. It is similar to the decline barbell press, but it is performed using a machine. The machine press is a great exercise for beginners to learn the basic movement pattern of the decline press.", "bench_press.png", null, "Decline Machine Press" },
                    { new Guid("429eb45c-f218-4b28-a596-9c630dd86021"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The single-arm cable kick-back is a strength training exercise that primarily targets the triceps and to a lesser degree also targets the shoulders and forearms. The only single-arm cable kick-back equipment that you really need is the following: cable machine.", "triceps.png", null, "Single-Arm Cable Kick-Back" }
                });

            migrationBuilder.InsertData(
                table: "ExerciseTemplates",
                columns: new[] { "Id", "CreationTime", "CreatorId", "Description", "Image", "LastModifiedTime", "Name" },
                values: new object[,]
                {
                    { new Guid("4365981f-b8c0-4853-bd1b-6ce2d9806a39"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The snatch-grip high pull is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the biceps, calves, forearms, hamstrings, lats, lower back, middle back, quads, traps and triceps. The only snatch-grip high pull equipment that you really need is the following: barbell.", "shoulders.png", null, "Snatch-Grip High Pull" },
                    { new Guid("4455d4ed-3f12-4247-9c69-3b39d2412368"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The decline cable fly or decline cable flye is a strength training exercise similar in movement to the decline dumbbell fly. It involves squeezing the arms together in front of the body. The difference is, in the decline dumbbell fly, the force is perpendicular to the body, while in the decline cable fly the force is horizontal to the body.", "bench_press.png", null, "Decline Cable Press Fly" },
                    { new Guid("44708953-676e-4002-8590-1a7fda399450"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The barbell shrug is a free weights exercise that primarily targets the traps and to a lesser degree also targets the abs, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, neck, obliques, outer thighs, quads, shoulders and triceps. The only barbell shrug equipment that you really need is the following: barbell.", "traps.png", null, "Barbell Shrug" },
                    { new Guid("455cfa97-377a-48bb-a41a-16879d5e6662"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The barbell bent-over row is a free weights exercise that primarily targets the middle back and to a lesser degree also targets the biceps, lats, lower back, shoulders and traps. The only barbell bent-over row equipment that you really need is the following: barbell.", "lat_pulldown.png", null, "Barbell Bent-Over Row" },
                    { new Guid("490a4fa7-14c6-4ea7-83e0-9828a3e96ae4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The cable rope tricep pushdown is a strength training exercise that primarily targets the triceps and to a lesser degree also targets the chest and shoulders. The only cable rope tricep pushdown equipment that you really need is the following: cable machine and rope attachment.", "triceps.png", null, "Cable Rope Tricep Pushdown" },
                    { new Guid("493ed4bf-7316-4350-8a73-7c887ab624d7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The bird-dog is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and lower back. The only bird-dog equipment that you really need is the following: exercise mat.", "abs.png", null, "Bird-dog" },
                    { new Guid("49869f74-db51-4e74-8918-9d4835e9bf77"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The walking lunge is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only walking lunge equipment that you really need is the following: dumbbells.", "quads.png", null, "Walking Lunge" },
                    { new Guid("4f71959f-dc0f-4d84-95fb-152e4e73ca1e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The back extension is a exercise machine exercise that primarily targets the lower back and to a lesser degree also targets the abs, glutes and hamstrings. The only back extension equipment that you really need is the following: hyperextension machine.", "hamstrings.png", null, "Back Extension" },
                    { new Guid("4fe9451d-3663-40c5-9dd7-6db9c20951fa"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The leant-forward ez bar curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only leant-forward ez bar curl equipment that you really need is the following: ez curl bar.", "biceps.png", null, "Leant-Forward EZ Bar Curl" },
                    { new Guid("502e9f73-2b75-4e7d-a766-6b3af8e3fd70"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The walking lunges is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only walking lunges equipment that you really need is the following: dumbbells.", "hamstrings.png", null, "Walking Lunges" },
                    { new Guid("549ca9bb-c581-47e7-b749-d7970fe62ee2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The incline dumbbell shrug is a free weights exercise that primarily targets the traps and to a lesser degree also targets the abs, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, neck, obliques, outer thighs, quads, shoulders and triceps. The only incline dumbbell shrug equipment that you really need is the following: dumbbells and incline bench.", "traps.png", null, "Incline Dumbbell Shrug" },
                    { new Guid("57c2dcea-9976-47b0-b877-c8e26b06eebf"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The pushup is a bodyweight exercise that primarily targets the chest and to a lesser degree also targets the abs, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, neck, outer thighs, quads, shoulders and triceps. The only pushup equipment that you really need is the following: exercise mat.", "traps.png", null, "Pushup" },
                    { new Guid("58590702-d52b-4a53-8d6e-f299f30b3f03"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The bicycle crunch is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and lower back. The only bicycle crunch equipment that you really need is the following: exercise mat.", "abs.png", null, "Bicycle Crunch" },
                    { new Guid("59a53eb5-3c3c-4d3c-a07d-78385fdca6d1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The mountain climber is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the calves, chest, forearms, glutes, hamstrings, hip flexors, lower back, middle back, quads, shoulders and traps. The only mountain climber equipment that you really need is the following: exercise mat.", "abs.png", null, "Mountain climber" },
                    { new Guid("5ca0b291-ff1b-4565-9f24-d9ad00d90d74"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The reverse curl straight bar is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only reverse curl straight bar equipment that you really need is the following: barbell.", "biceps.png", null, "Reverse Curl Straight Bar" },
                    { new Guid("5cd50e3b-38f5-4158-923f-fe1e93d3bc23"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The dumbbell woodchop is a free weights exercise that primarily targets the abs and to a lesser degree also targets the chest, forearms, glutes, hamstrings, hip flexors, lower back, middle back, obliques, quads, shoulders and traps. The only dumbbell woodchop equipment that you really need is the following: dumbbells.", "abs.png", null, "Dumbbell woodchop" },
                    { new Guid("5e774126-93e4-4bd7-beae-2dfa1a35c89f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The reverse pec deck fly is a exercise machine exercise that primarily targets the shoulders and to a lesser degree also targets the abs, forearms, traps and triceps. The only reverse pec deck fly equipment that you really need is the following: pec deck machine.", "shoulders.png", null, "Reverse Pec Deck Fly" },
                    { new Guid("5faca2e4-b8b4-4c67-8cd9-4740fb59aabb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The plank is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the chest, forearms, glutes, hamstrings, lower back, middle back, shoulders and traps. The only plank equipment that you really need is the following: exercise mat.", "abs.png", null, "Plank" },
                    { new Guid("5ffbb1fb-1b59-406a-b4c5-52e70f7b5784"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The seated alternating dumbbell curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only seated alternating dumbbell curl equipment that you really need is the following: dumbbells and flat bench.", "biceps.png", null, "Seated Alternating Dumbbell Curl" },
                    { new Guid("650a03a5-dbc2-487c-868e-ba31f6b811b8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The hill runs is a cardiovascular and calisthenics exercise that primarily targets the calves and to a lesser degree also targets the abs, glutes, hamstrings, hip flexors, lower back, quads and traps.", "calves.png", null, "Hill Runs" },
                    { new Guid("659a9c7d-3505-4fae-84a3-f14a3878acd8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The sprints is a cardio exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only sprints equipment that you really need is the following: track.", "quads.png", null, "Sprints" },
                    { new Guid("67bc1eaa-43db-402c-a9d4-e2dbf5ba8a88"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The machine press is a machine-based exercise targeting the chest. It is similar to the barbell bench press, but it is performed using a machine. The machine press is a great exercise for beginners to learn the basic movement pattern of the bench press.", "bench_press.png", null, "Machine Press" },
                    { new Guid("684fbecf-358d-492e-85be-48a55ed86c3f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The deadlift is a free weights exercise that primarily targets the hamstrings and to a lesser degree also targets the calves, glutes, lower back and quads. The only deadlift equipment that you really need is the following: barbell.", "quads.png", null, "Deadlift" },
                    { new Guid("6aafc88b-86d0-43a5-87ed-ac402718879a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The reverse crunch is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and lower back. The only reverse crunch equipment that you really need is the following: exercise mat.", "abs.png", null, "Reverse crunch" },
                    { new Guid("6b0d4643-d831-4fd8-bd06-c7aca5ea5cd4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The decline dumbbell bench press is a free weights exercise that primarily targets the chest and to a lesser degree also targets the shoulders and triceps. The only decline dumbbell bench press equipment that you really need is the following: dumbbells and decline bench.", "bench_press.png", null, "Decline Dumbbell Press" },
                    { new Guid("6d000af9-5dbc-46ca-8365-fb461a90f90e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The cable fly or cable flye is a strength training exercise similar in movement to the pec deck. It involves squeezing the arms together in front of the body. The difference is, in the pec deck, the force is perpendicular to the body, while in the cable fly the force is horizontal to the body.", "bench_press.png", null, "Cable Press Fly" },
                    { new Guid("72f03b37-1331-424c-9d07-736625c862cf"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The hanging knee raise twist is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and obliques. The only hanging knee raise twist equipment that you really need is the following: pull-up bar.", "abs.png", null, "Hanging knee raise twist" },
                    { new Guid("7380ecf4-80e9-48ef-ab1b-576490fdc2a3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The incline bench press is an upper body strength training exercise that consists of pressing a weight at an angle, similar to but less than one hundred and eighty degrees, to the body. This angle is between 45 and 60 degrees, lower than that of a standard bench press.", "bench_press.png", null, "Incline Bench Press" },
                    { new Guid("752348ab-5040-44f2-9c7f-53ee73abc8ef"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The barbell romanian deadlift is a free weights exercise that primarily targets the hamstrings and to a lesser degree also targets the calves, glutes and lower back. The only barbell romanian deadlift equipment that you really need is the following: barbell.", "hamstrings.png", null, "Barbell Romanian Deadlift" },
                    { new Guid("784a87b2-867e-45a8-b5e1-e19ee7b3addc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The v-sit is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and lower back. The only v-sit equipment that you really need is the following: exercise mat.", "abs.png", null, "V-sit" },
                    { new Guid("784b37e9-1d73-4b5c-87b3-30a5022d6e6f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The stairmaster is a exercise machine exercise that primarily targets the calves and to a lesser degree also targets the abs, glutes, hamstrings and quads. The only stairmaster equipment that you really need is the following: stairmaster.", "calves.png", null, "StairMaster" },
                    { new Guid("790d714b-b4ff-466d-a5cc-921fb9db49bd"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The glute bridge is a free weights exercise that primarily targets the hamstrings and to a lesser degree also targets the calves, glutes and lower back. The only glute bridge equipment that you really need is the following: dumbbells.", "hamstrings.png", null, "Glute Bridge" },
                    { new Guid("7ac5cb23-fb21-45de-bf0b-9f190cf4bca0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The seated calf raise is a exercise machine exercise that primarily targets the calves and to a lesser degree also targets the abs, glutes and hamstrings. The only seated calf raise equipment that you really need is the following: calf raise machine.", "calves.png", null, "Seated calf raise" },
                    { new Guid("8042df64-aa34-407e-8ae3-247703e6ca98"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The seated calf raise is a exercise machine exercise that primarily targets the calves and to a lesser degree also targets the abs, glutes and hamstrings. The only seated calf raise equipment that you really need is the following: calf raise machine.", "calves.png", null, "Seated Calf Raise" },
                    { new Guid("82f657a0-dc5e-4662-9c0d-5276b131af03"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The medicine ball crunch is a medicine ball exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and lower back. The only medicine ball crunch equipment that you really need is the following: medicine ball.", "abs.png", null, "Medicine ball crunch" },
                    { new Guid("832af846-3bb5-4ba2-acab-8950bc77e8fc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The dumbbell single-arm row is a free weights exercise that primarily targets the middle back and to a lesser degree also targets the biceps, lats, lower back, shoulders and traps. The only dumbbell single-arm row equipment that you really need is the following: dumbbells and flat bench.", "lat_pulldown.png", null, "Dumbbell Single-arm Row" },
                    { new Guid("8342e7fc-79d3-4441-8f5f-fe249e949d55"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The standing barbell calf raise is a exercise machine and free weights exercise that primarily targets the calves and to a lesser degree also targets the abs, glutes and hamstrings. The only standing barbell calf raise equipment that you really need is the following: barbell.", "calves.png", null, "Standing Barbell Calf Raise" },
                    { new Guid("834a04ad-3288-455a-9eb6-d75213f3e912"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The lat pulldown is a machine-based exercise targeting the latissimus dorsi. It is performed in a seated position with a bar overhead. The lat pulldown is a great exercise for beginners to learn the basic movement pattern of the pull-up.", "lat_pulldown.png", null, "Lat Pulldown" },
                    { new Guid("88887b8e-5853-4e7a-afab-dc4d4cb3f370"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The barbell front squat is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and lower back. The only barbell front squat equipment that you really need is the following: barbell.", "quads.png", null, "Barbell Front Squat" },
                    { new Guid("8cdc341b-2d73-4493-a827-fb1bbf20ec8c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The triceps machine dip is a machine-based exercise targeting the triceps. It is similar to the bench dip, but it is performed using a machine. The machine dip is a great exercise for beginners to learn the basic movement pattern of the dip.", "triceps.png", null, "Triceps Machine Dip" },
                    { new Guid("92615894-7499-4227-a1f2-c2fa9492245d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The dumbbell romanian deadlift is a free weights exercise that primarily targets the hamstrings and to a lesser degree also targets the calves, glutes and lower back. The only dumbbell romanian deadlift equipment that you really need is the following: dumbbells.", "hamstrings.png", null, "Dumbbell Romanian Deadlift" },
                    { new Guid("93bf4048-f545-4ac9-a9f4-c7305b8b6757"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The shrug is a free weights exercise that primarily targets the traps and to a lesser degree also targets the abs, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, neck, obliques, outer thighs, quads, shoulders and triceps. The only shrug equipment that you really need is the following: barbell.", "traps.png", null, "Shrug" }
                });

            migrationBuilder.InsertData(
                table: "ExerciseTemplates",
                columns: new[] { "Id", "CreationTime", "CreatorId", "Description", "Image", "LastModifiedTime", "Name" },
                values: new object[,]
                {
                    { new Guid("9510ec7b-5a06-4f32-8c01-d2354842dce7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The rear-foot elevated lunge is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only rear-foot elevated lunge equipment that you really need is the following: dumbbells.", "hamstrings.png", null, "Rear-Foot Elevated Lunge" },
                    { new Guid("9511a218-4b5c-4c68-845c-1074302a60ce"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The farmer’s walk on toes is a free weights exercise that primarily targets the calves and to a lesser degree also targets the forearms, glutes, hamstrings, hip flexors, lower back, quads and traps. The only farmer’s walk on toes equipment that you really need is the following: dumbbells.", "calves.png", null, "Farmer’s walk on toes" },
                    { new Guid("95733dcb-d7d3-46f8-84da-c9ee72179c03"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The leg extensions is a exercise machine exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only leg extensions equipment that you really need is the following: leg extension machine.", "quads.png", null, "Leg Extensions" },
                    { new Guid("99cef42d-5225-45e1-9808-b0ba1f40af66"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The tricep dips is a bodyweight exercise that primarily targets the triceps and to a lesser degree also targets the chest and shoulders. The only tricep dips equipment that you really need is the following: dip station.", "triceps.png", null, "Tricep Dips" },
                    { new Guid("9b4829d0-c37e-4757-8e9e-89e9abf7a7b2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The incline dumbbell bench press is a free weights exercise that primarily targets the chest and to a lesser degree also targets the shoulders and triceps. The only incline dumbbell bench press equipment that you really need is the following: dumbbells and incline bench.", "bench_press.png", null, "Incline Dumbbell Press" },
                    { new Guid("9b9e7af2-ece0-4eae-8e7a-05579ffd38a7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The dumbbell fly or dumbbell flye is a strength training exercise similar in movement to a cable fly. It involves squeezing the arms together in front of the body. The difference is, in the dumbbell fly, the force is perpendicular to the body, while in the cable fly the force is horizontal to the body.", "bench_press.png", null, "Dumbbell Press Fly" },
                    { new Guid("9fa18bd3-4717-4223-af22-e1fcf78be513"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The standard push-up is a bodyweight exercise that primarily targets the chest and to a lesser degree also targets the abs, lower back, middle back, shoulders and triceps. The only standard push-up equipment that you really need is the following: no equipment.", "triceps.png", null, "Standard Push-Up" },
                    { new Guid("a07c5863-6afd-41c7-a31d-0aeefa5d54c3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The dumbbell bench press is a variation of the barbell bench press and an exercise used to build the muscles of the chest. Often times, the dumbbell bench press is recommended after reaching a certain point of strength on the barbell bench press to avoid pec and shoulder injuries.", "bench_press.png", null, "Dumbbell Press" },
                    { new Guid("a28e6aa4-fb62-44b9-b6c0-f19719e5c714"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The jumping jack is a calisthenics and cardiovascular exercise that primarily targets the calves and to a lesser degree also targets the abs, biceps, chest, forearms, glutes, groin, hamstrings, hip flexors, lats, lower back, middle back, obliques, quads, shoulders, traps and triceps.", "calves.png", null, "Jumping Jack" },
                    { new Guid("a3564a91-8b75-4557-9d31-759d0ca5769f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The incline dumbbell curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only incline dumbbell curl equipment that you really need is the following: dumbbells and incline bench.", "biceps.png", null, "Incline Dumbbell Curl" },
                    { new Guid("a3ae47c9-442b-4669-861b-2f9e0fd47d4f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The standing dumbbell curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only standing dumbbell curl equipment that you really need is the following: dumbbells.", "biceps.png", null, "Standing Dumbbell Curl" },
                    { new Guid("a4a06094-3935-450d-9265-29c98fb2c146"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The diagonal walking lunges is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only diagonal walking lunges equipment that you really need is the following: dumbbells.", "quads.png", null, "Diagonal Walking Lunges" },
                    { new Guid("a802b003-9d6a-4b62-bf5d-4385b804fc0a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The dumbbell overhead triceps extension is a free weights exercise that primarily targets the triceps and to a lesser degree also targets the chest and shoulders. The only dumbbell overhead triceps extension equipment that you really need is the following: dumbbells and flat bench.", "triceps.png", null, "Dumbbell Overhead Triceps Extension" },
                    { new Guid("a82d17c1-b2fb-4ccc-96e6-98088f23d4d0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The bosu ball squat is a exercise machine and calisthenics exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only bosu ball squat equipment that you really need is the following: bosu ball.", "calves.png", null, "Bosu Ball Squat" },
                    { new Guid("adf183e2-8e57-4cf9-8dc5-ad1aa4775075"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The dead bug is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and lower back. The only dead bug equipment that you really need is the following: exercise mat.", "abs.png", null, "Dead bug" },
                    { new Guid("b2d5f742-9494-472f-912f-9c00e799fca6"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The agility ladder is a calisthenics and cardiovascular exercise that primarily targets the calves and to a lesser degree also targets the abs, biceps, chest, forearms, glutes, groin, hamstrings, hip flexors, lats, lower back, middle back, obliques, quads, shoulders, traps and triceps.", "calves.png", null, "Agility Ladder" },
                    { new Guid("b40ad979-7993-458f-9619-29763cf2c9c3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The barbell back squat is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and lower back. The only barbell back squat equipment that you really need is the following: barbell.", "quads.png", null, "Barbell Back Squat" },
                    { new Guid("b53546bf-271a-4ca0-a90f-495a4153d28f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The cable push-down is a strength training exercise that primarily targets the triceps and to a lesser degree also targets the chest and shoulders. The only cable push-down equipment that you really need is the following: cable machine and v-bar attachment.", "triceps.png", null, "Cable Push-Down" },
                    { new Guid("b5ad50e8-e99e-4c61-a0b6-acff634f1d63"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The standing cable curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only standing cable curl equipment that you really need is the following: cable machine.", "biceps.png", null, "Standing Cable Curl" },
                    { new Guid("b8a7b6ca-8f32-4592-ba05-ba5045e6d4c9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The cable overhead extension with rope is a strength training exercise that primarily targets the triceps and to a lesser degree also targets the chest and shoulders. The only cable overhead extension with rope equipment that you really need is the following: cable machine and rope attachment.", "triceps.png", null, "Cable Overhead Extension With Rope" },
                    { new Guid("bb0f3af6-e571-4f4a-bbe5-cf8801b7a02c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The one-arm cable lateral raise is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the abs, forearms, traps and triceps. The only one-arm cable lateral raise equipment that you really need is the following: cable machine.", "shoulders.png", null, "One-Arm Cable Lateral Raise" },
                    { new Guid("bb6b31e1-fea9-4835-a655-483f5b9695d7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The deadlift is a free weights exercise that primarily targets the hamstrings and to a lesser degree also targets the calves, glutes, lower back and quads. The only deadlift equipment that you really need is the following: barbell.", "hamstrings.png", null, "Deadlift" },
                    { new Guid("bbaf62ce-3faf-4e76-8d1f-ca85850a6f1e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The cable flex curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only cable flex curl equipment that you really need is the following: cable machine.", "biceps.png", null, "Cable Flex Curl" },
                    { new Guid("c204e55c-c00f-485d-bd2f-1def4b440e9c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The machine shoulder press is a exercise machine exercise that primarily targets the shoulders and to a lesser degree also targets the abs, calves, forearms, middle back, quads and triceps. The only machine shoulder press equipment that you really need is the following: shoulder press machine.", "shoulders.png", null, "Machine Shoulder Press" },
                    { new Guid("c2d1ad5e-8cd3-4f31-9919-391d3055ecc2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The lying triceps extension is a free weights exercise that primarily targets the triceps and to a lesser degree also targets the chest and shoulders. The only lying triceps extension equipment that you really need is the following: dumbbells and flat bench.", "triceps.png", null, "Lying Triceps Extension" },
                    { new Guid("cf3752a3-9e6b-4816-9c6d-eb063fc0a478"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The barbell box squat is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and lower back. The only barbell box squat equipment that you really need is the following: barbell and box.", "quads.png", null, "Barbell Box Squat" },
                    { new Guid("d38f1637-f620-4949-b007-92114a3c9c93"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The machine press fly or machine fly is a strength training exercise similar in movement to the pec deck. It involves squeezing the arms together in front of the body. The difference is, in the pec deck, the force is perpendicular to the body, while in the machine fly the force is horizontal to the body.", "bench_press.png", null, "Machine Press Fly" },
                    { new Guid("d4222158-af81-4061-813a-4fcca3de7bfb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The standing dumbbell fly is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the chest and traps. The only standing dumbbell fly equipment that you really need is the following: dumbbells.", "shoulders.png", null, "Standing Dumbbell Fly" },
                    { new Guid("d434546b-154d-4c78-812a-8681578280e8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The renegade row is a free weights exercise that primarily targets the middle back and to a lesser degree also targets the biceps, lats, lower back, shoulders and traps. The only renegade row equipment that you really need is the following: dumbbells and flat bench.", "lat_pulldown.png", null, "Renegade Row" },
                    { new Guid("d4685c36-e1a2-4122-a2f2-39582057d198"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The diamond push-ups is a bodyweight exercise that primarily targets the triceps and to a lesser degree also targets the chest and shoulders. The only diamond push-ups equipment that you really need is the following: no equipment.", "triceps.png", null, "Diamond Push-Ups" },
                    { new Guid("da94326e-ce24-4b40-ae9e-fe643effb40d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The barbell overhead press is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the abs, calves, forearms, quads, traps and triceps. The only barbell overhead press equipment that you really need is the following: barbell.", "shoulders.png", null, "Barbell Overhead Press" },
                    { new Guid("e04f0e59-c2a5-45aa-a431-38636726c30f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The face pull is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the abs, forearms, traps and triceps. The only face pull equipment that you really need is the following: cable machine.", "shoulders.png", null, "Face Pull" },
                    { new Guid("e08741ca-f017-408f-8fda-0b15722fb2b0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The leg press is a exercise machine exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only leg press equipment that you really need is the following: leg press machine.", "quads.png", null, "Leg Press" },
                    { new Guid("e4d20bf6-cbf9-46d3-b8c3-b5af02235e88"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The tuck and crunch is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and lower back. The only tuck and crunch equipment that you really need is the following: exercise mat.", "abs.png", null, "Tuck and crunch" },
                    { new Guid("e5f441df-92c2-457b-a221-956f86b05df7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The dumbbell snatch is a free weights exercise that primarily targets the traps and to a lesser degree also targets the abs, biceps, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, neck, obliques, outer thighs, quads, shoulders and triceps. The only dumbbell snatch equipment that you really need is the following: dumbbells.", "traps.png", null, "Dumbbell Snatch" },
                    { new Guid("e72ef35d-5ee1-4c14-8113-83ab2f5535a7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The snatch-grip low pull is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the biceps, calves, forearms, hamstrings, lats, lower back, middle back, quads, traps and triceps. The only snatch-grip low pull equipment that you really need is the following: barbell.", "shoulders.png", null, "Snatch-Grip Low Pull" },
                    { new Guid("e7997730-666f-437f-b892-f566de2729ae"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The hammer curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only hammer curl equipment that you really need is the following: dumbbells.", "biceps.png", null, "Hammer Curl" },
                    { new Guid("e8ca5541-8bce-4b34-893a-be12b7671999"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The med ball wood chop is a free weights exercise that primarily targets the abs and to a lesser degree also targets the chest, forearms, glutes, hamstrings, hip flexors, lower back, middle back, obliques, quads, shoulders and traps. The only med ball wood chop equipment that you really need is the following: medicine ball.", "lat_pulldown.png", null, "Med Ball Wood Chop" },
                    { new Guid("e908d2f7-e8db-4216-9f17-bb7da11d86da"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The seated row is a machine-based exercise targeting the middle back. It is performed in a seated position with a chest pad, two foot pads, and a handle to pull. The seated row is a great exercise for beginners to learn the basic movement pattern of the row.", "lat_pulldown.png", null, "Seated Row" },
                    { new Guid("ebc752b3-8034-44a7-bc50-004e078000a0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The twisting dumbbell curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only twisting dumbbell curl equipment that you really need is the following: dumbbells.", "biceps.png", null, "Twisting Dumbbell Curl" },
                    { new Guid("ec2ce80c-8a98-4cea-a82e-6445c4abf497"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The jump rope is a calisthenics and cardiovascular exercise that primarily targets the calves and to a lesser degree also targets the abs, biceps, chest, forearms, glutes, groin, hamstrings, hip flexors, lats, lower back, middle back, obliques, quads, shoulders, traps and triceps.", "calves.png", null, "Jump rope" },
                    { new Guid("eec26cfa-aee7-4a77-9beb-2499b4a94861"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The flutter kicks is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and lower back. The only flutter kicks equipment that you really need is the following: exercise mat.", "abs.png", null, "Flutter kicks" }
                });

            migrationBuilder.InsertData(
                table: "ExerciseTemplates",
                columns: new[] { "Id", "CreationTime", "CreatorId", "Description", "Image", "LastModifiedTime", "Name" },
                values: new object[,]
                {
                    { new Guid("eefbafe6-2025-413d-a78f-ec911fa2379e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The bench press is an upper-body weight training exercise in which the trainee presses a weight upwards while lying on a weight training bench. The exercise uses the pectoralis major, the anterior deltoids, and the triceps, among other stabilizing muscles.", "bench_press.png", null, "Bench Press" },
                    { new Guid("efdcac64-5b18-4fd8-8d89-993e34a79285"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The crunch is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and neck. The only crunch equipment that you really need is the following: exercise mat.", "abs.png", null, "Crunch" },
                    { new Guid("f278c87f-ad83-4c0e-a60d-ff5b19ed1519"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The bench dip is a bodyweight exercise that primarily targets the triceps and to a lesser degree also targets the chest and shoulders. The only bench dip equipment that you really need is the following: bench.", "triceps.png", null, "Bench Dip" },
                    { new Guid("f2f91ecb-c94f-4118-b897-90a536066bbf"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The glute-ham raise is a exercise machine exercise that primarily targets the hamstrings and to a lesser degree also targets the calves, glutes and lower back. The only glute-ham raise equipment that you really need is the following: glute ham raise machine.", "hamstrings.png", null, "Glute-Ham Raise" },
                    { new Guid("f3a969e9-f36d-4461-8623-759750172ba0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The standing reverse barbell curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only standing reverse barbell curl equipment that you really need is the following: barbell.", "biceps.png", null, "Standing Reverse Barbell Curl" },
                    { new Guid("f5edb822-987e-4dd4-b93a-023a5e83dda4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The leg raise is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and lower back. The only leg raise equipment that you really need is the following: exercise mat.", "abs.png", null, "Leg raise" },
                    { new Guid("f8f07246-891b-4f52-b3c7-774847623598"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The box jump is a plyometrics exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only box jump equipment that you really need is the following: box.", "quads.png", null, "Box Jump" },
                    { new Guid("f9f6be07-7860-4d84-8844-8366f81c5b9b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The upright row is a free weights exercise that primarily targets the traps and to a lesser degree also targets the abs, biceps, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, neck, obliques, outer thighs, quads, shoulders and triceps. The only upright row equipment that you really need is the following: barbell.", "traps.png", null, "Upright row" },
                    { new Guid("fd928f50-a399-4f4a-81d2-49efeca83156"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The close-grip bench press is a free weights exercise that primarily targets the triceps and to a lesser degree also targets the chest and shoulders. The only close-grip bench press equipment that you really need is the following: barbell and flat bench.", "triceps.png", null, "Close-Grip Bench Press" },
                    { new Guid("fe0b170a-953c-41db-97ba-b2911c3161bb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The abs roll-out is a exercise machine and pilates exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and lower back. The only abs roll-out equipment that you really need is the following: ab roller.", "abs.png", null, "Abs roll-out" },
                    { new Guid("ff163dbc-f496-4c8d-9912-130186269781"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The t-bar row is a free weights exercise that primarily targets the middle back and to a lesser degree also targets the biceps, lats, lower back, shoulders and traps. The only t-bar row equipment that you really need is the following: t-bar row machine and v-handle attachment.", "lat_pulldown.png", null, "T-Bar Row" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_CreatorId",
                table: "Exercises",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_WorkoutId",
                table: "Exercises",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTemplates_CreatorId",
                table: "ExerciseTemplates",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Macro_CreatorId",
                table: "Macro",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_CreatorId",
                table: "Workouts",
                column: "CreatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "ExerciseTemplates");

            migrationBuilder.DropTable(
                name: "Macro");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
