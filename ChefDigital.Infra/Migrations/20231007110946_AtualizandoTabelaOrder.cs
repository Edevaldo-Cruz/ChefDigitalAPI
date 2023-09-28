using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChefDigital.Infra.Migrations
{
    public partial class AtualizandoTabelaOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "AspNetUsers",
                newName: "Type");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "AspNetUsers",
                newName: "Tipo");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
