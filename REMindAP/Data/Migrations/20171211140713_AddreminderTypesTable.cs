using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace REMindAP.Data.Migrations
{
    public partial class AddreminderTypesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReminderType",
                table: "Reminders",
                newName: "ReminderTypeId");

            migrationBuilder.CreateTable(
                name: "ReminderTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReminderTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reminders_ReminderTypeId",
                table: "Reminders",
                column: "ReminderTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reminders_ReminderTypes_ReminderTypeId",
                table: "Reminders",
                column: "ReminderTypeId",
                principalTable: "ReminderTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reminders_ReminderTypes_ReminderTypeId",
                table: "Reminders");

            migrationBuilder.DropTable(
                name: "ReminderTypes");

            migrationBuilder.DropIndex(
                name: "IX_Reminders_ReminderTypeId",
                table: "Reminders");

            migrationBuilder.RenameColumn(
                name: "ReminderTypeId",
                table: "Reminders",
                newName: "ReminderType");
        }
    }
}
