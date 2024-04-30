using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Server.Migrations
{
    /// <inheritdoc />
    public partial class DropProductsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_product_ProductId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_product_ProductID",
                table: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItems_ProductID",
                table: "ShoppingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "OrderItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProductID",
                table: "ShoppingCartItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ShoppingCartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "OrderItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    p_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    p_desc = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    p_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    p_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.p_id);
                    table.ForeignKey(
                        name: "FK_product_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ProductID",
                table: "ShoppingCartItems",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_product_OrderId",
                table: "product",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_product_ProductId",
                table: "OrderItems",
                column: "ProductId",
                principalTable: "product",
                principalColumn: "p_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_product_ProductID",
                table: "ShoppingCartItems",
                column: "ProductID",
                principalTable: "product",
                principalColumn: "p_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
