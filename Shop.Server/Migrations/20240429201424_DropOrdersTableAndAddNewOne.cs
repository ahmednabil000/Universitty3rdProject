using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Server.Migrations
{
    /// <inheritdoc />
    public partial class DropOrdersTableAndAddNewOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "product",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CustomerCId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_customer_CustomerCId",
                        column: x => x.CustomerCId,
                        principalTable: "customer",
                        principalColumn: "c_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_OrderId",
                table: "product",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerCId",
                table: "Orders",
                column: "CustomerCId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId1",
                table: "Orders",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_product_Orders_OrderId",
                table: "product",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_Orders_OrderId",
                table: "product");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_product_OrderId",
                table: "product");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "product");

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    o_id = table.Column<int>(type: "int", nullable: false),
                    c_id = table.Column<int>(type: "int", nullable: true),
                    ProductPId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    c_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    p_id = table.Column<int>(type: "int", nullable: true),
                    p_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.o_id);
                    table.ForeignKey(
                        name: "FK_order_customer_c_id",
                        column: x => x.c_id,
                        principalTable: "customer",
                        principalColumn: "c_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_product_ProductPId",
                        column: x => x.ProductPId,
                        principalTable: "product",
                        principalColumn: "p_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_order_c_id",
                table: "order",
                column: "c_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_ProductPId",
                table: "order",
                column: "ProductPId");
        }
    }
}
