using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEMO_1.Migrations
{
    /// <inheritdoc />
    public partial class add_password_to_student : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                table: "Students");
        }
    }
}
