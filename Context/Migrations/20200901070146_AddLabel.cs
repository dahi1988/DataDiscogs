using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class AddLabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Labels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ContactInfo = table.Column<string>(nullable: true),
                    Profile = table.Column<string>(nullable: true),
                    DataQuality = table.Column<string>(nullable: true),
                    Urls = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LabelImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabelId = table.Column<int>(nullable: true),
                    ImageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabelImages_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LabelImages_Labels_LabelId",
                        column: x => x.LabelId,
                        principalTable: "Labels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParentLabels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    LabelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentLabels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParentLabels_Labels_LabelId",
                        column: x => x.LabelId,
                        principalTable: "Labels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubLabels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    LabelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubLabels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubLabels_Labels_LabelId",
                        column: x => x.LabelId,
                        principalTable: "Labels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabelImages_ImageId",
                table: "LabelImages",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_LabelImages_LabelId",
                table: "LabelImages",
                column: "LabelId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentLabels_LabelId",
                table: "ParentLabels",
                column: "LabelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubLabels_LabelId",
                table: "SubLabels",
                column: "LabelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabelImages");

            migrationBuilder.DropTable(
                name: "ParentLabels");

            migrationBuilder.DropTable(
                name: "SubLabels");

            migrationBuilder.DropTable(
                name: "Labels");
        }
    }
}
