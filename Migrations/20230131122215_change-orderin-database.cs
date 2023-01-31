using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Linhkiendientu_aspnetmvc.Migrations
{
    public partial class changeorderindatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderIns_Users_UserId",
                table: "OrderIns");

            migrationBuilder.DropIndex(
                name: "IX_OrderIns_UserId",
                table: "OrderIns");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OrderIns");

            migrationBuilder.CreateIndex(
                name: "IX_OrderIns_StaffId",
                table: "OrderIns",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderIns_Users_StaffId",
                table: "OrderIns",
                column: "StaffId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderIns_Users_StaffId",
                table: "OrderIns");

            migrationBuilder.DropIndex(
                name: "IX_OrderIns_StaffId",
                table: "OrderIns");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "OrderIns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderIns_UserId",
                table: "OrderIns",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderIns_Users_UserId",
                table: "OrderIns",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
