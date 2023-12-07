using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chance.Repo.Migrations
{
    /// <inheritdoc />
    public partial class GenericClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "Title");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Username",
                table: "Users",
                newName: "IX_Users_Title");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Characters",
                newName: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Title",
                table: "Users",
                newName: "IX_Users_Username");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Characters",
                newName: "Name");
        }
    }
}
