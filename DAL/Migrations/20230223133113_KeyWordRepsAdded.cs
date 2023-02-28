using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class KeyWordRepsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_KeyWord_KeyWordId",
                table: "Results");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KeyWord",
                table: "KeyWord");

            migrationBuilder.RenameTable(
                name: "KeyWord",
                newName: "KeyWords");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KeyWords",
                table: "KeyWords",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_KeyWords_KeyWordId",
                table: "Results",
                column: "KeyWordId",
                principalTable: "KeyWords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_KeyWords_KeyWordId",
                table: "Results");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KeyWords",
                table: "KeyWords");

            migrationBuilder.RenameTable(
                name: "KeyWords",
                newName: "KeyWord");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KeyWord",
                table: "KeyWord",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_KeyWord_KeyWordId",
                table: "Results",
                column: "KeyWordId",
                principalTable: "KeyWord",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
