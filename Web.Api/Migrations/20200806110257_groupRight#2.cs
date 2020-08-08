using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Web.Api.Migrations
{
    public partial class groupRight2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rights",
                table: "AdminsGroups");

            migrationBuilder.CreateTable(
                name: "RightAdmins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Right = table.Column<int>(nullable: false),
                    AdminGroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RightAdmins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RightAdmins_AdminsGroups_AdminGroupId",
                        column: x => x.AdminGroupId,
                        principalTable: "AdminsGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RightAdmins_AdminGroupId",
                table: "RightAdmins",
                column: "AdminGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RightAdmins");

            migrationBuilder.AddColumn<int[]>(
                name: "Rights",
                table: "AdminsGroups",
                type: "integer[]",
                nullable: true);
        }
    }
}
