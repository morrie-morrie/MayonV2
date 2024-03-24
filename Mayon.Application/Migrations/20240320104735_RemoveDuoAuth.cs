using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mayon.Application.Migrations;
/// <inheritdoc />
public partial class RemoveDuoAuth : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "DuoApiAuths");

        migrationBuilder.CreateTable(
            name: "InfraMsExchangeMailboxes",
            columns: table => new
            {
                Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                MsTenantCustomerId = table.Column<string>(type: "nvarchar(64)", nullable: false),
                ExternalDirectoryObjectId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                UserPrincipalName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                Alias = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                DisplayName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                EmailAddresses = table.Column<string>(type: "nvarchar(max)", nullable: true),
                PrimarySmtpAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                RecipientType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                RecipientTypeDetails = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_InfraMsExchangeMailboxes", x => x.Id);
                table.ForeignKey(
                    name: "FK_InfraMsExchangeMailboxes_infraMsTenants_MsTenantCustomerId",
                    column: x => x.MsTenantCustomerId,
                    principalTable: "infraMsTenants",
                    principalColumn: "MsTenantCustomerId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_InfraMsExchangeMailboxes_MsTenantCustomerId",
            table: "InfraMsExchangeMailboxes",
            column: "MsTenantCustomerId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "InfraMsExchangeMailboxes");

        migrationBuilder.CreateTable(
            name: "DuoApiAuths",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                ApiHostname = table.Column<string>(type: "nvarchar(96)", maxLength: 96, nullable: false),
                IntegrationKey = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                SecretKey = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_DuoApiAuths", x => x.Id);
            });
    }
}
