using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mayon.Application.Migrations;
/// <inheritdoc />
public partial class ChangeNullable : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "SecretKey",
            table: "DuoApiAuths",
            type: "nvarchar(64)",
            maxLength: 64,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(64)",
            oldMaxLength: 64,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "IntegrationKey",
            table: "DuoApiAuths",
            type: "nvarchar(64)",
            maxLength: 64,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(64)",
            oldMaxLength: 64,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ApiHostname",
            table: "DuoApiAuths",
            type: "nvarchar(96)",
            maxLength: 96,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(96)",
            oldMaxLength: 96,
            oldNullable: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "SecretKey",
            table: "DuoApiAuths",
            type: "nvarchar(64)",
            maxLength: 64,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(64)",
            oldMaxLength: 64);

        migrationBuilder.AlterColumn<string>(
            name: "IntegrationKey",
            table: "DuoApiAuths",
            type: "nvarchar(64)",
            maxLength: 64,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(64)",
            oldMaxLength: 64);

        migrationBuilder.AlterColumn<string>(
            name: "ApiHostname",
            table: "DuoApiAuths",
            type: "nvarchar(96)",
            maxLength: 96,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(96)",
            oldMaxLength: 96);
    }
}