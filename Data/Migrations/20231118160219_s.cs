using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asp.net_proje_denemesi.Data.Migrations
{
    /// <inheritdoc />
    public partial class s : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Siparis",
                newName: "Silindi");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Siparis",
                newName: "SatinAlmaTarihi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Silindi",
                table: "Siparis",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "SatinAlmaTarihi",
                table: "Siparis",
                newName: "CreateDate");
        }
    }
}
