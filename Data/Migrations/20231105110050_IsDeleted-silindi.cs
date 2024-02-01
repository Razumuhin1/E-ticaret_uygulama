using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asp.net_proje_denemesi.Data.Migrations
{
    /// <inheritdoc />
    public partial class IsDeletedsilindi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Alisveris Sepeti",
                newName: "Silindi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Silindi",
                table: "Alisveris Sepeti",
                newName: "IsDeleted");
        }
    }
}
