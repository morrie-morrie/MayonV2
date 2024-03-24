using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mayon.Application.Migrations;
/// <inheritdoc />
public partial class ITGOrgsMakeDescNullable : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "QuickNoteVaultId",
            table: "ITGOrganisations");

        migrationBuilder.AlterColumn<string>(
            name: "description",
            table: "ITGOrganisations",
            type: "nvarchar(1024)",
            maxLength: 1024,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(1024)",
            oldMaxLength: 1024);

        migrationBuilder.AlterColumn<string>(
            name: "alert",
            table: "ITGOrganisations",
            type: "nvarchar(256)",
            maxLength: 256,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(256)",
            oldMaxLength: 256);

        migrationBuilder.AlterColumn<string>(
            name: "ShortName",
            table: "ITGOrganisations",
            type: "nvarchar(32)",
            maxLength: 32,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(32)",
            oldMaxLength: 32);

        migrationBuilder.AlterColumn<string>(
            name: "QuickNotes",
            table: "ITGOrganisations",
            type: "nvarchar(1024)",
            maxLength: 1024,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(1024)",
            oldMaxLength: 1024);

        migrationBuilder.AlterColumn<string>(
            name: "OrganizationTypeName",
            table: "ITGOrganisations",
            type: "nvarchar(8)",
            maxLength: 8,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(8)",
            oldMaxLength: 8);

        migrationBuilder.AlterColumn<string>(
            name: "OrganizationStatusName",
            table: "ITGOrganisations",
            type: "nvarchar(64)",
            maxLength: 64,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(64)",
            oldMaxLength: 64);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "description",
            table: "ITGOrganisations",
            type: "nvarchar(1024)",
            maxLength: 1024,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(1024)",
            oldMaxLength: 1024,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "alert",
            table: "ITGOrganisations",
            type: "nvarchar(256)",
            maxLength: 256,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(256)",
            oldMaxLength: 256,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ShortName",
            table: "ITGOrganisations",
            type: "nvarchar(32)",
            maxLength: 32,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(32)",
            oldMaxLength: 32,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "QuickNotes",
            table: "ITGOrganisations",
            type: "nvarchar(1024)",
            maxLength: 1024,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(1024)",
            oldMaxLength: 1024,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "OrganizationTypeName",
            table: "ITGOrganisations",
            type: "nvarchar(8)",
            maxLength: 8,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(8)",
            oldMaxLength: 8,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "OrganizationStatusName",
            table: "ITGOrganisations",
            type: "nvarchar(64)",
            maxLength: 64,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(64)",
            oldMaxLength: 64,
            oldNullable: true);

        migrationBuilder.AddColumn<int>(
            name: "QuickNoteVaultId",
            table: "ITGOrganisations",
            type: "int",
            maxLength: 16,
            nullable: false,
            defaultValue: 0);
    }
}