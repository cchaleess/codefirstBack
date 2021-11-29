using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirst.Migrations
{
    public partial class pepe8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Archivo_ArchivoID",
                table: "Consulta");

            migrationBuilder.RenameColumn(
                name: "ArchivoID",
                table: "Consulta",
                newName: "ReferenciaID");

            migrationBuilder.RenameIndex(
                name: "IX_Consulta_ArchivoID",
                table: "Consulta",
                newName: "IX_Consulta_ReferenciaID");

            migrationBuilder.CreateTable(
                name: "Referencia",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ref = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnidadesPropuesta = table.Column<int>(type: "int", nullable: false),
                    ArchivoID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referencia", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Referencia_Archivo_ArchivoID",
                        column: x => x.ArchivoID,
                        principalTable: "Archivo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Referencia_ArchivoID",
                table: "Referencia",
                column: "ArchivoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Referencia_ReferenciaID",
                table: "Consulta",
                column: "ReferenciaID",
                principalTable: "Referencia",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Referencia_ReferenciaID",
                table: "Consulta");

            migrationBuilder.DropTable(
                name: "Referencia");

            migrationBuilder.RenameColumn(
                name: "ReferenciaID",
                table: "Consulta",
                newName: "ArchivoID");

            migrationBuilder.RenameIndex(
                name: "IX_Consulta_ReferenciaID",
                table: "Consulta",
                newName: "IX_Consulta_ArchivoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Archivo_ArchivoID",
                table: "Consulta",
                column: "ArchivoID",
                principalTable: "Archivo",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
