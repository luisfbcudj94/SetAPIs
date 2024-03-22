using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class APITypeSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "APITypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("62ffbd2a-30f3-4e8e-bb8e-774a7d95e924"), "GRAPHQL" },
                    { new Guid("8028a4d9-53cf-4a23-bb5c-949b0a2a5806"), "SOAP" },
                    { new Guid("d09b4952-47c8-4c9d-a39a-d3d57643c02b"), "REST" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "APITypes",
                keyColumn: "Id",
                keyValue: new Guid("62ffbd2a-30f3-4e8e-bb8e-774a7d95e924"));

            migrationBuilder.DeleteData(
                table: "APITypes",
                keyColumn: "Id",
                keyValue: new Guid("8028a4d9-53cf-4a23-bb5c-949b0a2a5806"));

            migrationBuilder.DeleteData(
                table: "APITypes",
                keyColumn: "Id",
                keyValue: new Guid("d09b4952-47c8-4c9d-a39a-d3d57643c02b"));
        }
    }
}
