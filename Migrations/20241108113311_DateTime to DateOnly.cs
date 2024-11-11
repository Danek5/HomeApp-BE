using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Home_app.Migrations
{
    /// <inheritdoc />
    public partial class DateTimetoDateOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CpuTemperature",
                table: "ServerInfos");

            migrationBuilder.DropColumn(
                name: "GpuName",
                table: "ServerInfos");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Events");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "ServerInfos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "Events",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "ServerInfos");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Events");

            migrationBuilder.AddColumn<double>(
                name: "CpuTemperature",
                table: "ServerInfos",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GpuName",
                table: "ServerInfos",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Events",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
