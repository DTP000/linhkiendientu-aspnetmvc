using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Linhkiendientu_aspnetmvc.Migrations
{
    public partial class changeColumnAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Default",
                table: "Addresses",
                newName: "IsDefault");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDefault",
                table: "Addresses",
                newName: "Default");
        }
    }
}
