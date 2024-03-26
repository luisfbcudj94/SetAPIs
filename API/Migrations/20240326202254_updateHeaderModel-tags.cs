using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class updateHeaderModeltags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HeaderTags_HeaderId",
                table: "HeaderTags");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Headers");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Headers");

            migrationBuilder.CreateIndex(
                name: "IX_HeaderTags_HeaderId",
                table: "HeaderTags",
                column: "HeaderId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HeaderTags_HeaderId",
                table: "HeaderTags");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Headers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Headers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_HeaderTags_HeaderId",
                table: "HeaderTags",
                column: "HeaderId");
        }
    }
}
