using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace REMindAP.Data.Migrations
{
    public partial class SeedTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Tags (Title) VALUES ('Tag1')");
            migrationBuilder.Sql("INSERT INTO Tags (Title, Color) VALUES ('Tag2', 'ff0000')");
            migrationBuilder.Sql("INSERT INTO Tags (Title, Color) VALUES ('Tag3', '0000ff')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Tags WHERE Title IN ('Tag1', 'Tag2','Tag3')");
        }
    }
}
