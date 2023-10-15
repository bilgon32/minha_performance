using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinhaPerformance.Migrations
{
    /// <inheritdoc />
    public partial class CreateDomainTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Criterios",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantitativo = table.Column<bool>(type: "bit", nullable: false),
                    FeedbackId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criterios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Criterios_Feedbacks_FeedbackId",
                        column: x => x.FeedbackId,
                        principalTable: "Feedbacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoFeedbacks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FeedbackId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReceptorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProvedorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoFeedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoFeedbacks_AspNetUsers_ProvedorId",
                        column: x => x.ProvedorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricoFeedbacks_AspNetUsers_ReceptorId",
                        column: x => x.ReceptorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricoFeedbacks_Feedbacks_FeedbackId",
                        column: x => x.FeedbackId,
                        principalTable: "Feedbacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoFeedbackCriterios",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HistoricoFeedbackId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CriterioId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoFeedbackCriterios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoFeedbackCriterios_Criterios_CriterioId",
                        column: x => x.CriterioId,
                        principalTable: "Criterios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoricoFeedbackCriterios_HistoricoFeedbacks_HistoricoFeedbackId",
                        column: x => x.HistoricoFeedbackId,
                        principalTable: "HistoricoFeedbacks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Criterios_FeedbackId",
                table: "Criterios",
                column: "FeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoFeedbackCriterios_CriterioId",
                table: "HistoricoFeedbackCriterios",
                column: "CriterioId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoFeedbackCriterios_HistoricoFeedbackId",
                table: "HistoricoFeedbackCriterios",
                column: "HistoricoFeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoFeedbacks_FeedbackId",
                table: "HistoricoFeedbacks",
                column: "FeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoFeedbacks_ProvedorId",
                table: "HistoricoFeedbacks",
                column: "ProvedorId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoFeedbacks_ReceptorId",
                table: "HistoricoFeedbacks",
                column: "ReceptorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoFeedbackCriterios");

            migrationBuilder.DropTable(
                name: "Criterios");

            migrationBuilder.DropTable(
                name: "HistoricoFeedbacks");

            migrationBuilder.DropTable(
                name: "Feedbacks");
        }
    }
}
