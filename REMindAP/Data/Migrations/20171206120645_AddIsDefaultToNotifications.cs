using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace REMindAP.Data.Migrations
{
    public partial class AddIsDefaultToNotifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Notification",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Notification");
        }
    }
}
