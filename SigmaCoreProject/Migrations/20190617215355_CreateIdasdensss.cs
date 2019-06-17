using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SigmaCoreProject.Migrations
{
    public partial class CreateIdasdensss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdNews = table.Column<int>(nullable: false),
                    IdPers = table.Column<int>(nullable: false),
                    IdUser = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OtherContent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TitleContent = table.Column<string>(maxLength: 5000, nullable: true),
                    BodyContent = table.Column<string>(nullable: true),
                    IdUserCreate = table.Column<string>(maxLength: 50, nullable: true),
                    IdPhysPer = table.Column<int>(nullable: false),
                    IdTypeContent = table.Column<int>(nullable: false),
                    IsVislbe = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherContent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RankNews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdUser = table.Column<string>(maxLength: 500, nullable: true),
                    idPhysPers = table.Column<int>(nullable: false),
                    Rank = table.Column<decimal>(type: "decimal(5,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RankNews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "STypeContent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeConent = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STypeContent", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "OtherContent");

            migrationBuilder.DropTable(
                name: "RankNews");

            migrationBuilder.DropTable(
                name: "STypeContent");
        }
    }
}
