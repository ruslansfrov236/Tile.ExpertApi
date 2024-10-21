using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test.data.Migrations
{
    /// <inheritdoc />
    public partial class addDatabaseSqlServerDbContextUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_TagsCheckbox_TagsCheckboxId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_TagsCheckboxId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "TagsCheckboxId",
                table: "Tags");

            migrationBuilder.AddColumn<Guid>(
                name: "TagsId",
                table: "TagsCheckbox",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TagsCheckbox_TagsId",
                table: "TagsCheckbox",
                column: "TagsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TagsCheckbox_Tags_TagsId",
                table: "TagsCheckbox",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagsCheckbox_Tags_TagsId",
                table: "TagsCheckbox");

            migrationBuilder.DropIndex(
                name: "IX_TagsCheckbox_TagsId",
                table: "TagsCheckbox");

            migrationBuilder.DropColumn(
                name: "TagsId",
                table: "TagsCheckbox");

            migrationBuilder.AddColumn<Guid>(
                name: "TagsCheckboxId",
                table: "Tags",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TagsCheckboxId",
                table: "Tags",
                column: "TagsCheckboxId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_TagsCheckbox_TagsCheckboxId",
                table: "Tags",
                column: "TagsCheckboxId",
                principalTable: "TagsCheckbox",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
