using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VocabularyLists_LearningSpaces_LearningSpaceId",
                table: "VocabularyLists");

            migrationBuilder.AlterColumn<Guid>(
                name: "LearningSpaceId",
                table: "VocabularyLists",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    LearningSpaceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LogDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SkillDedicatedId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ComprehensionLevel = table.Column<double>(type: "REAL", nullable: false),
                    TimeDedicated = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_LearningSpaces_LearningSpaceId",
                        column: x => x.LearningSpaceId,
                        principalTable: "LearningSpaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Logs_Skills_SkillDedicatedId",
                        column: x => x.SkillDedicatedId,
                        principalTable: "Skills",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logs_LearningSpaceId",
                table: "Logs",
                column: "LearningSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_SkillDedicatedId",
                table: "Logs",
                column: "SkillDedicatedId");

            migrationBuilder.AddForeignKey(
                name: "FK_VocabularyLists_LearningSpaces_LearningSpaceId",
                table: "VocabularyLists",
                column: "LearningSpaceId",
                principalTable: "LearningSpaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VocabularyLists_LearningSpaces_LearningSpaceId",
                table: "VocabularyLists");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.AlterColumn<Guid>(
                name: "LearningSpaceId",
                table: "VocabularyLists",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_VocabularyLists_LearningSpaces_LearningSpaceId",
                table: "VocabularyLists",
                column: "LearningSpaceId",
                principalTable: "LearningSpaces",
                principalColumn: "Id");
        }
    }
}
