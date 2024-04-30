using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Server.Migrations
{
    /// <inheritdoc />
    public partial class DropCustomerTableAndBillTableAndCreatingOrderItemsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_customer_CustomerCId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "bill");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerCId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerCId",
                table: "Orders");

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "p_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.AddColumn<int>(
                name: "CustomerCId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    c_id = table.Column<int>(type: "int", nullable: false),
                    c_name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    password = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    re_password = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.c_id);
                });

            migrationBuilder.CreateTable(
                name: "bill",
                columns: table => new
                {
                    B_id = table.Column<int>(type: "int", nullable: false),
                    c_id = table.Column<int>(type: "int", nullable: true),
                    ProductPId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    c_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    p_id = table.Column<int>(type: "int", nullable: true),
                    p_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bill", x => x.B_id);
                    table.ForeignKey(
                        name: "FK_bill_customer",
                        column: x => x.c_id,
                        principalTable: "customer",
                        principalColumn: "c_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bill_product_ProductPId",
                        column: x => x.ProductPId,
                        principalTable: "product",
                        principalColumn: "p_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerCId",
                table: "Orders",
                column: "CustomerCId");

            migrationBuilder.CreateIndex(
                name: "IX_bill_c_id",
                table: "bill",
                column: "c_id");

            migrationBuilder.CreateIndex(
                name: "IX_bill_ProductPId",
                table: "bill",
                column: "ProductPId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_customer_CustomerCId",
                table: "Orders",
                column: "CustomerCId",
                principalTable: "customer",
                principalColumn: "c_id");
        }
    }
}
