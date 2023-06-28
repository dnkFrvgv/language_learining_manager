using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFieldTo_LastStudiedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastUpdatedDate",
                table: "Languages",
                newName: "LastStudiedDate");

            migrationBuilder.CreateTable(
                name: "Vocabularies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    LanguageId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ExamplePhrase = table.Column<string>(type: "TEXT", nullable: true),
                    Translation = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vocabularies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vocabularies_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VocabularyTag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    VocabularyId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VocabularyTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VocabularyTag_Vocabularies_VocabularyId",
                        column: x => x.VocabularyId,
                        principalTable: "Vocabularies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vocabularies_LanguageId",
                table: "Vocabularies",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_VocabularyTag_VocabularyId",
                table: "VocabularyTag",
                column: "VocabularyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VocabularyTag");

            migrationBuilder.DropTable(
                name: "Vocabularies");

            migrationBuilder.RenameColumn(
                name: "LastStudiedDate",
                table: "Languages",
                newName: "LastUpdatedDate");
        }
    }
}
