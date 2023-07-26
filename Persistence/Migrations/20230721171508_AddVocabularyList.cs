using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddVocabularyList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VocabularyTag");

            migrationBuilder.DropTable(
                name: "TagsForVocab");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Vocabularies",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Vocabularies",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "VocabularyListId",
                table: "Vocabularies",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VocabularyLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    LearningSpaceId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VocabularyLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VocabularyLists_LearningSpaces_LearningSpaceId",
                        column: x => x.LearningSpaceId,
                        principalTable: "LearningSpaces",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vocabularies_VocabularyListId",
                table: "Vocabularies",
                column: "VocabularyListId");

            migrationBuilder.CreateIndex(
                name: "IX_VocabularyLists_LearningSpaceId",
                table: "VocabularyLists",
                column: "LearningSpaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vocabularies_VocabularyLists_VocabularyListId",
                table: "Vocabularies",
                column: "VocabularyListId",
                principalTable: "VocabularyLists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vocabularies_VocabularyLists_VocabularyListId",
                table: "Vocabularies");

            migrationBuilder.DropTable(
                name: "VocabularyLists");

            migrationBuilder.DropIndex(
                name: "IX_Vocabularies_VocabularyListId",
                table: "Vocabularies");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Vocabularies");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Vocabularies");

            migrationBuilder.DropColumn(
                name: "VocabularyListId",
                table: "Vocabularies");

            migrationBuilder.CreateTable(
                name: "TagsForVocab",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagsForVocab", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VocabularyTag",
                columns: table => new
                {
                    VocabularyId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TagId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LearningSpaceId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VocabularyTag", x => new { x.VocabularyId, x.TagId });
                    table.ForeignKey(
                        name: "FK_VocabularyTag_LearningSpaces_LearningSpaceId",
                        column: x => x.LearningSpaceId,
                        principalTable: "LearningSpaces",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VocabularyTag_TagsForVocab_TagId",
                        column: x => x.TagId,
                        principalTable: "TagsForVocab",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VocabularyTag_Vocabularies_VocabularyId",
                        column: x => x.VocabularyId,
                        principalTable: "Vocabularies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VocabularyTag_LearningSpaceId",
                table: "VocabularyTag",
                column: "LearningSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_VocabularyTag_TagId",
                table: "VocabularyTag",
                column: "TagId");
        }
    }
}
