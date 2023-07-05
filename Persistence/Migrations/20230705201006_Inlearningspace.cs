using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Inlearningspace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastStudiedDate",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Languages");

            migrationBuilder.AddColumn<Guid>(
                name: "LearningSpaceId",
                table: "VocabularyTag",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LearningSpaces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    StartDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    LastUdpatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LanguageId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningSpaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LearningSpaces_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VocabularyTag_LearningSpaceId",
                table: "VocabularyTag",
                column: "LearningSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningSpaces_LanguageId",
                table: "LearningSpaces",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_VocabularyTag_LearningSpaces_LearningSpaceId",
                table: "VocabularyTag",
                column: "LearningSpaceId",
                principalTable: "LearningSpaces",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VocabularyTag_LearningSpaces_LearningSpaceId",
                table: "VocabularyTag");

            migrationBuilder.DropTable(
                name: "LearningSpaces");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_VocabularyTag_LearningSpaceId",
                table: "VocabularyTag");

            migrationBuilder.DropColumn(
                name: "LearningSpaceId",
                table: "VocabularyTag");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastStudiedDate",
                table: "Languages",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateOnly>(
                name: "StartDate",
                table: "Languages",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }
    }
}
