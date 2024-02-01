using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asp.net_proje_denemesi.Data.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Urun_Siparis_SiparisId",
                table: "Urun");

            migrationBuilder.DropIndex(
                name: "IX_Urun_SiparisId",
                table: "Urun");

            migrationBuilder.DropColumn(
                name: "SiparisId",
                table: "Urun");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SiparisId",
                table: "Urun",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Urun_SiparisId",
                table: "Urun",
                column: "SiparisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Urun_Siparis_SiparisId",
                table: "Urun",
                column: "SiparisId",
                principalTable: "Siparis",
                principalColumn: "Id");
        }
    }
}
