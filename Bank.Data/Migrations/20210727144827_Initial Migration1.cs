using Microsoft.EntityFrameworkCore.Migrations;

namespace Bank.Data.Migrations
{
    public partial class InitialMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComissionAmount",
                table: "CommissionCases",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComissionAmount",
                table: "CommissionCases");
        }
    }
}
