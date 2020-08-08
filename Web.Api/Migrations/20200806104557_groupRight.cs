using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Web.Models.Enums;

namespace Web.Api.Migrations
{
    public partial class groupRight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "Right",
                table: "AdminsGroups");

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Groups",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InfoId",
                table: "Groups",
                nullable: true);

            migrationBuilder.AddColumn<List<RightType>>(
                name: "Rights",
                table: "AdminsGroups",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GroupsInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupsInfos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CreatorId",
                table: "Groups",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_InfoId",
                table: "Groups",
                column: "InfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Users_CreatorId",
                table: "Groups",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_GroupsInfos_InfoId",
                table: "Groups",
                column: "InfoId",
                principalTable: "GroupsInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Users_CreatorId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_GroupsInfos_InfoId",
                table: "Groups");

            migrationBuilder.DropTable(
                name: "GroupsInfos");

            migrationBuilder.DropIndex(
                name: "IX_Groups_CreatorId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_InfoId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "InfoId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "Rights",
                table: "AdminsGroups");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Groups",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Groups",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Right",
                table: "AdminsGroups",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
