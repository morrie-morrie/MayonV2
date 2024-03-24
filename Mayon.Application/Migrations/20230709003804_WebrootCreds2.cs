using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mayon.Application.Migrations;
/// <inheritdoc />
public partial class WebrootCreds2 : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<byte[]>(
            name: "ClientSecretIV",
            table: "WebrootCredentials",
            type: "varbinary(16)",
            maxLength: 16,
            nullable: false,
            defaultValue: new byte[0]);

        migrationBuilder.AddColumn<byte[]>(
            name: "ClientSecretKey",
            table: "WebrootCredentials",
            type: "varbinary(128)",
            maxLength: 128,
            nullable: false,
            defaultValue: new byte[0]);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "ClientSecretIV",
            table: "WebrootCredentials");

        migrationBuilder.DropColumn(
            name: "ClientSecretKey",
            table: "WebrootCredentials");
    }
}