using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bill_customer",
                table: "bill");

            migrationBuilder.DropForeignKey(
                name: "FK_bill_product",
                table: "bill");

            migrationBuilder.DropForeignKey(
                name: "FK_order_customer",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "FK_order_product",
                table: "order");

            migrationBuilder.AddForeignKey(
                name: "FK_bill_customer",
                table: "bill",
                column: "c_id",
                principalTable: "customer",
                principalColumn: "c_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bill_product",
                table: "bill",
                column: "p_id",
                principalTable: "product",
                principalColumn: "p_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_customer_c_id",
                table: "order",
                column: "c_id",
                principalTable: "customer",
                principalColumn: "c_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_product_p_id",
                table: "order",
                column: "p_id",
                principalTable: "product",
                principalColumn: "p_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bill_customer",
                table: "bill");

            migrationBuilder.DropForeignKey(
                name: "FK_bill_product",
                table: "bill");

            migrationBuilder.DropForeignKey(
                name: "FK_order_customer_c_id",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "FK_order_product_p_id",
                table: "order");

            migrationBuilder.AddForeignKey(
                name: "FK_bill_customer",
                table: "bill",
                column: "c_id",
                principalTable: "customer",
                principalColumn: "c_id");

            migrationBuilder.AddForeignKey(
                name: "FK_bill_product",
                table: "bill",
                column: "p_id",
                principalTable: "product",
                principalColumn: "p_id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_customer",
                table: "order",
                column: "c_id",
                principalTable: "customer",
                principalColumn: "c_id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_product",
                table: "order",
                column: "p_id",
                principalTable: "product",
                principalColumn: "p_id");
        }
    }
}
