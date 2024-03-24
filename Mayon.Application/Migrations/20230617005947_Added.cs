﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mayon.Application.Migrations;
/// <inheritdoc />
public partial class Added : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "MsRefreshToken",
            table: "adminMsApiAuths",
            type: "nvarchar(64)",
            maxLength: 64,
            nullable: false,
            defaultValue: "");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "MsRefreshToken",
            table: "adminMsApiAuths");
    }
}