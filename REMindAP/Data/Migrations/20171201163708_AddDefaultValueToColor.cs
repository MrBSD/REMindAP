using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace REMindAP.Data.Migrations
{
    public partial class AddDefaultValueToColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Tags",
                maxLength: 6,
                nullable: true,
                defaultValue: "00ff00",
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Color",
                table: "Tags",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 6,
                oldNullable: true,
                oldDefaultValue: "00ff00");
        }
    }
}
