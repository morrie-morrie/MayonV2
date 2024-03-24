using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Mayon.Application.Migrations;
/// <inheritdoc />
public partial class RemoveWebrootDB : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "WebrootCredentials");

        migrationBuilder.DropTable(
            name: "WebrootTokenInfo");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "WebrootCredentials",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                ClientId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                ClientSecretHash = table.Column<byte[]>(type: "varbinary(32)", maxLength: 32, nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                GSMKeyCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                Username = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_WebrootCredentials", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "WebrootTokenInfo",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                AccessToken = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                ExpiresIn = table.Column<int>(type: "int", nullable: false),
                RefreshToken = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                Scope = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                TokenType = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_WebrootTokenInfo", x => x.Id);
            });
    }
}
