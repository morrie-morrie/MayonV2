﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mayon.Application.Migrations;
/// <inheritdoc />
public partial class DuoCustomers : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "DuoCustomers",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", maxLength: 32, nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                DuoApiHostname = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                DuoCustomerName = table.Column<string>(type: "nvarchar(96)", maxLength: 96, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_DuoCustomers", x => x.Id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "DuoCustomers");
    }
}