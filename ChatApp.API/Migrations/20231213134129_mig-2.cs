using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatApp.API.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientConnectionId",
                table: "Celints");

            migrationBuilder.AddColumn<string>(
                name: "ConnectionId",
                table: "Celints",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConnectionId",
                table: "Celints");

            migrationBuilder.AddColumn<int>(
                name: "ClientConnectionId",
                table: "Celints",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
