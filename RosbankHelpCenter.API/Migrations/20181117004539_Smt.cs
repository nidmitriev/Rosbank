using Microsoft.EntityFrameworkCore.Migrations;

namespace RosbankHelpCenter.API.Migrations
{
    public partial class Smt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BusinessType",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsVIP",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MailForVip = table.Column<string>(nullable: true),
                    MailForNotVip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Theme = table.Column<string>(nullable: true),
                    SubTheme = table.Column<string>(nullable: true),
                    Quest = table.Column<string>(nullable: true),
                    Aswer = table.Column<string>(nullable: true),
                    StaffMailId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Staffs_StaffMailId",
                        column: x => x.StaffMailId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_StaffMailId",
                table: "Questions",
                column: "StaffMailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropColumn(
                name: "BusinessType",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsVIP",
                table: "Users");
        }
    }
}
