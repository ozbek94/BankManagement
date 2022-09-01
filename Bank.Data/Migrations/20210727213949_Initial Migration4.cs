using Microsoft.EntityFrameworkCore.Migrations;

namespace Bank.Data.Migrations
{
    public partial class InitialMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "CommissionCases");

            migrationBuilder.AddColumn<string>(
                name: "ComissionTypeName",
                table: "CommissionCases",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComissionTypeName",
                table: "CommissionCases");

            migrationBuilder.AddColumn<int>(
                name: "Balance",
                table: "CommissionCases",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
