using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirst.Migrations
{
    public partial class pepe9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Referencia_ReferenciaID",
                table: "Consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_Referencia_Archivo_ArchivoID",
                table: "Referencia");

            migrationBuilder.DropIndex(
                name: "IX_Consulta_ReferenciaID",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "ReferenciaID",
                table: "Consulta");

            migrationBuilder.RenameColumn(
                name: "ArchivoID",
                table: "Referencia",
                newName: "ConsultaID");

            migrationBuilder.RenameIndex(
                name: "IX_Referencia_ArchivoID",
                table: "Referencia",
                newName: "IX_Referencia_ConsultaID");

            migrationBuilder.AddColumn<int>(
                name: "ReferenciaID",
                table: "Archivo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Archivo_ReferenciaID",
                table: "Archivo",
                column: "ReferenciaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Archivo_Referencia_ReferenciaID",
                table: "Archivo",
                column: "ReferenciaID",
                principalTable: "Referencia",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Referencia_Consulta_ConsultaID",
                table: "Referencia",
                column: "ConsultaID",
                principalTable: "Consulta",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Archivo_Referencia_ReferenciaID",
                table: "Archivo");

            migrationBuilder.DropForeignKey(
                name: "FK_Referencia_Consulta_ConsultaID",
                table: "Referencia");

            migrationBuilder.DropIndex(
                name: "IX_Archivo_ReferenciaID",
                table: "Archivo");

            migrationBuilder.DropColumn(
                name: "ReferenciaID",
                table: "Archivo");

            migrationBuilder.RenameColumn(
                name: "ConsultaID",
                table: "Referencia",
                newName: "ArchivoID");

            migrationBuilder.RenameIndex(
                name: "IX_Referencia_ConsultaID",
                table: "Referencia",
                newName: "IX_Referencia_ArchivoID");

            migrationBuilder.AddColumn<int>(
                name: "ReferenciaID",
                table: "Consulta",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_ReferenciaID",
                table: "Consulta",
                column: "ReferenciaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Referencia_ReferenciaID",
                table: "Consulta",
                column: "ReferenciaID",
                principalTable: "Referencia",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Referencia_Archivo_ArchivoID",
                table: "Referencia",
                column: "ArchivoID",
                principalTable: "Archivo",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
