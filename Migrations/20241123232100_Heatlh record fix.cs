using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Home_app.Migrations
{
    /// <inheritdoc />
    public partial class Heatlhrecordfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "HealthRecords");

            migrationBuilder.AddColumn<long>(
                name: "Repetitions",
                table: "Lifts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "HealthRecords",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateIndex(
                name: "IX_HealthRecords_Date",
                table: "HealthRecords",
                column: "Date",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HealthRecords_Date",
                table: "HealthRecords");

            migrationBuilder.DropColumn(
                name: "Repetitions",
                table: "Lifts");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "HealthRecords");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "HealthRecords",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
