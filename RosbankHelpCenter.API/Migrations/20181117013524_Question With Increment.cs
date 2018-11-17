using Microsoft.EntityFrameworkCore.Migrations;

namespace RosbankHelpCenter.API.Migrations
{
    public partial class QuestionWithIncrement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IndexOfPop",
                table: "Questions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IndexOfPop",
                table: "Questions");
        }
    }
}
