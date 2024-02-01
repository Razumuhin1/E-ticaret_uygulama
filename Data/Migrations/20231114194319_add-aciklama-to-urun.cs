using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asp.net_proje_denemesi.Data.Migrations
{
    /// <inheritdoc />
    public partial class addaciklamatourun : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                table: "Urun",
                type: "TEXT",
                maxLength: 40,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aciklama",
                table: "Urun");
        }
    }
}
