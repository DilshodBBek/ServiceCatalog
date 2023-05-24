using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Addresses_StadiumId",
                table: "Addresses");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StadiumId",
                table: "Addresses",
                column: "StadiumId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Addresses_StadiumId",
                table: "Addresses");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StadiumId",
                table: "Addresses",
                column: "StadiumId");
        }
    }
}
