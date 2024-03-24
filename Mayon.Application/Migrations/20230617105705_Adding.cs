using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mayon.Application.Migrations;
/// <inheritdoc />
public partial class Adding : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "infraMsTenants",
            columns: table => new
            {
                MsTenantCustomerId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                MsTenantDisplayName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                MsTenantDefaultDomainName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                MsTenantContractType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                MSTenantDeletedDateTime = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_infraMsTenants", x => x.MsTenantCustomerId);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "infraMsTenants");
    }
}