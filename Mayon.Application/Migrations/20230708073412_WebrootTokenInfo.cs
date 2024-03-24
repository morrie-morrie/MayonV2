using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mayon.Application.Migrations;
/// <inheritdoc />
public partial class WebrootTokenInfo : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "WebrootTokenInfo",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", maxLength: 8, nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                AccessToken = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                TokenType = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                ExpiresIn = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                RefreshToken = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                Scope = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 32, nullable: false),
                UpdatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 32, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_WebrootTokenInfo", x => x.Id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "WebrootTokenInfo");
    }
}