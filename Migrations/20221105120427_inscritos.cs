using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuncionesLinq.Migrations
{
    public partial class inscritos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inscritos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Addby = table.Column<int>(type: "int", nullable: false),
                    Idalumno = table.Column<int>(type: "int", nullable: false),
                    Idcurso = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    FechaAdd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscritos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscritos");
        }
    }
}
