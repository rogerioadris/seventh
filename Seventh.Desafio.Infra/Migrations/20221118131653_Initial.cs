using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Seventh.Desafio.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "server",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    name = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: true),
                    ipaddress = table.Column<string>(name: "ip_address", type: "nvarchar(15)", maxLength: 15, nullable: true),
                    port = table.Column<int>(type: "int", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_server", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "server");
        }
    }
}
