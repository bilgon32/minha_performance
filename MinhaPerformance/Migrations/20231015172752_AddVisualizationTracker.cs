using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinhaPerformance.Migrations
{
    /// <inheritdoc />
    public partial class AddVisualizationTracker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "VisualizadoEm",
                table: "HistoricoFeedbacks",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VisualizadoEm",
                table: "HistoricoFeedbacks");
        }
    }
}
