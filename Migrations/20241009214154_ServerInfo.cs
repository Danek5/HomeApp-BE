using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Home_app.Migrations
{
    /// <inheritdoc />
    public partial class ServerInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServerInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CpuUsagePercentage = table.Column<double>(type: "double precision", nullable: false),
                    TotalMemory = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    AvailableMemory = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    GpuName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    GpuMemory = table.Column<decimal>(type: "numeric(20,0)", nullable: true),
                    CpuTemperature = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerInfos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServerInfos");
        }
    }
}
