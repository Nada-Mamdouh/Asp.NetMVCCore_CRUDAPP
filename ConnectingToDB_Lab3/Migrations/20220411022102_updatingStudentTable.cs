using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConnectingToDB_Lab3.Migrations
{
    public partial class updatingStudentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StdImg",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StdImg",
                table: "Students");
        }
    }
}
