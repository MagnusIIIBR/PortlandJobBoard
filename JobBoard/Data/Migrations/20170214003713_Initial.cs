using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JobBoard.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyID",
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
                    table.PrimaryKey("PK_CompanyID", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "JobID",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Company = table.Column<string>(nullable: true),
                    Contract = table.Column<bool>(nullable: false),
                    DatePosted = table.Column<string>(nullable: true),
                    FullTime = table.Column<bool>(nullable: false),
                    Languages = table.Column<string>(nullable: true),
                    PartTime = table.Column<bool>(nullable: false),
                    Salary = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobID", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PlaceID",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceID", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserID",
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
                    table.PrimaryKey("PK_UserID", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyID");

            migrationBuilder.DropTable(
                name: "JobID");

            migrationBuilder.DropTable(
                name: "PlaceID");

            migrationBuilder.DropTable(
                name: "UserID");
        }
    }
}
