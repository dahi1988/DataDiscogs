using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class AddMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistImages_Image_ImageId",
                table: "ArtistImages");

            migrationBuilder.DropForeignKey(
                name: "FK_LabelImages_Image_ImageId",
                table: "LabelImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Image",
                table: "Image");

            // WARNING : drop and recreate table => POSSIBLE LOSS OF DATA
            // This is done because simple renaming the table fails as Image is recognized in SQL as a Type
            migrationBuilder.DropTable(
                name: "Image");
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new 
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Height = table.Column<int>(nullable: true),
                    Width = table.Column<int>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Uri = table.Column<string>(nullable: true),
                    Uri150 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Masters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainRelease = table.Column<int>(nullable: true),
                    Genres = table.Column<string>(nullable: true),
                    Styles = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    DataQuality = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Masters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Src = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: true),
                    Embed = table.Column<bool>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterArtists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Anv = table.Column<string>(nullable: true),
                    Join = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Tracks = table.Column<string>(nullable: true),
                    MasterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterArtists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterArtists_Masters_MasterId",
                        column: x => x.MasterId,
                        principalTable: "Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MasterImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabelId = table.Column<int>(nullable: true),
                    ImageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterImages_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MasterImages_Masters_LabelId",
                        column: x => x.LabelId,
                        principalTable: "Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MasterVideos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterId = table.Column<int>(nullable: true),
                    VideoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterVideos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterVideos_Masters_MasterId",
                        column: x => x.MasterId,
                        principalTable: "Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MasterVideos_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MasterArtists_MasterId",
                table: "MasterArtists",
                column: "MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterImages_ImageId",
                table: "MasterImages",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterImages_LabelId",
                table: "MasterImages",
                column: "LabelId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterVideos_MasterId",
                table: "MasterVideos",
                column: "MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterVideos_VideoId",
                table: "MasterVideos",
                column: "VideoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistImages_Images_ImageId",
                table: "ArtistImages",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LabelImages_Images_ImageId",
                table: "LabelImages",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistImages_Images_ImageId",
                table: "ArtistImages");

            migrationBuilder.DropForeignKey(
                name: "FK_LabelImages_Images_ImageId",
                table: "LabelImages");

            migrationBuilder.DropTable(
                name: "MasterArtists");

            migrationBuilder.DropTable(
                name: "MasterImages");

            migrationBuilder.DropTable(
                name: "MasterVideos");

            migrationBuilder.DropTable(
                name: "Masters");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "Image");

            migrationBuilder.AlterColumn<int>(
                name: "Width",
                table: "Image",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Height",
                table: "Image",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Image",
                table: "Image",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistImages_Image_ImageId",
                table: "ArtistImages",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LabelImages_Image_ImageId",
                table: "LabelImages",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
