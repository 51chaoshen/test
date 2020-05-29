using Microsoft.EntityFrameworkCore.Migrations;

namespace SPAVUE.Migrations
{
    public partial class modify_attachment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "CommonAttachment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "CommonAttachment");
        }
    }
}
