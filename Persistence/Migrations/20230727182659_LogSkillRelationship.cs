using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class LogSkillRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Skills_SkillDedicatedId",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_SkillDedicatedId",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "SkillDedicatedId",
                table: "Logs");

            migrationBuilder.AddColumn<Guid>(
                name: "SkillId",
                table: "Logs",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Logs_SkillId",
                table: "Logs",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Skills_SkillId",
                table: "Logs",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Skills_SkillId",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_SkillId",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "Logs");

            migrationBuilder.AddColumn<Guid>(
                name: "SkillDedicatedId",
                table: "Logs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Logs_SkillDedicatedId",
                table: "Logs",
                column: "SkillDedicatedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Skills_SkillDedicatedId",
                table: "Logs",
                column: "SkillDedicatedId",
                principalTable: "Skills",
                principalColumn: "Id");
        }
    }
}
