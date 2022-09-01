using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Bank.Data.Migrations
{
    public partial class InitialMigration10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsCompletion",
                table: "Deposit",
                newName: "IsCompleted");

            migrationBuilder.CreateTable(
                name: "Withdraw",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PartyId = table.Column<int>(type: "integer", nullable: false),
                    AccountId = table.Column<int>(type: "integer", nullable: false),
                    CompletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    AccountTransactionId = table.Column<Guid>(type: "uuid", nullable: false),
                    BankName = table.Column<string>(type: "text", nullable: true),
                    BankId = table.Column<int>(type: "integer", nullable: false),
                    IBAN = table.Column<string>(type: "text", nullable: true),
                    InsertTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Withdraw", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Withdraw");

            migrationBuilder.RenameColumn(
                name: "IsCompleted",
                table: "Deposit",
                newName: "IsCompletion");
        }
    }
}
