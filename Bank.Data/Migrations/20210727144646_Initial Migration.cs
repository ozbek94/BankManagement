using Microsoft.EntityFrameworkCore.Migrations;

namespace Bank.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "CommissionCases",
                newName: "Balance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "CommissionCases",
                newName: "Amount");
        }
    }
}
