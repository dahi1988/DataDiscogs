using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class IntilaCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    ARTIST_ID = table.Column<int>(nullable: false),
                    NAME = table.Column<string>(nullable: true),
                    REALNAME = table.Column<string>(nullable: true),
                    PROFILE = table.Column<string>(nullable: true),
                    DATA_QUALITY = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.ARTIST_ID);
                });

            migrationBuilder.CreateTable(
                name: "Masters",
                columns: table => new
                {
                    MASTER_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MAIN_RELEASE_ID = table.Column<int>(nullable: false),
                    TITLE = table.Column<string>(nullable: true),
                    NOTES = table.Column<string>(nullable: true),
                    DATA_QUALITY = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Masters", x => x.MASTER_ID);
                });

            migrationBuilder.CreateTable(
                name: "Releases",
                columns: table => new
                {
                    RELEASE_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MASTER_ID = table.Column<int>(nullable: true),
                    IS_MAIN_RELEASE = table.Column<bool>(nullable: false),
                    STATUS = table.Column<string>(nullable: true),
                    TITLE = table.Column<string>(nullable: true),
                    COUNTRY = table.Column<string>(nullable: true),
                    NOTES = table.Column<string>(nullable: true),
                    DATA_QUALITY = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Releases", x => x.RELEASE_ID);
                });

            migrationBuilder.CreateTable(
                name: "SubLabel",
                columns: table => new
                {
                    LABEL_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubLabel", x => x.LABEL_ID);
                });

            migrationBuilder.CreateTable(
                name: "Labels",
                columns: table => new
                {
                    LABEL_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(nullable: true),
                    CONTACTINFO = table.Column<string>(nullable: true),
                    PROFILE = table.Column<string>(nullable: true),
                    DATA_QUALITY = table.Column<string>(nullable: true),
                    PARENTLABELLABEL_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labels", x => x.LABEL_ID);
                    table.ForeignKey(
                        name: "FK_Labels_SubLabel_PARENTLABELLABEL_ID",
                        column: x => x.PARENTLABELLABEL_ID,
                        principalTable: "SubLabel",
                        principalColumn: "LABEL_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Labels_PARENTLABELLABEL_ID",
                table: "Labels",
                column: "PARENTLABELLABEL_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Labels");

            migrationBuilder.DropTable(
                name: "Masters");

            migrationBuilder.DropTable(
                name: "Releases");

            migrationBuilder.DropTable(
                name: "SubLabel");
        }
    }
}
