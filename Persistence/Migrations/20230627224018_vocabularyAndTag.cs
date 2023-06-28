using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class vocabularyAndTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vocabularies_Languages_LanguageId",
                table: "Vocabularies");

            migrationBuilder.DropForeignKey(
                name: "FK_VocabularyTag_Vocabularies_VocabularyId",
                table: "VocabularyTag");

            migrationBuilder.DropIndex(
                name: "IX_VocabularyTag_VocabularyId",
                table: "VocabularyTag");

            migrationBuilder.DropIndex(
                name: "IX_Vocabularies_LanguageId",
                table: "Vocabularies");

            migrationBuilder.DropColumn(
                name: "VocabularyId",
                table: "VocabularyTag");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Vocabularies");

            migrationBuilder.CreateTable(
                name: "VocabularyVocabularyTag",
                columns: table => new
                {
                    TagsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    VocabulariesId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VocabularyVocabularyTag", x => new { x.TagsId, x.VocabulariesId });
                    table.ForeignKey(
                        name: "FK_VocabularyVocabularyTag_Vocabularies_VocabulariesId",
                        column: x => x.VocabulariesId,
                        principalTable: "Vocabularies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VocabularyVocabularyTag_VocabularyTag_TagsId",
                        column: x => x.TagsId,
                        principalTable: "VocabularyTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VocabularyVocabularyTag_VocabulariesId",
                table: "VocabularyVocabularyTag",
                column: "VocabulariesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VocabularyVocabularyTag");

            migrationBuilder.AddColumn<Guid>(
                name: "VocabularyId",
                table: "VocabularyTag",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LanguageId",
                table: "Vocabularies",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VocabularyTag_VocabularyId",
                table: "VocabularyTag",
                column: "VocabularyId");

            migrationBuilder.CreateIndex(
                name: "IX_Vocabularies_LanguageId",
                table: "Vocabularies",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vocabularies_Languages_LanguageId",
                table: "Vocabularies",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VocabularyTag_Vocabularies_VocabularyId",
                table: "VocabularyTag",
                column: "VocabularyId",
                principalTable: "Vocabularies",
                principalColumn: "Id");
        }
    }
}
