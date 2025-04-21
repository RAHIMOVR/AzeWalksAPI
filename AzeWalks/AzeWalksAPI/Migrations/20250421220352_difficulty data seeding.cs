using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AzeWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class difficultydataseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("451ead80-3cc6-4039-ae9b-96bb4163e8c9"), "Normal" },
                    { new Guid("d1b35171-8580-4302-b1bd-db3203ea969d"), "Hard" },
                    { new Guid("da48028d-23a1-487c-9e3c-245dc0b57332"), "Easy" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("451ead80-3cc6-4039-ae9b-96bb4163e8c9"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("d1b35171-8580-4302-b1bd-db3203ea969d"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("da48028d-23a1-487c-9e3c-245dc0b57332"));
        }
    }
}
