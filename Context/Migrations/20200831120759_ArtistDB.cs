using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class ArtistDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Artists",
                table: "Artists");

            migrationBuilder.RenameTable(
                name: "Artists",
                newName: "Artist");

            migrationBuilder.AddColumn<string>(
                name: "NameVariations",
                table: "Artist",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Urls",
                table: "Artist",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artist",
                table: "Artist",
                column: "ARTIST_ID");

            migrationBuilder.CreateTable(
                name: "Alias",
                columns: table => new
                {
                    ARTIST_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(nullable: true),
                    ARTIST_ID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alias", x => x.ARTIST_ID);
                    table.ForeignKey(
                        name: "FK_Alias_Artist_ARTIST_ID1",
                        column: x => x.ARTIST_ID1,
                        principalTable: "Artist",
                        principalColumn: "ARTIST_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    ARTIST_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(nullable: true),
                    ARTIST_ID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.ARTIST_ID);
                    table.ForeignKey(
                        name: "FK_Group_Artist_ARTIST_ID1",
                        column: x => x.ARTIST_ID1,
                        principalTable: "Artist",
                        principalColumn: "ARTIST_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    HEIGHT = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WIDTH = table.Column<int>(nullable: false),
                    TYPE = table.Column<string>(nullable: true),
                    URI = table.Column<string>(nullable: true),
                    URI150 = table.Column<string>(nullable: true),
                    ARTIST_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.HEIGHT);
                    table.ForeignKey(
                        name: "FK_Image_Artist_ARTIST_ID",
                        column: x => x.ARTIST_ID,
                        principalTable: "Artist",
                        principalColumn: "ARTIST_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    ARTIST_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(nullable: true),
                    ARTIST_ID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.ARTIST_ID);
                    table.ForeignKey(
                        name: "FK_Member_Artist_ARTIST_ID1",
                        column: x => x.ARTIST_ID1,
                        principalTable: "Artist",
                        principalColumn: "ARTIST_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alias_ARTIST_ID1",
                table: "Alias",
                column: "ARTIST_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_Group_ARTIST_ID1",
                table: "Group",
                column: "ARTIST_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ARTIST_ID",
                table: "Image",
                column: "ARTIST_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Member_ARTIST_ID1",
                table: "Member",
                column: "ARTIST_ID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alias");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artist",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "NameVariations",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "Urls",
                table: "Artist");

            migrationBuilder.RenameTable(
                name: "Artist",
                newName: "Artists");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artists",
                table: "Artists",
                column: "ARTIST_ID");
        }
    }
}
