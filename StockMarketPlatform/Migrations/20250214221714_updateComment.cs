using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockMarketPlatform.Migrations
{
    /// <inheritdoc />
    public partial class updateComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Comments",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Comments");
        }
    }
}
