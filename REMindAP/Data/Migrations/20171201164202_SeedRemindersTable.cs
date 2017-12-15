using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace REMindAP.Data.Migrations
{
    public partial class SeedRemindersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Reminders (Title, ShortDescription, EventDate, IsRepeatable) " +
                                 "VALUES ('Reminder1', 'Description1', '01-01-2018', 0)");

            migrationBuilder.Sql("INSERT INTO Reminders (Title, ShortDescription, EventDate, IsRepeatable) " +
                                 "VALUES ('Reminder2', 'Description2', '01-01-2018', 0)");

            migrationBuilder.Sql("INSERT INTO Reminders (Title, ShortDescription, EventDate, IsRepeatable) " +
                                 "VALUES ('Reminder3', 'Description3', '01-01-2018', 0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Tags WHERE Title IN ('Reminder1','Reminder2','Reminder3')");
        }
    }
}
