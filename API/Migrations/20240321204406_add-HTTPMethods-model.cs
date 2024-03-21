using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class addHTTPMethodsmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "HttpMethodsId",
                table: "URLs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "HTTPMethods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HTTPMethods", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_URLs_HttpMethodsId",
                table: "URLs",
                column: "HttpMethodsId");

            migrationBuilder.AddForeignKey(
                name: "FK_URLs_HTTPMethods_HttpMethodsId",
                table: "URLs",
                column: "HttpMethodsId",
                principalTable: "HTTPMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_URLs_HTTPMethods_HttpMethodsId",
                table: "URLs");

            migrationBuilder.DropTable(
                name: "HTTPMethods");

            migrationBuilder.DropIndex(
                name: "IX_URLs_HttpMethodsId",
                table: "URLs");

            migrationBuilder.DropColumn(
                name: "HttpMethodsId",
                table: "URLs");
        }
    }
}
