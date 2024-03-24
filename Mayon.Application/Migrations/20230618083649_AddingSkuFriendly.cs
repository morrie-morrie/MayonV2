using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mayon.Application.Migrations;
/// <inheritdoc />
public partial class AddingSkuFriendly : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "InfraFriendlySkus",
            columns: table => new
            {
                id = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                MSSkuDisplayName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                MSSkuStringId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                MSSkuGUID = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                MSSkuServicePlanName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                MSSkuServicePlanId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                MSSkuFriendlyName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_InfraFriendlySkus", x => x.id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "InfraFriendlySkus");
    }
}