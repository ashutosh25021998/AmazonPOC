using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductRough.Migrations
{
    public partial class foroutpurtjwei : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Operators_OperatorId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_OperatorId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "OperatorId",
                table: "Suppliers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OperatorId",
                table: "Suppliers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_OperatorId",
                table: "Suppliers",
                column: "OperatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Operators_OperatorId",
                table: "Suppliers",
                column: "OperatorId",
                principalTable: "Operators",
                principalColumn: "OperatorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
