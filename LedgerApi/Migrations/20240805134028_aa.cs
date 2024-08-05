using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LedgerApi.Migrations
{
    /// <inheritdoc />
    public partial class aa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ladger",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ladger", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LadgerUser",
                columns: table => new
                {
                    LedgersId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LadgerUser", x => new { x.LedgersId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_LadgerUser_Ladger_LedgersId",
                        column: x => x.LedgersId,
                        principalTable: "Ladger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LadgerUser_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LadgerUser_UsersId",
                table: "LadgerUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LadgerUser");

            migrationBuilder.DropTable(
                name: "Ladger");
        }
    }
}
