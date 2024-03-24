using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mayon.Application.Migrations;
/// <inheritdoc />
public partial class ITGlueOrgs : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "ITGOrganisations",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", maxLength: 16, nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                alert = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                OrganizationTypeId = table.Column<int>(type: "int", maxLength: 16, nullable: true),
                OrganizationTypeName = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                OrganizationStatusId = table.Column<int>(type: "int", maxLength: 16, nullable: true),
                OrganizationStatusName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                primary = table.Column<bool>(type: "bit", maxLength: 8, nullable: false),
                QuickNotes = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                QuickNoteVaultId = table.Column<int>(type: "int", maxLength: 16, nullable: false),
                ShortName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 32, nullable: false),
                UpdatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 32, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ITGOrganisations", x => x.Id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "ITGOrganisations");
    }
}