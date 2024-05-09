using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Server.Migrations
{
	/// <inheritdoc />
	public partial class Initial3 : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_bill_product",
				table: "bill");

			migrationBuilder.DropForeignKey(
				name: "FK_order_product_p_id",
				table: "order");



			migrationBuilder.AddColumn<int>(
				name: "ProductPId",
				table: "order",
				type: "int",
				nullable: true);

			migrationBuilder.AddColumn<int>(
				name: "ProductPId",
				table: "bill",
				type: "int",
				nullable: true);

			migrationBuilder.CreateIndex(
				name: "IX_order_ProductPId",
				table: "order",
				column: "ProductPId");

			migrationBuilder.CreateIndex(
				name: "IX_bill_ProductPId",
				table: "bill",
				column: "ProductPId");

			migrationBuilder.AddForeignKey(
				name: "FK_bill_product_ProductPId",
				table: "bill",
				column: "ProductPId",
				principalTable: "product",
				principalColumn: "p_id");

			migrationBuilder.AddForeignKey(
				name: "FK_order_product_ProductPId",
				table: "order",
				column: "ProductPId",
				principalTable: "product",
				principalColumn: "p_id");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_bill_product_ProductPId",
				table: "bill");

			migrationBuilder.DropForeignKey(
				name: "FK_order_product_ProductPId",
				table: "order");

			migrationBuilder.DropIndex(
				name: "IX_order_ProductPId",
				table: "order");

			migrationBuilder.DropIndex(
				name: "IX_bill_ProductPId",
				table: "bill");

			migrationBuilder.DropColumn(
				name: "ProductPId",
				table: "order");

			migrationBuilder.DropColumn(
				name: "ProductPId",
				table: "bill");

			migrationBuilder.CreateIndex(
				name: "IX_order_p_id",
				table: "order",
				column: "p_id");

			migrationBuilder.CreateIndex(
				name: "IX_bill_p_id",
				table: "bill",
				column: "p_id");

			migrationBuilder.AddForeignKey(
				name: "FK_bill_product",
				table: "bill",
				column: "p_id",
				principalTable: "product",
				principalColumn: "p_id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_order_product_p_id",
				table: "order",
				column: "p_id",
				principalTable: "product",
				principalColumn: "p_id",
				onDelete: ReferentialAction.Cascade);
		}
	}
}
