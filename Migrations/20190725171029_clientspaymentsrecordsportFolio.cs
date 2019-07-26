using Microsoft.EntityFrameworkCore.Migrations;

namespace Empleados.Migrations
{
    public partial class clientspaymentsrecordsportFolio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Access");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "Empleados",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "applealed",
                table: "Empleados",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "photo",
                table: "Empleados",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "telephone",
                table: "Empleados",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Carteras",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idEmploye = table.Column<int>(nullable: false),
                    IdClient = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carteras", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    photo = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    applealed = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    telephone = table.Column<string>(nullable: true),
                    other = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Foliados",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idParameter = table.Column<int>(nullable: false),
                    idREcord = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foliados", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idEmploye = table.Column<int>(nullable: false),
                    idClient = table.Column<int>(nullable: false),
                    preBalance = table.Column<double>(nullable: false),
                    payment = table.Column<double>(nullable: false),
                    newBalance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carteras");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Foliados");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropColumn(
                name: "address",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "applealed",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "photo",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "telephone",
                table: "Empleados");

            migrationBuilder.CreateTable(
                name: "Access",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Employeid = table.Column<int>(nullable: true),
                    menu = table.Column<string>(nullable: true),
                    status = table.Column<bool>(nullable: false),
                    url = table.Column<string>(nullable: true)
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
    }
}
