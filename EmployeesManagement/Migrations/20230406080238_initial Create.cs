using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeesManagement.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    PersonalNumber = table.Column<string>(maxLength: 11, nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Gender = table.Column<bool>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: false),
                    Position = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    FiredDate = table.Column<DateTime>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
