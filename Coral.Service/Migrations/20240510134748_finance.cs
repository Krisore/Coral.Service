using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coral.Service.Migrations
{
    /// <inheritdoc />
    public partial class finance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Expenses",
                newName: "Expenses",
                newSchema: "finance");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Expenses",
                schema: "finance",
                newName: "Expenses");
        }
    }
}
