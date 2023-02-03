using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Linhkiendientu_aspnetmvc.Migrations
{
    public partial class changeTableOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>("StaffId", "Orders", "int");
            migrationBuilder.CreateIndex(
                 name: "IX_Order_StaffId",
                 table: "Orders",
                 column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_StaffId",
                table: "Orders",
                column: "StaffId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Order_StaffId",
                table: "Orders"
            );
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_StaffId",
                table: "Orders"
            );
        }
    }
}
