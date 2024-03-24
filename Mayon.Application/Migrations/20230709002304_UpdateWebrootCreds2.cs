using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mayon.Application.Migrations;
/// <inheritdoc />
public partial class UpdateWebrootCreds2 : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "ClientSecretSalt",
            table: "WebrootCredentials");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<byte[]>(
            name: "ClientSecretSalt",
            table: "WebrootCredentials",
            type: "varbinary(128)",
            maxLength: 128,
            nullable: false,
            defaultValue: new byte[0]);
    }
}