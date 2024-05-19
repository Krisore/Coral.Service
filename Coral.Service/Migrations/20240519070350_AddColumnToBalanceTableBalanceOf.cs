using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coral.Service.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnToBalanceTableBalanceOf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BalanceAsOf",
                schema: "finance",
                table: "Balances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 19, 15, 3, 50, 51, DateTimeKind.Local).AddTicks(2185));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BalanceAsOf",
                schema: "finance",
                table: "Balances");
        }
    }
}
