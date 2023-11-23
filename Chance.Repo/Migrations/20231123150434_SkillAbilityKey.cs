using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chance.Repo.Migrations
{
    /// <inheritdoc />
    public partial class SkillAbilityKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 0,
                column: "AbilityId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 1,
                column: "AbilityId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 2,
                column: "AbilityId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 4,
                column: "AbilityId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 5,
                column: "AbilityId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 6,
                column: "AbilityId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 7,
                column: "AbilityId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 8,
                column: "AbilityId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 9,
                column: "AbilityId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 10,
                column: "AbilityId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 11,
                column: "AbilityId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 12,
                column: "AbilityId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 13,
                column: "AbilityId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 14,
                column: "AbilityId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 15,
                column: "AbilityId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 16,
                column: "AbilityId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 17,
                column: "AbilityId",
                value: 4);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 0,
                column: "AbilityId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 1,
                column: "AbilityId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 2,
                column: "AbilityId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 4,
                column: "AbilityId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 5,
                column: "AbilityId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 6,
                column: "AbilityId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 7,
                column: "AbilityId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 8,
                column: "AbilityId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 9,
                column: "AbilityId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 10,
                column: "AbilityId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 11,
                column: "AbilityId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 12,
                column: "AbilityId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 13,
                column: "AbilityId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 14,
                column: "AbilityId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 15,
                column: "AbilityId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 16,
                column: "AbilityId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillType",
                keyValue: 17,
                column: "AbilityId",
                value: 0);
        }
    }
}
