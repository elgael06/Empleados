using Microsoft.EntityFrameworkCore.Migrations;

namespace Empleados.Migrations
{
    public partial class empleados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Access",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    menu = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true),
                    status = table.Column<bool>(nullable: false),
                    Employeid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Access", x => x.id);
                    table.ForeignKey(
                        name: "FK_Access_Empleados_Employeid",
                        column: x => x.Employeid,
                        principalTable: "Empleados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Access_Employeid",
                table: "Access",
                column: "Employeid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Access");

            migrationBuilder.DropTable(
                name: "Empleados");
        }
    }
}
