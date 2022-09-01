using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bank.Data.Migrations
{
    public partial class InitialMigration9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCheckconfirmation",
                table: "AccountTransaction");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CompletionTime",
                table: "Deposit",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompletion",
                table: "Deposit",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompletion",
                table: "Deposit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CompletionTime",
                table: "Deposit",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCheckconfirmation",
                table: "AccountTransaction",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
