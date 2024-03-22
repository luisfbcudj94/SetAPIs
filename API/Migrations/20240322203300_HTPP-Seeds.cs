using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class HTPPSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HTTPMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("587e4311-f39f-4c0e-b909-81f7f4571d7b"), "GET" },
                    { new Guid("9b0f3a02-12a6-4b1f-bc48-1e631b79c2fd"), "PATCH" },
                    { new Guid("a05fd283-d09d-45b1-8f67-9832c4e21e0f"), "POST" },
                    { new Guid("c1acbd7a-8d8d-4f5d-bb72-6d6b0f7939b1"), "PUT" },
                    { new Guid("f2fc5b6c-8ab7-49e0-ae56-733c889b45c6"), "DELETE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HTTPMethods",
                keyColumn: "Id",
                keyValue: new Guid("587e4311-f39f-4c0e-b909-81f7f4571d7b"));

            migrationBuilder.DeleteData(
                table: "HTTPMethods",
                keyColumn: "Id",
                keyValue: new Guid("9b0f3a02-12a6-4b1f-bc48-1e631b79c2fd"));

            migrationBuilder.DeleteData(
                table: "HTTPMethods",
                keyColumn: "Id",
                keyValue: new Guid("a05fd283-d09d-45b1-8f67-9832c4e21e0f"));

            migrationBuilder.DeleteData(
                table: "HTTPMethods",
                keyColumn: "Id",
                keyValue: new Guid("c1acbd7a-8d8d-4f5d-bb72-6d6b0f7939b1"));

            migrationBuilder.DeleteData(
                table: "HTTPMethods",
                keyColumn: "Id",
                keyValue: new Guid("f2fc5b6c-8ab7-49e0-ae56-733c889b45c6"));
        }
    }
}
