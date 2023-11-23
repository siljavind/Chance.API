using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Chance.Repo.Migrations
{
    /// <inheritdoc />
    public partial class SkillData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BackgroundSkill_Skills_SkillsId",
                table: "BackgroundSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassSkill_Skills_SkillsId",
                table: "ClassSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Skills");

            migrationBuilder.RenameColumn(
                name: "SkillsId",
                table: "ClassSkill",
                newName: "SkillsSkillType");

            migrationBuilder.RenameIndex(
                name: "IX_ClassSkill_SkillsId",
                table: "ClassSkill",
                newName: "IX_ClassSkill_SkillsSkillType");

            migrationBuilder.RenameColumn(
                name: "SkillsId",
                table: "BackgroundSkill",
                newName: "SkillsSkillType");

            migrationBuilder.RenameIndex(
                name: "IX_BackgroundSkill_SkillsId",
                table: "BackgroundSkill",
                newName: "IX_BackgroundSkill_SkillsSkillType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                column: "SkillType");

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillType", "AbilityId" },
                values: new object[,]
                {
                    { 0, 0 },
                    { 1, 0 },
                    { 2, 0 },
                    { 3, 0 },
                    { 4, 0 },
                    { 5, 0 },
                    { 6, 0 },
                    { 7, 0 },
                    { 8, 0 },
                    { 9, 0 },
                    { 10, 0 },
                    { 11, 0 },
                    { 12, 0 },
                    { 13, 0 },
                    { 14, 0 },
                    { 15, 0 },
                    { 16, 0 },
                    { 17, 0 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BackgroundSkill_Skills_SkillsSkillType",
                table: "BackgroundSkill",
                column: "SkillsSkillType",
                principalTable: "Skills",
                principalColumn: "SkillType");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSkill_Skills_SkillsSkillType",
                table: "ClassSkill",
                column: "SkillsSkillType",
                principalTable: "Skills",
                principalColumn: "SkillType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BackgroundSkill_Skills_SkillsSkillType",
                table: "BackgroundSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassSkill_Skills_SkillsSkillType",
                table: "ClassSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 0);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 17);

            migrationBuilder.RenameColumn(
                name: "SkillsSkillType",
                table: "ClassSkill",
                newName: "SkillsId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassSkill_SkillsSkillType",
                table: "ClassSkill",
                newName: "IX_ClassSkill_SkillsId");

            migrationBuilder.RenameColumn(
                name: "SkillsSkillType",
                table: "BackgroundSkill",
                newName: "SkillsId");

            migrationBuilder.RenameIndex(
                name: "IX_BackgroundSkill_SkillsSkillType",
                table: "BackgroundSkill",
                newName: "IX_BackgroundSkill_SkillsId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Skills",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BackgroundSkill_Skills_SkillsId",
                table: "BackgroundSkill",
                column: "SkillsId",
                principalTable: "Skills",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSkill_Skills_SkillsId",
                table: "ClassSkill",
                column: "SkillsId",
                principalTable: "Skills",
                principalColumn: "Id");
        }
    }
}
