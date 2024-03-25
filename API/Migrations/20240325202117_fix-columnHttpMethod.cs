using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class fixcolumnHttpMethod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_URLs_HTTPMethods_HttpMethodsId",
                table: "URLs");

            migrationBuilder.DropIndex(
                name: "IX_URLs_HttpMethodsId",
                table: "URLs");

            migrationBuilder.DropColumn(
                name: "HttpMethodsId",
                table: "URLs");

            migrationBuilder.CreateIndex(
                name: "IX_URLs_HTTPMethodId",
                table: "URLs",
                column: "HTTPMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_URLs_HTTPMethods_HTTPMethodId",
                table: "URLs",
                column: "HTTPMethodId",
                principalTable: "HTTPMethods",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_URLs_HTTPMethods_HTTPMethodId",
                table: "URLs");

            migrationBuilder.DropIndex(
                name: "IX_URLs_HTTPMethodId",
                table: "URLs");

            migrationBuilder.AddColumn<Guid>(
                name: "HttpMethodsId",
                table: "URLs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
    }
}
