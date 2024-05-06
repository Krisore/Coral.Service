using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coral.Service.Migrations
{
    /// <inheritdoc />
    public partial class TagModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Budgets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_TagId",
                table: "Budgets",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Budgets_Tags_TagId",
                table: "Budgets",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Budgets_Tags_TagId",
                table: "Budgets");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Budgets_TagId",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Budgets");
        }
    }
}
