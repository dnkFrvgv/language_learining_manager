using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeVocabFieldsName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vocabularies_VocabularyLists_VocabularyListId",
                table: "Vocabularies");

            migrationBuilder.RenameColumn(
                name: "ExamplePhrase",
                table: "Vocabularies",
                newName: "Source");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Vocabularies",
                newName: "DateAdded");

            migrationBuilder.AlterColumn<Guid>(
                name: "VocabularyListId",
                table: "Vocabularies",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContextPhrase",
                table: "Vocabularies",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vocabularies_VocabularyLists_VocabularyListId",
                table: "Vocabularies",
                column: "VocabularyListId",
                principalTable: "VocabularyLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vocabularies_VocabularyLists_VocabularyListId",
                table: "Vocabularies");

            migrationBuilder.DropColumn(
                name: "ContextPhrase",
                table: "Vocabularies");

            migrationBuilder.RenameColumn(
                name: "Source",
                table: "Vocabularies",
                newName: "ExamplePhrase");

            migrationBuilder.RenameColumn(
                name: "DateAdded",
                table: "Vocabularies",
                newName: "Date");

            migrationBuilder.AlterColumn<Guid>(
                name: "VocabularyListId",
                table: "Vocabularies",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Vocabularies_VocabularyLists_VocabularyListId",
                table: "Vocabularies",
                column: "VocabularyListId",
                principalTable: "VocabularyLists",
                principalColumn: "Id");
        }
    }
}
