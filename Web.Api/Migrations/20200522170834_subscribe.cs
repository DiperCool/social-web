using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Web.Api.Migrations
{
    public partial class subscribe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subscribes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WhoId = table.Column<int>(nullable: true),
                    ToId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscribes_Users_ToId",
                        column: x => x.ToId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subscribes_Users_WhoId",
                        column: x => x.WhoId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subscribes_ToId",
                table: "Subscribes",
                column: "ToId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscribes_WhoId",
                table: "Subscribes",
                column: "WhoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscribes");
        }
    }
}
