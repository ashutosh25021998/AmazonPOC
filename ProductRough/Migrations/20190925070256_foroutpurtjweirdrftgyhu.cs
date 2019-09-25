using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductRough.Migrations
{
    public partial class foroutpurtjweirdrftgyhu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OperatorId",
                table: "Carts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductItemId",
                table: "Carts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_OperatorId",
                table: "Carts",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ProductItemId",
                table: "Carts",
                column: "ProductItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Operators_OperatorId",
                table: "Carts",
                column: "OperatorId",
                principalTable: "Operators",
                principalColumn: "OperatorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_ProductItemes_ProductItemId",
                table: "Carts",
                column: "ProductItemId",
                principalTable: "ProductItemes",
                principalColumn: "ProductItemId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Operators_OperatorId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_ProductItemes_ProductItemId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_OperatorId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_ProductItemId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "OperatorId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "ProductItemId",
                table: "Carts");
        }
    }
}
