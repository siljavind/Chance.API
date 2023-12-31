﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Chance.Repo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Backgrounds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Backgrounds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SkillProficiencyCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    AbilityId = table.Column<int>(type: "int", nullable: false),
                    IncreaseAbilityScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Races_Abilities_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "Abilities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<int>(type: "int", nullable: false),
                    AbilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Abilities_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "Abilities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AbilityClass",
                columns: table => new
                {
                    AbilitiesId = table.Column<int>(type: "int", nullable: false),
                    ClassesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityClass", x => new { x.AbilitiesId, x.ClassesId });
                    table.ForeignKey(
                        name: "FK_AbilityClass_Abilities_AbilitiesId",
                        column: x => x.AbilitiesId,
                        principalTable: "Abilities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbilityClass_Classes_ClassesId",
                        column: x => x.ClassesId,
                        principalTable: "Classes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClassFeature",
                columns: table => new
                {
                    ClassesId = table.Column<int>(type: "int", nullable: false),
                    FeaturesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassFeature", x => new { x.ClassesId, x.FeaturesId });
                    table.ForeignKey(
                        name: "FK_ClassFeature_Classes_ClassesId",
                        column: x => x.ClassesId,
                        principalTable: "Classes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClassFeature_Features_FeaturesId",
                        column: x => x.FeaturesId,
                        principalTable: "Features",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FeatureRace",
                columns: table => new
                {
                    FeaturesId = table.Column<int>(type: "int", nullable: false),
                    RacesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureRace", x => new { x.FeaturesId, x.RacesId });
                    table.ForeignKey(
                        name: "FK_FeatureRace_Features_FeaturesId",
                        column: x => x.FeaturesId,
                        principalTable: "Features",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FeatureRace_Races_RacesId",
                        column: x => x.RacesId,
                        principalTable: "Races",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Subraces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AbilityId = table.Column<int>(type: "int", nullable: false),
                    AbilityScore = table.Column<int>(type: "int", nullable: false),
                    RaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subraces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subraces_Abilities_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "Abilities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Subraces_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BackgroundSkill",
                columns: table => new
                {
                    BackgroundsId = table.Column<int>(type: "int", nullable: false),
                    SkillsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackgroundSkill", x => new { x.BackgroundsId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_BackgroundSkill_Backgrounds_BackgroundsId",
                        column: x => x.BackgroundsId,
                        principalTable: "Backgrounds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BackgroundSkill_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClassSkill",
                columns: table => new
                {
                    ClassesId = table.Column<int>(type: "int", nullable: false),
                    SkillsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSkill", x => new { x.ClassesId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_ClassSkill_Classes_ClassesId",
                        column: x => x.ClassesId,
                        principalTable: "Classes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClassSkill_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Alignment = table.Column<int>(type: "int", nullable: false),
                    XP = table.Column<int>(type: "int", nullable: false),
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    SubraceId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    BackgroundId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Backgrounds_BackgroundId",
                        column: x => x.BackgroundId,
                        principalTable: "Backgrounds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_Subraces_SubraceId",
                        column: x => x.SubraceId,
                        principalTable: "Subraces",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FeatureSubrace",
                columns: table => new
                {
                    FeaturesId = table.Column<int>(type: "int", nullable: false),
                    SubracesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureSubrace", x => new { x.FeaturesId, x.SubracesId });
                    table.ForeignKey(
                        name: "FK_FeatureSubrace_Features_FeaturesId",
                        column: x => x.FeaturesId,
                        principalTable: "Features",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FeatureSubrace_Subraces_SubracesId",
                        column: x => x.SubracesId,
                        principalTable: "Subraces",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AbilityCharacter",
                columns: table => new
                {
                    AbilitiesId = table.Column<int>(type: "int", nullable: false),
                    CharactersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityCharacter", x => new { x.AbilitiesId, x.CharactersId });
                    table.ForeignKey(
                        name: "FK_AbilityCharacter_Abilities_AbilitiesId",
                        column: x => x.AbilitiesId,
                        principalTable: "Abilities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbilityCharacter_Characters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Abilities",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "AbilityId", "Title" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 2, 5, 2 },
                    { 3, 4, 3 },
                    { 4, 1, 4 },
                    { 5, 6, 5 },
                    { 6, 4, 6 },
                    { 7, 5, 7 },
                    { 8, 6, 8 },
                    { 9, 4, 9 },
                    { 10, 5, 10 },
                    { 11, 4, 11 },
                    { 12, 5, 12 },
                    { 13, 6, 13 },
                    { 14, 6, 14 },
                    { 15, 4, 15 },
                    { 16, 2, 16 },
                    { 17, 2, 17 },
                    { 18, 5, 18 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbilityCharacter_CharactersId",
                table: "AbilityCharacter",
                column: "CharactersId");

            migrationBuilder.CreateIndex(
                name: "IX_AbilityClass_ClassesId",
                table: "AbilityClass",
                column: "ClassesId");

            migrationBuilder.CreateIndex(
                name: "IX_Backgrounds_Title",
                table: "Backgrounds",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BackgroundSkill_SkillsId",
                table: "BackgroundSkill",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_BackgroundId",
                table: "Characters",
                column: "BackgroundId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ClassId",
                table: "Characters",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_RaceId",
                table: "Characters",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_SubraceId",
                table: "Characters",
                column: "SubraceId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_UserId",
                table: "Characters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_Title",
                table: "Classes",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClassFeature_FeaturesId",
                table: "ClassFeature",
                column: "FeaturesId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSkill_SkillsId",
                table: "ClassSkill",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_FeatureRace_RacesId",
                table: "FeatureRace",
                column: "RacesId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_Title",
                table: "Features",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FeatureSubrace_SubracesId",
                table: "FeatureSubrace",
                column: "SubracesId");

            migrationBuilder.CreateIndex(
                name: "IX_Races_AbilityId",
                table: "Races",
                column: "AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Races_Title",
                table: "Races",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_AbilityId",
                table: "Skills",
                column: "AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Subraces_AbilityId",
                table: "Subraces",
                column: "AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Subraces_RaceId",
                table: "Subraces",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Subraces_Title",
                table: "Subraces",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbilityCharacter");

            migrationBuilder.DropTable(
                name: "AbilityClass");

            migrationBuilder.DropTable(
                name: "BackgroundSkill");

            migrationBuilder.DropTable(
                name: "ClassFeature");

            migrationBuilder.DropTable(
                name: "ClassSkill");

            migrationBuilder.DropTable(
                name: "FeatureRace");

            migrationBuilder.DropTable(
                name: "FeatureSubrace");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Backgrounds");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Subraces");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "Abilities");
        }
    }
}
