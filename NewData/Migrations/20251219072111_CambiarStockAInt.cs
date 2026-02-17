using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewData.Migrations
{
    /// <inheritdoc />
    public partial class CambiarStockAInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Rol_RolId",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "RolId",
                table: "Usuarios",
                newName: "RoLId");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios",
                newName: "IX_Usuarios_RoLId");

            migrationBuilder.AlterColumn<int>(
                name: "Stock",
                table: "Productos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Rol_RoLId",
                table: "Usuarios",
                column: "RoLId",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Rol_RoLId",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "RoLId",
                table: "Usuarios",
                newName: "RolId");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_RoLId",
                table: "Usuarios",
                newName: "IX_Usuarios_RolId");

            migrationBuilder.AlterColumn<string>(
                name: "Stock",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Rol_RolId",
                table: "Usuarios",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
