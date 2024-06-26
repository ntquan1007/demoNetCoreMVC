using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItem_Orders_OrderId",
                table: "LineItem");

            migrationBuilder.DropForeignKey(
                name: "FK_LineItem_Products_ProductId",
                table: "LineItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LineItem",
                table: "LineItem");

            migrationBuilder.RenameTable(
                name: "LineItem",
                newName: "LineItems");

            migrationBuilder.RenameIndex(
                name: "IX_LineItem_ProductId",
                table: "LineItems",
                newName: "IX_LineItems_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_LineItem_OrderId",
                table: "LineItems",
                newName: "IX_LineItems_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LineItems",
                table: "LineItems",
                column: "LineItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Orders_OrderId",
                table: "LineItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Products_ProductId",
                table: "LineItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Orders_OrderId",
                table: "LineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Products_ProductId",
                table: "LineItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LineItems",
                table: "LineItems");

            migrationBuilder.RenameTable(
                name: "LineItems",
                newName: "LineItem");

            migrationBuilder.RenameIndex(
                name: "IX_LineItems_ProductId",
                table: "LineItem",
                newName: "IX_LineItem_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_LineItems_OrderId",
                table: "LineItem",
                newName: "IX_LineItem_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LineItem",
                table: "LineItem",
                column: "LineItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_LineItem_Orders_OrderId",
                table: "LineItem",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LineItem_Products_ProductId",
                table: "LineItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
