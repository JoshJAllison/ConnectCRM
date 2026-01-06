using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConnectCRM.Migrations
{
    /// <inheritdoc />
    public partial class AddLatLngToAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Accounts",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Accounts",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Accounts");
        }
    }
}
