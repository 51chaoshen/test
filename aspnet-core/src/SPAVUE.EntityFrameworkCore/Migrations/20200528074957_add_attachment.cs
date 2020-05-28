using Microsoft.EntityFrameworkCore.Migrations;

namespace SPAVUE.Migrations
{
    public partial class add_attachment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "common_attachment",
                columns: table => new
                {
                    ATTACHMENTID = table.Column<string>(nullable: false),
                    NAME = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    EXTENSON = table.Column<string>(nullable: true),
                    SOURCEID = table.Column<string>(nullable: true),
                    FILESIZE = table.Column<double>(nullable: true),
                    REMARK = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_common_attachment", x => x.ATTACHMENTID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "common_attachment");
        }
    }
}
