using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedOneToManyLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KeyWordId",
                table: "Results",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "KeyWord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Word = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyWord", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Results_KeyWordId",
                table: "Results",
                column: "KeyWordId");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_KeyWord_KeyWordId",
                table: "Results",
                column: "KeyWordId",
                principalTable: "KeyWord",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_KeyWord_KeyWordId",
                table: "Results");

            migrationBuilder.DropTable(
                name: "KeyWord");

            migrationBuilder.DropIndex(
                name: "IX_Results_KeyWordId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "KeyWordId",
                table: "Results");
        }
    }
}
