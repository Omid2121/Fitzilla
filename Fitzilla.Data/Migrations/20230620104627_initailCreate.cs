using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitzilla.Data.Migrations
{
    public partial class initailCreate : Migration
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
                name: "ExerciseTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseTypes_AspNetUsers_CreatorId",
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
                    Calories = table.Column<double>(type: "float", nullable: false),
                    Protein = table.Column<double>(type: "float", nullable: false),
                    Carbohydrates = table.Column<double>(type: "float", nullable: false),
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
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Set = table.Column<int>(type: "int", nullable: false),
                    Rep = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExerciseTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        name: "FK_Exercises_ExerciseTypes_ExerciseTypeId",
                        column: x => x.ExerciseTypeId,
                        principalTable: "ExerciseTypes",
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
                    { "3709a9c6-5445-458e-b1fe-cb29345f5697", "e2783ce4-74d2-44ae-ba0b-4adba6c274c7", "Consumer", "CONSUMER" },
                    { "3d22deb9-4c0d-4446-9e8b-ffbee35f3c78", "82bdd954-642a-43f9-abc9-ab3ab89ac1db", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "CreationTime", "CreatorId", "Description", "Icon", "LastModifiedTime", "Name" },
                values: new object[,]
                {
                    { new Guid("0131ea74-5408-41f6-881e-183c69d163a2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The barbell back squat is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and lower back. The only barbell back squat equipment that you really need is the following: barbell.", "quads.png", null, "Barbell Back Squat" },
                    { new Guid("0283b712-d19f-47fe-8a08-efc1db1c1527"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The standing barbell calf raise is a exercise machine and free weights exercise that primarily targets the calves and to a lesser degree also targets the abs, glutes and hamstrings. The only standing barbell calf raise equipment that you really need is the following: barbell.", "calves.png", null, "Standing Barbell Calf Raise" },
                    { new Guid("03fb8d3b-a0a1-40d7-9a1b-94204941ddc3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The trap raise is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the abs, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, quads and triceps. The only trap raise equipment that you really need is the following: dumbbells.", "shoulders.png", null, "Trap Raise" },
                    { new Guid("040f25d6-8328-4fc2-a0ec-46faadb0b0d8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The incline dumbbell fly or incline dumbbell flye is a strength training exercise similar in movement to the incline dumbbell fly. It involves squeezing the arms together in front of the body. The difference is, in the incline dumbbell fly, the force is perpendicular to the body, while in the incline dumbbell fly the force is horizontal to the body.", "bench_press.png", null, "Incline Dumbbell Press Fly" },
                    { new Guid("054368e5-876c-4771-b52d-c291bdd12247"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The lat pulldown is a machine-based exercise targeting the latissimus dorsi. It is performed in a seated position with a bar overhead. The lat pulldown is a great exercise for beginners to learn the basic movement pattern of the pull-up.", "lat_pulldown.png", null, "Lat Pulldown" },
                    { new Guid("062a08f1-4815-4576-b69e-04a00a7e0456"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The med ball wood chop is a free weights exercise that primarily targets the abs and to a lesser degree also targets the chest, forearms, glutes, hamstrings, hip flexors, lower back, middle back, obliques, quads, shoulders and traps. The only med ball wood chop equipment that you really need is the following: medicine ball.", "lat_pulldown.png", null, "Med Ball Wood Chop" },
                    { new Guid("08234c30-0400-42b2-98c5-61fbd46151a6"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The barbell box squat is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and lower back. The only barbell box squat equipment that you really need is the following: barbell and box.", "quads.png", null, "Barbell Box Squat" },
                    { new Guid("084f64dd-4a2b-4e9a-8642-b6a7ecd6ad64"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The shrug is a free weights exercise that primarily targets the traps and to a lesser degree also targets the abs, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, neck, obliques, outer thighs, quads, shoulders and triceps. The only shrug equipment that you really need is the following: barbell.", "traps.png", null, "Shrug" },
                    { new Guid("0997fad6-88af-4238-9304-758078674e4b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The grounded russian twist is a exercise machine and pilates exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and lower back. The only grounded russian twist equipment that you really need is the following: exercise ball.", "abs.png", null, "Grounded Russian twist" },
                    { new Guid("0b722e9d-e0dd-4330-87b7-4ac1067439f4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The snatch-grip low pull is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the biceps, calves, forearms, hamstrings, lats, lower back, middle back, quads, traps and triceps. The only snatch-grip low pull equipment that you really need is the following: barbell.", "shoulders.png", null, "Snatch-Grip Low Pull" },
                    { new Guid("0efc5e0e-9c68-47cc-ada8-43bc1b8fb695"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The reverse crunch is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and lower back. The only reverse crunch equipment that you really need is the following: exercise mat.", "abs.png", null, "Reverse crunch" },
                    { new Guid("0f033511-8549-4672-9318-b1cf355ec94c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The v-sit is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and lower back. The only v-sit equipment that you really need is the following: exercise mat.", "abs.png", null, "V-sit" },
                    { new Guid("0f795709-c1a9-4876-9498-bdd146db2e26"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The mountain climber is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the calves, chest, forearms, glutes, hamstrings, hip flexors, lower back, middle back, quads, shoulders and traps. The only mountain climber equipment that you really need is the following: exercise mat.", "abs.png", null, "Mountain climber" },
                    { new Guid("12532fff-c87a-4ad6-9da4-badaf58f2671"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The face pull is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the abs, forearms, traps and triceps. The only face pull equipment that you really need is the following: cable machine.", "shoulders.png", null, "Face Pull" },
                    { new Guid("1b20e0a5-f681-4ed9-8b45-4f7fa88fce52"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The decline bench press is an exercise which helps you get the complete chest development. It recruits more of the inner pecs, i.e. the sternocostal head of the pectoralis major muscle. It is performed in a very similar manner to the flat bench press, the only difference is that the bench is set to a decline position of 15 to 30 degrees.", "bench_press.png", null, "Decline Bench Press" },
                    { new Guid("1ee40869-e79b-4c1c-9b6d-81f6415bffdd"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The bicycle crunch is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and lower back. The only bicycle crunch equipment that you really need is the following: exercise mat.", "abs.png", null, "Bicycle Crunch" },
                    { new Guid("211cce85-915d-4d4c-88c4-7eedd13b49f8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The dumbbell romanian deadlift is a free weights exercise that primarily targets the hamstrings and to a lesser degree also targets the calves, glutes and lower back. The only dumbbell romanian deadlift equipment that you really need is the following: dumbbells.", "hamstrings.png", null, "Dumbbell Romanian Deadlift" },
                    { new Guid("287e685b-da05-4fda-8ed2-5f49fac35bf5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The incline bench press is an upper body strength training exercise that consists of pressing a weight at an angle, similar to but less than one hundred and eighty degrees, to the body. This angle is between 45 and 60 degrees, lower than that of a standard bench press.", "bench_press.png", null, "Incline Bench Press" },
                    { new Guid("299c8cff-3b08-48ac-a37f-51514ed44fa3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The seated calf raise is a exercise machine exercise that primarily targets the calves and to a lesser degree also targets the abs, glutes and hamstrings. The only seated calf raise equipment that you really need is the following: calf raise machine.", "calves.png", null, "Seated calf raise" },
                    { new Guid("2a72338f-3b81-4470-9823-3103775f1b29"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The agility ladder is a calisthenics and cardiovascular exercise that primarily targets the calves and to a lesser degree also targets the abs, biceps, chest, forearms, glutes, groin, hamstrings, hip flexors, lats, lower back, middle back, obliques, quads, shoulders, traps and triceps.", "calves.png", null, "Agility Ladder" },
                    { new Guid("2bbc7c36-243a-4d28-b86a-44cbf7c7b1a0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The incline machine press is a machine-based exercise targeting the chest. It is similar to the incline barbell press, but it is performed using a machine. The machine press is a great exercise for beginners to learn the basic movement pattern of the incline press.", "bench_press.png", null, "Incline Machine Press" },
                    { new Guid("2c1edf37-f82d-43d9-8eca-48ec01ccbd96"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The machine shoulder press is a exercise machine exercise that primarily targets the shoulders and to a lesser degree also targets the abs, calves, forearms, middle back, quads and triceps. The only machine shoulder press equipment that you really need is the following: shoulder press machine.", "shoulders.png", null, "Machine Shoulder Press" },
                    { new Guid("2c9e0956-d900-427f-925c-53b29ef1268f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The decline dumbbell bench press is a free weights exercise that primarily targets the chest and to a lesser degree also targets the shoulders and triceps. The only decline dumbbell bench press equipment that you really need is the following: dumbbells and decline bench.", "bench_press.png", null, "Decline Dumbbell Press" },
                    { new Guid("2ee8b213-76c4-405a-b810-bc5c1c244f74"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The hammer curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only hammer curl equipment that you really need is the following: dumbbells.", "biceps.png", null, "Hammer Curl" },
                    { new Guid("2fc730c6-6cfd-4b72-81a0-c23b8ee308b9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The hack squat is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only hack squat equipment that you really need is the following: hack squat machine.", "quads.png", null, "Hack Squat" },
                    { new Guid("2ffebe9c-71b8-4362-b888-4e40da91c4d2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The machine press is a machine-based exercise targeting the chest. It is similar to the barbell bench press, but it is performed using a machine. The machine press is a great exercise for beginners to learn the basic movement pattern of the bench press.", "bench_press.png", null, "Machine Press" },
                    { new Guid("307aebd8-1a56-4b0a-a388-e916e537ddc7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The hanging knee raise twist is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and obliques. The only hanging knee raise twist equipment that you really need is the following: pull-up bar.", "abs.png", null, "Hanging knee raise twist" },
                    { new Guid("3884aa8d-5e31-4ed8-afca-b676bccabc79"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The lying leg curl is a exercise machine exercise that primarily targets the hamstrings and to a lesser degree also targets the calves, glutes and lower back. The only lying leg curl equipment that you really need is the following: leg curl machine.", "hamstrings.png", null, "Lying Leg Curl" },
                    { new Guid("39f2da89-b1ee-4f49-9a11-1fddc4cfdf64"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The barbell behind-the-back shrug is a free weights exercise that primarily targets the traps and to a lesser degree also targets the abs, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, neck, obliques, outer thighs, quads, shoulders and triceps. The only barbell behind-the-back shrug equipment that you really need is the following: barbell.", "traps.png", null, "Barbell Behind-the-Back Shrug" },
                    { new Guid("3a187b32-6118-434a-a20d-28f7c8e1bff8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The back extension is a exercise machine exercise that primarily targets the lower back and to a lesser degree also targets the abs, glutes and hamstrings. The only back extension equipment that you really need is the following: hyperextension machine.", "hamstrings.png", null, "Back Extension" },
                    { new Guid("3d4651fa-5856-4da3-a32a-e6c2b0240b45"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The barbell overhead press is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the abs, calves, forearms, quads, traps and triceps. The only barbell overhead press equipment that you really need is the following: barbell.", "shoulders.png", null, "Barbell Overhead Press" },
                    { new Guid("3e18004e-2357-4fab-9ece-b52484b3fb3f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The ez bar curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only ez bar curl equipment that you really need is the following: ez curl bar.", "biceps.png", null, "EZ Bar Curl" },
                    { new Guid("3e461d76-bd05-46d1-8034-d4c7e76c31f3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The dumbbell bench press is a variation of the barbell bench press and an exercise used to build the muscles of the chest. Often times, the dumbbell bench press is recommended after reaching a certain point of strength on the barbell bench press to avoid pec and shoulder injuries.", "bench_press.png", null, "Dumbbell Press" },
                    { new Guid("3e526ed2-e428-4000-8426-f12ad6bf8cb0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The seated row is a machine-based exercise targeting the middle back. It is performed in a seated position with a chest pad, two foot pads, and a handle to pull. The seated row is a great exercise for beginners to learn the basic movement pattern of the row.", "lat_pulldown.png", null, "Seated Row" },
                    { new Guid("403a2d6f-61bb-44db-b95d-a33c3d47d0f5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The one-arm cable lateral raise is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the abs, forearms, traps and triceps. The only one-arm cable lateral raise equipment that you really need is the following: cable machine.", "shoulders.png", null, "One-Arm Cable Lateral Raise" },
                    { new Guid("409f48a1-213a-406f-854b-7e5e9869618a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The one-arm overhead extension is a free weights exercise that primarily targets the triceps and to a lesser degree also targets the chest and shoulders. The only one-arm overhead extension equipment that you really need is the following: dumbbell.", "triceps.png", null, "One-Arm Overhead Extension" },
                    { new Guid("44dc89ed-2074-4981-9893-ef05f225e4a0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The shoulder blade squeeze is a bodyweight exercise that primarily targets the traps and to a lesser degree also targets the abs, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, neck, obliques, outer thighs, quads, shoulders and triceps. The only shoulder blade squeeze equipment that you really need is the following: exercise mat.", "traps.png", null, "Shoulder blade squeeze" },
                    { new Guid("46b5142f-20fe-4b9e-b07f-b3d4404c34cb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The leg press is a exercise machine exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only leg press equipment that you really need is the following: leg press machine.", "quads.png", null, "Leg Press" },
                    { new Guid("4feaecaf-8088-46c1-b8ac-1bfebf48602f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The dip is a strength training exercise used to develop strength and size in triceps. Dips are an advanced bodyweight exercise that is primarily used to develop the triceps muscles. It is also a compound exercise that also involves the chest and shoulders, making it a great exercise for developing overall upper body strength.", "bench_press.png", null, "Dips" },
                    { new Guid("51477364-d896-4ea0-8ecc-831875251fa6"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The front raise is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the abs, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, quads and triceps. The only front raise equipment that you really need is the following: dumbbells.", "shoulders.png", null, "Front Raise" }
                });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "CreationTime", "CreatorId", "Description", "Icon", "LastModifiedTime", "Name" },
                values: new object[,]
                {
                    { new Guid("53fa25e7-d520-45c1-b35c-21c1175d1b3a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The rear-foot elevated lunge is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only rear-foot elevated lunge equipment that you really need is the following: dumbbells.", "hamstrings.png", null, "Rear-Foot Elevated Lunge" },
                    { new Guid("56110c39-b389-4474-8c79-20b93b9e0728"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The jump rope is a calisthenics and cardiovascular exercise that primarily targets the calves and to a lesser degree also targets the abs, biceps, chest, forearms, glutes, groin, hamstrings, hip flexors, lats, lower back, middle back, obliques, quads, shoulders, traps and triceps.", "calves.png", null, "Jump rope" },
                    { new Guid("57fc490c-380d-424e-99ae-a166fd562aca"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The seated alternating dumbbell curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only seated alternating dumbbell curl equipment that you really need is the following: dumbbells and flat bench.", "biceps.png", null, "Seated Alternating Dumbbell Curl" },
                    { new Guid("5961a128-ddc5-4eb7-bf51-819e925082b2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The barbell shrug is a free weights exercise that primarily targets the traps and to a lesser degree also targets the abs, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, neck, obliques, outer thighs, quads, shoulders and triceps. The only barbell shrug equipment that you really need is the following: barbell.", "traps.png", null, "Barbell Shrug" },
                    { new Guid("596f259f-46c6-4c46-84bf-fa9e52438c78"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The lying triceps extension is a free weights exercise that primarily targets the triceps and to a lesser degree also targets the chest and shoulders. The only lying triceps extension equipment that you really need is the following: dumbbells and flat bench.", "triceps.png", null, "Lying Triceps Extension" },
                    { new Guid("60efb1e3-e8fa-48ae-8947-b1ef30d66aeb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The single-arm t-bar rows is a free weights exercise that primarily targets the middle back and to a lesser degree also targets the biceps, lats, lower back, shoulders and traps. The only single-arm t-bar rows equipment that you really need is the following: t-bar row machine and v-handle attachment.", "lat_pulldown.png", null, "Single-arm T-Bar Rows" },
                    { new Guid("65315094-d830-4f0b-a8b2-3dc879fac3f5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The decline dumbbell fly or decline dumbbell flye is a strength training exercise similar in movement to the decline dumbbell fly. It involves squeezing the arms together in front of the body. The difference is, in the decline dumbbell fly, the force is perpendicular to the body, while in the decline dumbbell fly the force is horizontal to the body.", "bench_press.png", null, "Decline Dumbbell Press Fly" },
                    { new Guid("6c91a8f4-5910-4d9c-97c7-8a7d4b677ff7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The tuck and crunch is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and lower back. The only tuck and crunch equipment that you really need is the following: exercise mat.", "abs.png", null, "Tuck and crunch" },
                    { new Guid("71983645-be00-481f-ae42-7433d90c9b80"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The barbell bent-over row is a free weights exercise that primarily targets the middle back and to a lesser degree also targets the biceps, lats, lower back, shoulders and traps. The only barbell bent-over row equipment that you really need is the following: barbell.", "lat_pulldown.png", null, "Barbell Bent-Over Row" },
                    { new Guid("74a92a0c-b6b2-4db9-a79f-2fe72825f061"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The standard push-up is a bodyweight exercise that primarily targets the chest and to a lesser degree also targets the abs, lower back, middle back, shoulders and triceps. The only standard push-up equipment that you really need is the following: no equipment.", "triceps.png", null, "Standard Push-Up" },
                    { new Guid("74d1045a-9f41-4a64-8f84-77c3dc2e4f2a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The seated calf raise is a exercise machine exercise that primarily targets the calves and to a lesser degree also targets the abs, glutes and hamstrings. The only seated calf raise equipment that you really need is the following: calf raise machine.", "calves.png", null, "Seated Calf Raise" },
                    { new Guid("7526aee4-b63d-4344-b031-59c3c38a8163"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The cable fly or cable flye is a strength training exercise similar in movement to the pec deck. It involves squeezing the arms together in front of the body. The difference is, in the pec deck, the force is perpendicular to the body, while in the cable fly the force is horizontal to the body.", "bench_press.png", null, "Cable Press Fly" },
                    { new Guid("76fce528-b1bb-4827-90e1-7746a5bc9b3b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The dumbbell single-arm row is a free weights exercise that primarily targets the middle back and to a lesser degree also targets the biceps, lats, lower back, shoulders and traps. The only dumbbell single-arm row equipment that you really need is the following: dumbbells and flat bench.", "lat_pulldown.png", null, "Dumbbell Single-arm Row" },
                    { new Guid("77b31933-9594-49c2-a060-c513748a7d98"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The standing dumbbell fly is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the chest and traps. The only standing dumbbell fly equipment that you really need is the following: dumbbells.", "shoulders.png", null, "Standing Dumbbell Fly" },
                    { new Guid("77da49fd-e07e-42a2-a0bd-15f82bc46be9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The box jump is a plyometrics exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only box jump equipment that you really need is the following: box.", "quads.png", null, "Box Jump" },
                    { new Guid("7a3e3e75-d13d-4698-a1ff-dc4b302458ef"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The deadlift is a free weights exercise that primarily targets the hamstrings and to a lesser degree also targets the calves, glutes, lower back and quads. The only deadlift equipment that you really need is the following: barbell.", "hamstrings.png", null, "Deadlift" },
                    { new Guid("7dbb7432-5255-4e32-b858-7c0b6d5fa555"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The standing reverse barbell curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only standing reverse barbell curl equipment that you really need is the following: barbell.", "biceps.png", null, "Standing Reverse Barbell Curl" },
                    { new Guid("806461a1-aa48-4573-bb30-d7723ff602a6"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The hip thrust is a free weights exercise that primarily targets the hamstrings and to a lesser degree also targets the calves, glutes and lower back. The only hip thrust equipment that you really need is the following: barbell.", "hamstrings.png", null, "Hip Thrust" },
                    { new Guid("80bf26ed-f8ea-402f-8165-52d6c7a46f78"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The seated single-leg jump squat is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only seated single-leg jump squat equipment that you really need is the following: box.", "quads.png", null, "Seated Single-Leg Jump Squat" },
                    { new Guid("82a84064-3de8-4ed8-a712-64f3a77ed319"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The decline machine press is a machine-based exercise targeting the chest. It is similar to the decline barbell press, but it is performed using a machine. The machine press is a great exercise for beginners to learn the basic movement pattern of the decline press.", "bench_press.png", null, "Decline Machine Press" },
                    { new Guid("82dbdef5-31a8-478d-be8c-f6499882d00a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The dumbbell pull-over is a free weights exercise that primarily targets the lats and to a lesser degree also targets the chest, forearms, lower back, middle back, shoulders and triceps. The only dumbbell pull-over equipment that you really need is the following: dumbbell.", "lat_pulldown.png", null, "Dumbbell Pull-Over" },
                    { new Guid("869ff70d-ae7b-4a0d-9645-06b679721d39"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The leg extensions is a exercise machine exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only leg extensions equipment that you really need is the following: leg extension machine.", "quads.png", null, "Leg Extensions" },
                    { new Guid("88a18a35-26cc-4f7e-99b7-1127e45bd3ef"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The incline dumbbell shrug is a free weights exercise that primarily targets the traps and to a lesser degree also targets the abs, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, neck, obliques, outer thighs, quads, shoulders and triceps. The only incline dumbbell shrug equipment that you really need is the following: dumbbells and incline bench.", "traps.png", null, "Incline Dumbbell Shrug" },
                    { new Guid("8a3a2ed0-0ef4-4732-9ad2-d9d0d0af6239"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The plank is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the chest, forearms, glutes, hamstrings, lower back, middle back, shoulders and traps. The only plank equipment that you really need is the following: exercise mat.", "abs.png", null, "Plank" },
                    { new Guid("8bebf513-9604-4cc2-a7ac-628739aad414"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The single-arm cable kick-back is a strength training exercise that primarily targets the triceps and to a lesser degree also targets the shoulders and forearms. The only single-arm cable kick-back equipment that you really need is the following: cable machine.", "triceps.png", null, "Single-Arm Cable Kick-Back" },
                    { new Guid("8ceee7ca-4570-49a3-9b9b-0fe9e9a3d0b5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The standing dumbbell curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only standing dumbbell curl equipment that you really need is the following: dumbbells.", "biceps.png", null, "Standing Dumbbell Curl" },
                    { new Guid("8d72d581-79c4-4035-ae7a-aff7b6451f08"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The dumbbell raise complex is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the abs, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, quads and triceps. The only dumbbell raise complex equipment that you really need is the following: dumbbells.", "shoulders.png", null, "Dumbbell Raise Complex" },
                    { new Guid("8fcca9df-31f9-4a0a-b942-3939d43b8fce"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The bench dip is a bodyweight exercise that primarily targets the triceps and to a lesser degree also targets the chest and shoulders. The only bench dip equipment that you really need is the following: bench.", "triceps.png", null, "Bench Dip" },
                    { new Guid("9214d141-9831-4848-bcff-0e473cbcca7c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The farmer’s walk on toes is a free weights exercise that primarily targets the calves and to a lesser degree also targets the forearms, glutes, hamstrings, hip flexors, lower back, quads and traps. The only farmer’s walk on toes equipment that you really need is the following: dumbbells.", "calves.png", null, "Farmer’s walk on toes" },
                    { new Guid("929c19e8-4a2e-4049-acd3-7f789507fce4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The leg raise is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and lower back. The only leg raise equipment that you really need is the following: exercise mat.", "abs.png", null, "Leg raise" },
                    { new Guid("93de6e16-8d96-4f54-8f8b-da796ac20a9e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The dumbbell woodchop is a free weights exercise that primarily targets the abs and to a lesser degree also targets the chest, forearms, glutes, hamstrings, hip flexors, lower back, middle back, obliques, quads, shoulders and traps. The only dumbbell woodchop equipment that you really need is the following: dumbbells.", "abs.png", null, "Dumbbell woodchop" },
                    { new Guid("9445eb3e-e3bd-4ba4-8934-749ba1d25a59"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The bulgarian split squat is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only bulgarian split squat equipment that you really need is the following: dumbbells and bench.", "quads.png", null, "Bulgarian Split Squat" },
                    { new Guid("9838c915-9647-4a41-8328-daaa6d7af370"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The triceps machine dip is a machine-based exercise targeting the triceps. It is similar to the bench dip, but it is performed using a machine. The machine dip is a great exercise for beginners to learn the basic movement pattern of the dip.", "triceps.png", null, "Triceps Machine Dip" },
                    { new Guid("9ae837bf-4ea7-4cc8-a17d-d72a7fe15526"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The snatch-grip high pull is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the biceps, calves, forearms, hamstrings, lats, lower back, middle back, quads, traps and triceps. The only snatch-grip high pull equipment that you really need is the following: barbell.", "shoulders.png", null, "Snatch-Grip High Pull" },
                    { new Guid("9b896489-f2f1-4962-b33f-54603896dba4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The clean and press is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the abs, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, quads and triceps. The only clean and press equipment that you really need is the following: barbell.", "shoulders.png", null, "Clean and Press" },
                    { new Guid("9fa34893-0c82-432f-b559-ffa3f36ec9eb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The stairmaster is a exercise machine exercise that primarily targets the calves and to a lesser degree also targets the abs, glutes, hamstrings and quads. The only stairmaster equipment that you really need is the following: stairmaster.", "calves.png", null, "StairMaster" },
                    { new Guid("a15d82fe-27d1-4bb2-b3af-d835a80233c2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The glute-ham raise is a exercise machine exercise that primarily targets the hamstrings and to a lesser degree also targets the calves, glutes and lower back. The only glute-ham raise equipment that you really need is the following: glute ham raise machine.", "hamstrings.png", null, "Glute-Ham Raise" },
                    { new Guid("a18792fd-0f67-402f-a220-64bbbeb20c9c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The renegade row is a free weights exercise that primarily targets the middle back and to a lesser degree also targets the biceps, lats, lower back, shoulders and traps. The only renegade row equipment that you really need is the following: dumbbells and flat bench.", "lat_pulldown.png", null, "Renegade Row" },
                    { new Guid("a27ab89b-f156-4c78-b8bf-e8494556776a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The incline dumbbell bench press is a free weights exercise that primarily targets the chest and to a lesser degree also targets the shoulders and triceps. The only incline dumbbell bench press equipment that you really need is the following: dumbbells and incline bench.", "bench_press.png", null, "Incline Dumbbell Press" },
                    { new Guid("a3dfd135-acc0-4594-a674-7b2ba1cd0740"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The cable flex curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only cable flex curl equipment that you really need is the following: cable machine.", "biceps.png", null, "Cable Flex Curl" },
                    { new Guid("a7edbd70-ac08-403b-8afb-c509eb2a2bb9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The chest-supported dumbbell row is a free weights exercise that primarily targets the middle back and to a lesser degree also targets the biceps, lats, lower back, shoulders and traps. The only chest-supported dumbbell row equipment that you really need is the following: dumbbells and flat bench.", "lat_pulldown.png", null, "Chest-supported Dumbbell Row" },
                    { new Guid("a805dcf0-1107-495f-b48a-c4a9a7a309a6"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The machine press fly or machine fly is a strength training exercise similar in movement to the pec deck. It involves squeezing the arms together in front of the body. The difference is, in the pec deck, the force is perpendicular to the body, while in the machine fly the force is horizontal to the body.", "bench_press.png", null, "Machine Press Fly" }
                });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "CreationTime", "CreatorId", "Description", "Icon", "LastModifiedTime", "Name" },
                values: new object[,]
                {
                    { new Guid("aa7f560e-e0a1-49f0-b984-0c11789da339"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The dumbbell overhead triceps extension is a free weights exercise that primarily targets the triceps and to a lesser degree also targets the chest and shoulders. The only dumbbell overhead triceps extension equipment that you really need is the following: dumbbells and flat bench.", "triceps.png", null, "Dumbbell Overhead Triceps Extension" },
                    { new Guid("aee7b10c-6735-4bad-ba71-5c6f765b2315"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The concentration curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only concentration curl equipment that you really need is the following: dumbbell.", "biceps.png", null, "Concentration Curl" },
                    { new Guid("b2295459-2e23-42d3-b0ac-5a4e1ccfc34f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The cable push-down is a strength training exercise that primarily targets the triceps and to a lesser degree also targets the chest and shoulders. The only cable push-down equipment that you really need is the following: cable machine and v-bar attachment.", "triceps.png", null, "Cable Push-Down" },
                    { new Guid("b28b0139-97f4-4b4e-819c-a547acfeffd9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The leant-forward ez bar curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only leant-forward ez bar curl equipment that you really need is the following: ez curl bar.", "biceps.png", null, "Leant-Forward EZ Bar Curl" },
                    { new Guid("b2dc60ee-3081-41a9-ae97-13b5e33c1851"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The dumbbell bent-over lateral raise is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the abs, forearms, traps and triceps. The only dumbbell bent-over lateral raise equipment that you really need is the following: dumbbells.", "shoulders.png", null, "Dumbbell Bent-Over Lateral Raise" },
                    { new Guid("b483d95a-1f0e-470d-8041-459b7b87249f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The diagonal walking lunges is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only diagonal walking lunges equipment that you really need is the following: dumbbells.", "quads.png", null, "Diagonal Walking Lunges" },
                    { new Guid("b568d091-d186-4fe2-ba4d-d969083ab578"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The twisting dumbbell curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only twisting dumbbell curl equipment that you really need is the following: dumbbells.", "biceps.png", null, "Twisting Dumbbell Curl" },
                    { new Guid("b8e56ae9-b150-462b-8aba-d470f028c8e9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The crunch is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and neck. The only crunch equipment that you really need is the following: exercise mat.", "abs.png", null, "Crunch" },
                    { new Guid("bb5b2bc4-2211-4305-9452-6f74433d79cc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The flutter kicks is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and lower back. The only flutter kicks equipment that you really need is the following: exercise mat.", "abs.png", null, "Flutter kicks" },
                    { new Guid("c170a62d-92d4-4add-af67-e187b05b4229"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The diamond push-ups is a bodyweight exercise that primarily targets the triceps and to a lesser degree also targets the chest and shoulders. The only diamond push-ups equipment that you really need is the following: no equipment.", "triceps.png", null, "Diamond Push-Ups" },
                    { new Guid("c3885d6c-006c-4364-bbc7-e567134f73b1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The close-grip bench press is a free weights exercise that primarily targets the triceps and to a lesser degree also targets the chest and shoulders. The only close-grip bench press equipment that you really need is the following: barbell and flat bench.", "triceps.png", null, "Close-Grip Bench Press" },
                    { new Guid("c4a89133-8a91-48e7-b043-d8c8fd783ca8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The weighted jump squat is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only weighted jump squat equipment that you really need is the following: dumbbells.", "quads.png", null, "Weighted Jump Squat" },
                    { new Guid("c6a946f0-3f3d-4e80-9f31-3bd7383284f8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The deadlift is a free weights exercise that primarily targets the hamstrings and to a lesser degree also targets the calves, glutes, lower back and quads. The only deadlift equipment that you really need is the following: barbell.", "quads.png", null, "Deadlift" },
                    { new Guid("c9ba7856-3d99-440d-8b8a-ada71909d01a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The tricep dips is a bodyweight exercise that primarily targets the triceps and to a lesser degree also targets the chest and shoulders. The only tricep dips equipment that you really need is the following: dip station.", "triceps.png", null, "Tricep Dips" },
                    { new Guid("ca130d88-b599-4666-801e-ea0ca9fcbac6"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The seated calf raise machine is a exercise machine exercise that primarily targets the calves and to a lesser degree also targets the abs, glutes and hamstrings. The only seated calf raise machine equipment that you really need is the following: calf raise machine.", "calves.png", null, "Seated Calf Raise Machine" },
                    { new Guid("cbe98622-7cea-4441-89d8-1b8e8f3a33d9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The bird-dog is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and lower back. The only bird-dog equipment that you really need is the following: exercise mat.", "abs.png", null, "Bird-dog" },
                    { new Guid("cc554656-9474-41b0-bdf0-ba87ae64ddaa"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The pull-up is a bodyweight exercise that primarily targets the lats and to a lesser degree also targets the abs, biceps, forearms, lower back, middle back, shoulders and traps. The only pull-up equipment that you really need is the following: pull-up bar.", "lat_pulldown.png", null, "Pull-Up" },
                    { new Guid("cca91fc4-be7d-40b1-954c-651f3029ea23"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The glute bridge is a free weights exercise that primarily targets the hamstrings and to a lesser degree also targets the calves, glutes and lower back. The only glute bridge equipment that you really need is the following: dumbbells.", "hamstrings.png", null, "Glute Bridge" },
                    { new Guid("ce84a4e7-f816-4ba9-b31a-9c2240481f98"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The cable rope tricep pushdown is a strength training exercise that primarily targets the triceps and to a lesser degree also targets the chest and shoulders. The only cable rope tricep pushdown equipment that you really need is the following: cable machine and rope attachment.", "triceps.png", null, "Cable Rope Tricep Pushdown" },
                    { new Guid("cf5650ac-35d5-4724-bd58-3da41f604f53"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The incline cable fly or incline cable flye is a strength training exercise similar in movement to the incline dumbbell fly. It involves squeezing the arms together in front of the body. The difference is, in the incline dumbbell fly, the force is perpendicular to the body, while in the incline cable fly the force is horizontal to the body.", "bench_press.png", null, "Incline Cable Press Fly" },
                    { new Guid("cf60d530-6af5-416c-af3f-acfe50429b93"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The zottman curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only zottman curl equipment that you really need is the following: dumbbells.", "biceps.png", null, "Zottman Curl" },
                    { new Guid("d040e133-ef3c-4065-99e5-32d7e3f0e143"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The walking lunge is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only walking lunge equipment that you really need is the following: dumbbells.", "quads.png", null, "Walking Lunge" },
                    { new Guid("d080e802-3f3d-4db2-80d4-4a4ad612346a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The pushup is a bodyweight exercise that primarily targets the chest and to a lesser degree also targets the abs, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, neck, outer thighs, quads, shoulders and triceps. The only pushup equipment that you really need is the following: exercise mat.", "traps.png", null, "Pushup" },
                    { new Guid("d48d5b1f-2dea-4746-901d-626e35eaf0b2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The barbell romanian deadlift is a free weights exercise that primarily targets the hamstrings and to a lesser degree also targets the calves, glutes and lower back. The only barbell romanian deadlift equipment that you really need is the following: barbell.", "hamstrings.png", null, "Barbell Romanian Deadlift" },
                    { new Guid("d632f6f2-8222-4439-8d93-95287e32b27d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The decline cable fly or decline cable flye is a strength training exercise similar in movement to the decline dumbbell fly. It involves squeezing the arms together in front of the body. The difference is, in the decline dumbbell fly, the force is perpendicular to the body, while in the decline cable fly the force is horizontal to the body.", "bench_press.png", null, "Decline Cable Press Fly" },
                    { new Guid("d8988489-127f-48ed-8eef-8f4647902d6a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The face pull is a free weights exercise that primarily targets the traps and to a lesser degree also targets the abs, biceps, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, neck, obliques, outer thighs, quads, shoulders and triceps. The only face pull equipment that you really need is the following: cable machine.", "traps.png", null, "Face Pull" },
                    { new Guid("dc397353-0f76-4ed3-ab38-09c7b32b8a0d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The jumping jack is a calisthenics and cardiovascular exercise that primarily targets the calves and to a lesser degree also targets the abs, biceps, chest, forearms, glutes, groin, hamstrings, hip flexors, lats, lower back, middle back, obliques, quads, shoulders, traps and triceps.", "calves.png", null, "Jumping Jack" },
                    { new Guid("df907775-9d95-4696-82b7-da69f153d999"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The cable overhead extension with rope is a strength training exercise that primarily targets the triceps and to a lesser degree also targets the chest and shoulders. The only cable overhead extension with rope equipment that you really need is the following: cable machine and rope attachment.", "triceps.png", null, "Cable Overhead Extension With Rope" },
                    { new Guid("e3fd54be-b20f-48c7-b45b-26698eaf1aed"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The seated dumbbell clean is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the abs, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, quads, traps and triceps. The only seated dumbbell clean equipment that you really need is the following: dumbbells and flat bench.", "shoulders.png", null, "Seated Dumbbell Clean" },
                    { new Guid("e4011c6b-1f9d-44a7-9bea-e8c02f831f6a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The medicine ball crunch is a medicine ball exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and lower back. The only medicine ball crunch equipment that you really need is the following: medicine ball.", "abs.png", null, "Medicine ball crunch" },
                    { new Guid("e5cb47e5-e6d7-4b47-a151-6b5aa8859b87"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The single-leg romanian deadlift is a free weights exercise that primarily targets the hamstrings and to a lesser degree also targets the calves, glutes and lower back. The only single-leg romanian deadlift equipment that you really need is the following: dumbbells.", "hamstrings.png", null, "Single-leg Romanian Deadlift" },
                    { new Guid("e5e54732-2c8c-49c0-807e-7250e7bcba61"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The goblet squat is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and lower back. The only goblet squat equipment that you really need is the following: dumbbell.", "quads.png", null, "Goblet Squat" },
                    { new Guid("e82aa0af-f44f-4ee8-9377-37161b2e7f84"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The t-bar row is a free weights exercise that primarily targets the middle back and to a lesser degree also targets the biceps, lats, lower back, shoulders and traps. The only t-bar row equipment that you really need is the following: t-bar row machine and v-handle attachment.", "lat_pulldown.png", null, "T-Bar Row" },
                    { new Guid("e964cb54-9db0-4daa-9c16-11088ee540b4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The upright row is a free weights exercise that primarily targets the traps and to a lesser degree also targets the abs, biceps, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, neck, obliques, outer thighs, quads, shoulders and triceps. The only upright row equipment that you really need is the following: barbell.", "traps.png", null, "Upright row" },
                    { new Guid("e9fc6a89-e150-413f-ae34-d12cf9bf959c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The reverse curl straight bar is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only reverse curl straight bar equipment that you really need is the following: barbell.", "biceps.png", null, "Reverse Curl Straight Bar" },
                    { new Guid("ea1fc057-214b-467f-9520-f7dbfc413dca"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The standing cable curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only standing cable curl equipment that you really need is the following: cable machine.", "biceps.png", null, "Standing Cable Curl" },
                    { new Guid("ea852495-1b16-4c3f-a959-3069b59504ad"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The bosu ball squat is a exercise machine and calisthenics exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only bosu ball squat equipment that you really need is the following: bosu ball.", "calves.png", null, "Bosu Ball Squat" },
                    { new Guid("ed2af66f-4b71-411e-b74c-2de2289c445e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The pullup shrug is a bodyweight exercise that primarily targets the traps and to a lesser degree also targets the abs, biceps, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, neck, obliques, outer thighs, quads, shoulders and triceps. The only pullup shrug equipment that you really need is the following: pull-up bar.", "traps.png", null, "Pullup Shrug" },
                    { new Guid("eda89959-365a-4654-8e16-93c88a294ecf"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The walking lunges is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only walking lunges equipment that you really need is the following: dumbbells.", "hamstrings.png", null, "Walking Lunges" },
                    { new Guid("ef658f61-89f9-4fbd-978a-fbb04816ba90"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The dead bug is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and lower back. The only dead bug equipment that you really need is the following: exercise mat.", "abs.png", null, "Dead bug" },
                    { new Guid("efda50f0-c8ca-4374-a293-eb2133dde702"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The dumbbell fly or dumbbell flye is a strength training exercise similar in movement to a cable fly. It involves squeezing the arms together in front of the body. The difference is, in the dumbbell fly, the force is perpendicular to the body, while in the cable fly the force is horizontal to the body.", "bench_press.png", null, "Dumbbell Press Fly" },
                    { new Guid("f2b08f97-bdaa-40e7-baa2-8d18db3cd461"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The reverse pec deck fly is a exercise machine exercise that primarily targets the shoulders and to a lesser degree also targets the abs, forearms, traps and triceps. The only reverse pec deck fly equipment that you really need is the following: pec deck machine.", "shoulders.png", null, "Reverse Pec Deck Fly" }
                });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "CreationTime", "CreatorId", "Description", "Icon", "LastModifiedTime", "Name" },
                values: new object[,]
                {
                    { new Guid("f63852f7-c89a-4d58-877e-9e7a55699433"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The barbell front squat is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and lower back. The only barbell front squat equipment that you really need is the following: barbell.", "quads.png", null, "Barbell Front Squat" },
                    { new Guid("f7916c6c-28d0-4a3c-ab63-143d4f4ff9bc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The cable or band pull-through is a exercise machine and alternative exercise that primarily targets the hamstrings and to a lesser degree also targets the calves, glutes and lower back.", "hamstrings.png", null, "Cable or Band Pull-through" },
                    { new Guid("fa2a8734-f9ec-4e63-b479-d24c83effd91"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The high pull is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the biceps, calves, forearms, hamstrings, lats, lower back, middle back, quads, traps and triceps. The only high pull equipment that you really need is the following: barbell.", "shoulders.png", null, "High Pull" },
                    { new Guid("fabeb515-0522-4847-be09-ea2885433503"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The abs roll-out is a exercise machine and pilates exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and lower back. The only abs roll-out equipment that you really need is the following: ab roller.", "abs.png", null, "Abs roll-out" },
                    { new Guid("fbb54ed4-b461-40de-870f-2ee5852d64b6"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The sprints is a cardio exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only sprints equipment that you really need is the following: track.", "quads.png", null, "Sprints" },
                    { new Guid("fc520a8f-5da6-4a6b-bb94-f42c90ef4bff"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The hill runs is a cardiovascular and calisthenics exercise that primarily targets the calves and to a lesser degree also targets the abs, glutes, hamstrings, hip flexors, lower back, quads and traps.", "calves.png", null, "Hill Runs" },
                    { new Guid("fc65f0ac-9228-445c-a612-bc97c5916dd7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The incline dumbbell curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only incline dumbbell curl equipment that you really need is the following: dumbbells and incline bench.", "biceps.png", null, "Incline Dumbbell Curl" },
                    { new Guid("fd04852c-b3a4-4440-9e1a-2c661b03d871"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The prone dumbbell spider curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only prone dumbbell spider curl equipment that you really need is the following: dumbbells and incline bench.", "biceps.png", null, "Prone Dumbbell Spider Curl" },
                    { new Guid("fd1e1c7e-c047-4926-bc00-2a472233d0a2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The bench press is an upper-body weight training exercise in which the trainee presses a weight upwards while lying on a weight training bench. The exercise uses the pectoralis major, the anterior deltoids, and the triceps, among other stabilizing muscles.", "bench_press.png", null, "Bench Press" },
                    { new Guid("fe1e490d-1b49-4352-9f50-c33aba3af1d3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The deadlift is a free weights exercise that primarily targets the lower back and to a lesser degree also targets the abs, glutes, hamstrings and quads. The only deadlift equipment that you really need is the following: barbell.", "lat_pulldown.png", null, "Deadlift" },
                    { new Guid("ff9a1cf7-7f43-4d04-bf8d-cc4b29de0399"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "The dumbbell snatch is a free weights exercise that primarily targets the traps and to a lesser degree also targets the abs, biceps, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, neck, obliques, outer thighs, quads, shoulders and triceps. The only dumbbell snatch equipment that you really need is the following: dumbbells.", "traps.png", null, "Dumbbell Snatch" }
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
                name: "IX_Exercises_ExerciseTypeId",
                table: "Exercises",
                column: "ExerciseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_WorkoutId",
                table: "Exercises",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypes_CreatorId",
                table: "ExerciseTypes",
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
                name: "Macro");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ExerciseTypes");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
