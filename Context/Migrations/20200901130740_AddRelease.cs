using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class AddRelease : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anv",
                table: "MasterArtists");

            migrationBuilder.DropColumn(
                name: "Join",
                table: "MasterArtists");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "MasterArtists");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "MasterArtists");

            migrationBuilder.DropColumn(
                name: "Tracks",
                table: "MasterArtists");

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "MasterArtists",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CatNo",
                table: "Labels",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReleaseId",
                table: "Labels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Anv",
                table: "Artists",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Join",
                table: "Artists",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Artists",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tracks",
                table: "Artists",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Releases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Genres = table.Column<string>(nullable: true),
                    Styles = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Released = table.Column<DateTime>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    DataQuality = table.Column<string>(nullable: true),
                    MasterId = table.Column<int>(nullable: true),
                    IsMainRelease = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Releases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Releases_Masters_MasterId",
                        column: x => x.MasterId,
                        principalTable: "Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CatNo = table.Column<string>(nullable: true),
                    EntityType = table.Column<int>(nullable: true),
                    ResourceUrl = table.Column<string>(nullable: true),
                    ReleaseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Releases_ReleaseId",
                        column: x => x.ReleaseId,
                        principalTable: "Releases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReleaseArtists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReleaseId = table.Column<int>(nullable: true),
                    ArtistId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleaseArtists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReleaseArtists_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReleaseArtists_Releases_ReleaseId",
                        column: x => x.ReleaseId,
                        principalTable: "Releases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReleaseExtraArtists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReleaseId = table.Column<int>(nullable: true),
                    ArtistId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleaseExtraArtists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReleaseExtraArtists_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReleaseExtraArtists_Releases_ReleaseId",
                        column: x => x.ReleaseId,
                        principalTable: "Releases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReleaseFormats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    Descriptions = table.Column<string>(nullable: true),
                    ReleaseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleaseFormats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReleaseFormats_Releases_ReleaseId",
                        column: x => x.ReleaseId,
                        principalTable: "Releases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReleaseIdentifiers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    ReleaseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleaseIdentifiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReleaseIdentifiers_Releases_ReleaseId",
                        column: x => x.ReleaseId,
                        principalTable: "Releases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReleaseImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReleaseId = table.Column<int>(nullable: true),
                    ImageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleaseImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReleaseImages_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReleaseImages_Releases_ReleaseId",
                        column: x => x.ReleaseId,
                        principalTable: "Releases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReleaseVideos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReleaseId = table.Column<int>(nullable: true),
                    VideoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleaseVideos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReleaseVideos_Releases_ReleaseId",
                        column: x => x.ReleaseId,
                        principalTable: "Releases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReleaseVideos_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    ReleaseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tracks_Releases_ReleaseId",
                        column: x => x.ReleaseId,
                        principalTable: "Releases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MasterArtists_ArtistId",
                table: "MasterArtists",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Labels_ReleaseId",
                table: "Labels",
                column: "ReleaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ReleaseId",
                table: "Companies",
                column: "ReleaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseArtists_ArtistId",
                table: "ReleaseArtists",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseArtists_ReleaseId",
                table: "ReleaseArtists",
                column: "ReleaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseExtraArtists_ArtistId",
                table: "ReleaseExtraArtists",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseExtraArtists_ReleaseId",
                table: "ReleaseExtraArtists",
                column: "ReleaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseFormats_ReleaseId",
                table: "ReleaseFormats",
                column: "ReleaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseIdentifiers_ReleaseId",
                table: "ReleaseIdentifiers",
                column: "ReleaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseImages_ImageId",
                table: "ReleaseImages",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseImages_ReleaseId",
                table: "ReleaseImages",
                column: "ReleaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Releases_MasterId",
                table: "Releases",
                column: "MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseVideos_ReleaseId",
                table: "ReleaseVideos",
                column: "ReleaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseVideos_VideoId",
                table: "ReleaseVideos",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_ReleaseId",
                table: "Tracks",
                column: "ReleaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Labels_Releases_ReleaseId",
                table: "Labels",
                column: "ReleaseId",
                principalTable: "Releases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterArtists_Artists_ArtistId",
                table: "MasterArtists",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labels_Releases_ReleaseId",
                table: "Labels");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterArtists_Artists_ArtistId",
                table: "MasterArtists");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "ReleaseArtists");

            migrationBuilder.DropTable(
                name: "ReleaseExtraArtists");

            migrationBuilder.DropTable(
                name: "ReleaseFormats");

            migrationBuilder.DropTable(
                name: "ReleaseIdentifiers");

            migrationBuilder.DropTable(
                name: "ReleaseImages");

            migrationBuilder.DropTable(
                name: "ReleaseVideos");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Releases");

            migrationBuilder.DropIndex(
                name: "IX_MasterArtists_ArtistId",
                table: "MasterArtists");

            migrationBuilder.DropIndex(
                name: "IX_Labels_ReleaseId",
                table: "Labels");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "MasterArtists");

            migrationBuilder.DropColumn(
                name: "CatNo",
                table: "Labels");

            migrationBuilder.DropColumn(
                name: "ReleaseId",
                table: "Labels");

            migrationBuilder.DropColumn(
                name: "Anv",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "Join",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "Tracks",
                table: "Artists");

            migrationBuilder.AddColumn<string>(
                name: "Anv",
                table: "MasterArtists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Join",
                table: "MasterArtists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MasterArtists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "MasterArtists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tracks",
                table: "MasterArtists",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
