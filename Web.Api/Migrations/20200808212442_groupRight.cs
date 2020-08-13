using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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

            migrationBuilder.CreateTable(
                name: "RightAdmins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Right = table.Column<string>(nullable: false),
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
                name: "IX_Groups_CreatorId",
                table: "Groups",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_InfoId",
                table: "Groups",
                column: "InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_RightAdmins_AdminGroupId",
                table: "RightAdmins",
                column: "AdminGroupId");

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

            migrationBuilder.DropTable(
                name: "RightAdmins");

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
