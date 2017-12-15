using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace REMindAP.Data.Migrations
{
    public partial class SeedReminderTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO ReminderTypes (Type) VALUES ('OneTime')");
            migrationBuilder.Sql("INSERT INTO ReminderTypes (Type) VALUES ('Hourly')");
            migrationBuilder.Sql("INSERT INTO ReminderTypes (Type) VALUES ('Daily')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
