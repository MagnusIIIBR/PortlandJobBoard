using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JobBoardMVC.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Location = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationLink = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    DatePosted = table.Column<string>(nullable: true),
                    Experience = table.Column<string>(nullable: true),
                    Hours = table.Column<string>(nullable: true),
                    JobID = table.Column<string>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    LanguagesUsed = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Salary = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Experience = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Languages = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "Place");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
