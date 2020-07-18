using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Api.Migrations
{
    public partial class group3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvaId",
                table: "Groups",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_AvaId",
                table: "Groups",
                column: "AvaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Imgs_AvaId",
                table: "Groups",
                column: "AvaId",
                principalTable: "Imgs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Imgs_AvaId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_AvaId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "AvaId",
                table: "Groups");
        }
    }
}
