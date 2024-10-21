using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test.data.Migrations
{
    /// <inheritdoc />
    public partial class mg_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagsCheckbox_Tags_TagsId",
                table: "TagsCheckbox");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagsCheckbox",
                table: "TagsCheckbox");

            migrationBuilder.RenameTable(
                name: "TagsCheckbox",
                newName: "TagsCheckboxes");

            migrationBuilder.RenameIndex(
                name: "IX_TagsCheckbox_TagsId",
                table: "TagsCheckboxes",
                newName: "IX_TagsCheckboxes_TagsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagsCheckboxes",
                table: "TagsCheckboxes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TagsCheckboxes_Tags_TagsId",
                table: "TagsCheckboxes",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagsCheckboxes_Tags_TagsId",
                table: "TagsCheckboxes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagsCheckboxes",
                table: "TagsCheckboxes");

            migrationBuilder.RenameTable(
                name: "TagsCheckboxes",
                newName: "TagsCheckbox");

            migrationBuilder.RenameIndex(
                name: "IX_TagsCheckboxes_TagsId",
                table: "TagsCheckbox",
                newName: "IX_TagsCheckbox_TagsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagsCheckbox",
                table: "TagsCheckbox",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TagsCheckbox_Tags_TagsId",
                table: "TagsCheckbox",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
