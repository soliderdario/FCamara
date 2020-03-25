using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Super.Digital.Data.Migrations
{
    public partial class db02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountEntry",
                table: "AccountEntry");

            migrationBuilder.AddColumn<Guid>(
                name: "AccountEntryId",
                table: "AccountEntry",
                maxLength: 40,
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountEntry",
                table: "AccountEntry",
                column: "AccountEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountEntry_AccountId",
                table: "AccountEntry",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountEntry",
                table: "AccountEntry");

            migrationBuilder.DropIndex(
                name: "IX_AccountEntry_AccountId",
                table: "AccountEntry");

            migrationBuilder.DropColumn(
                name: "AccountEntryId",
                table: "AccountEntry");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountEntry",
                table: "AccountEntry",
                column: "AccountId");
        }
    }
}
