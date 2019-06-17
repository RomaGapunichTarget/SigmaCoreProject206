using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SigmaCoreProject.Migrations
{
    public partial class CreateIdentitySchems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdUser = table.Column<string>(maxLength: 50, nullable: true),
                    DateComent = table.Column<DateTime>(type: "datetime", nullable: true),
                    BodyComment = table.Column<string>(nullable: true),
                    IdNews = table.Column<int>(nullable: true),
                    IdParentComent = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TitleNews = table.Column<string>(maxLength: 500, nullable: true),
                    BodyNews = table.Column<string>(nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateStartVisible = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateEndVisible = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsVisible = table.Column<bool>(nullable: true),
                    IdUserCreate = table.Column<string>(maxLength: 500, nullable: true),
                    ShoreInfo = table.Column<string>(maxLength: 500, nullable: true),
                    SeoDesc = table.Column<string>(maxLength: 500, nullable: true),
                    SeoTitlte = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "News");
        }
    }
}
