using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DkmsCore.Gamora.Migrations
{
    public partial class Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DkmsApi",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    Service = table.Column<string>(maxLength: 200, nullable: true),
                    SiteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DkmsApi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DkmsSite",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    DocUrl = table.Column<string>(maxLength: 500, nullable: true),
                    Host = table.Column<string>(maxLength: 200, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DkmsSite", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DkmsApi");

            migrationBuilder.DropTable(
                name: "DkmsSite");
        }
    }
}
