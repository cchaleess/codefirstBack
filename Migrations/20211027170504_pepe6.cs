using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirst.Migrations
{
    public partial class pepe6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Archivo_Consulta_ConsultaID",
                table: "Archivo");

            migrationBuilder.DropIndex(
                name: "IX_Archivo_ConsultaID",
                table: "Archivo");

            migrationBuilder.DropColumn(
                name: "ConsultaID",
                table: "Archivo");

            migrationBuilder.AddColumn<int>(
                name: "ArchivoID",
                table: "Consulta",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_ArchivoID",
                table: "Consulta",
                column: "ArchivoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Archivo_ArchivoID",
                table: "Consulta",
                column: "ArchivoID",
                principalTable: "Archivo",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Archivo_ArchivoID",
                table: "Consulta");

            migrationBuilder.DropIndex(
                name: "IX_Consulta_ArchivoID",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "ArchivoID",
                table: "Consulta");

            migrationBuilder.AddColumn<int>(
                name: "ConsultaID",
                table: "Archivo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Archivo_ConsultaID",
                table: "Archivo",
                column: "ConsultaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Archivo_Consulta_ConsultaID",
                table: "Archivo",
                column: "ConsultaID",
                principalTable: "Consulta",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
