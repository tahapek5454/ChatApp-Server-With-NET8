using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatApp.API.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Celints_Users_UserId",
                table: "Celints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Celints",
                table: "Celints");

            migrationBuilder.RenameTable(
                name: "Celints",
                newName: "Clients");

            migrationBuilder.RenameIndex(
                name: "IX_Celints_UserId",
                table: "Clients",
                newName: "IX_Clients_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_UserId",
                table: "Clients",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_UserId",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Celints");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_UserId",
                table: "Celints",
                newName: "IX_Celints_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Celints",
                table: "Celints",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Celints_Users_UserId",
                table: "Celints",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
