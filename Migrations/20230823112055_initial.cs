using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEMO_1.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Dept_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dept_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Dept_Desc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Dept_Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Dept_Manager = table.Column<int>(type: "int", nullable: true),
                    Manager_hiredate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Dept_Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    St_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    St_Fname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    St_Lname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    St_Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    St_Age = table.Column<int>(type: "int", nullable: true),
                    Dept_Id = table.Column<int>(type: "int", nullable: true),
                    St_super = table.Column<int>(type: "int", nullable: true),
                    Dept_Manager = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.St_Id);
                    table.ForeignKey(
                        name: "FK_Students_Department_Dept_Id",
                        column: x => x.Dept_Id,
                        principalTable: "Department",
                        principalColumn: "Dept_Id");
                    table.ForeignKey(
                        name: "FK_Students_Students_St_super",
                        column: x => x.St_super,
                        principalTable: "Students",
                        principalColumn: "St_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_Dept_Id",
                table: "Students",
                column: "Dept_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_St_super",
                table: "Students",
                column: "St_super");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
