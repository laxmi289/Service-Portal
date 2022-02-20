using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServicePortal.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "UserData",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserData", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "IT" },
                    { 2, "HR" },
                    { 3, "Payroll" },
                    { 4, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "UserData",
                columns: new[] { "UserId", "Address", "DOB", "DepartmentId", "Email", "FirstName", "Gender", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "Texas", new DateTime(1980, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "john@test.com", "John", "Male", "Hastings", "9756431245" },
                    { 2, "Boston", new DateTime(1981, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Sam@test.com", "Sam", "Male", "Galloway", "9756431245" },
                    { 3, "Vegas", new DateTime(1979, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "mary@test.com", "Mary", "Female", "Smith", "5656431245" },
                    { 4, "Vegas", new DateTime(1982, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "sara@test.com", "Sara", "Female", "Longway", "5656431245" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "UserData");
        }
    }
}
