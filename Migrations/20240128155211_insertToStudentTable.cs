using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestWEBAPI.Migrations
{
    /// <inheritdoc />
    public partial class insertToStudentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "DOB", "Email", "StudentName" },
                values: new object[,]
                {
                    { 1, "kathmandu", new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "rsingh.rajesh01@gmail.com", "Rajesh" },
                    { 2, "satobato", new DateTime(2015, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "aartimahato@gmail.com", "Aarti Mahato" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
