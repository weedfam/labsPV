using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstCarII.Data.Migrations
{
    public partial class alugueradded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluguer",
                columns: table => new
                {
                    AluguerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarroId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    LocalDeEntrega = table.Column<string>(nullable: true),
                    LocalDeRecolha = table.Column<string>(nullable: true),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluguer", x => x.AluguerId);
                    table.ForeignKey(
                        name: "FK_Aluguer_Carro_CarroId",
                        column: x => x.CarroId,
                        principalTable: "Carro",
                        principalColumn: "CarroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aluguer_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aluguer_CarroId",
                table: "Aluguer",
                column: "CarroId");

            migrationBuilder.CreateIndex(
                name: "IX_Aluguer_UserId",
                table: "Aluguer",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aluguer");
        }
    }
}
