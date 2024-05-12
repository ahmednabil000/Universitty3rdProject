﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Server.Migrations
{
    /// <inheritdoc />
    public partial class ChangingProductSaleColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "SaleRate",
                table: "ProductSales",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SaleRate",
                table: "ProductSales");
        }
    }
}
