using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asp.net_proje_denemesi.Data.Migrations
{
    /// <inheritdoc />
    public partial class tabloisimleridegisti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SepetDetayi_AlisverisSepeti_AlisverisSepetiId",
                table: "SepetDetayi");

            migrationBuilder.DropForeignKey(
                name: "FK_SepetDetayi_Urun_UrunId",
                table: "SepetDetayi");

            migrationBuilder.DropForeignKey(
                name: "FK_Siparis_SiparisDurumu_SiparisDurumuId",
                table: "Siparis");

            migrationBuilder.DropForeignKey(
                name: "FK_SiparisDetayi_Siparis_SiparisId",
                table: "SiparisDetayi");

            migrationBuilder.DropForeignKey(
                name: "FK_SiparisDetayi_Urun_UrunId",
                table: "SiparisDetayi");

            migrationBuilder.DropForeignKey(
                name: "FK_Urun_Siparis_SiparisId",
                table: "Urun");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SiparisDurumu",
                table: "SiparisDurumu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SiparisDetayi",
                table: "SiparisDetayi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SepetDetayi",
                table: "SepetDetayi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlisverisSepeti",
                table: "AlisverisSepeti");

            migrationBuilder.RenameTable(
                name: "SiparisDurumu",
                newName: "Siparis Durumu");

            migrationBuilder.RenameTable(
                name: "SiparisDetayi",
                newName: "Siparis Detayi");

            migrationBuilder.RenameTable(
                name: "SepetDetayi",
                newName: "Sepet Detayi");

            migrationBuilder.RenameTable(
                name: "AlisverisSepeti",
                newName: "Alisveris Sepeti");

            migrationBuilder.RenameIndex(
                name: "IX_SiparisDetayi_UrunId",
                table: "Siparis Detayi",
                newName: "IX_Siparis Detayi_UrunId");

            migrationBuilder.RenameIndex(
                name: "IX_SiparisDetayi_SiparisId",
                table: "Siparis Detayi",
                newName: "IX_Siparis Detayi_SiparisId");

            migrationBuilder.RenameIndex(
                name: "IX_SepetDetayi_UrunId",
                table: "Sepet Detayi",
                newName: "IX_Sepet Detayi_UrunId");

            migrationBuilder.RenameIndex(
                name: "IX_SepetDetayi_AlisverisSepetiId",
                table: "Sepet Detayi",
                newName: "IX_Sepet Detayi_AlisverisSepetiId");

            migrationBuilder.AlterColumn<int>(
                name: "SiparisId",
                table: "Urun",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Siparis Durumu",
                table: "Siparis Durumu",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Siparis Detayi",
                table: "Siparis Detayi",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sepet Detayi",
                table: "Sepet Detayi",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alisveris Sepeti",
                table: "Alisveris Sepeti",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sepet Detayi_Alisveris Sepeti_AlisverisSepetiId",
                table: "Sepet Detayi",
                column: "AlisverisSepetiId",
                principalTable: "Alisveris Sepeti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sepet Detayi_Urun_UrunId",
                table: "Sepet Detayi",
                column: "UrunId",
                principalTable: "Urun",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Siparis_Siparis Durumu_SiparisDurumuId",
                table: "Siparis",
                column: "SiparisDurumuId",
                principalTable: "Siparis Durumu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Siparis Detayi_Siparis_SiparisId",
                table: "Siparis Detayi",
                column: "SiparisId",
                principalTable: "Siparis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Siparis Detayi_Urun_UrunId",
                table: "Siparis Detayi",
                column: "UrunId",
                principalTable: "Urun",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Urun_Siparis_SiparisId",
                table: "Urun",
                column: "SiparisId",
                principalTable: "Siparis",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sepet Detayi_Alisveris Sepeti_AlisverisSepetiId",
                table: "Sepet Detayi");

            migrationBuilder.DropForeignKey(
                name: "FK_Sepet Detayi_Urun_UrunId",
                table: "Sepet Detayi");

            migrationBuilder.DropForeignKey(
                name: "FK_Siparis_Siparis Durumu_SiparisDurumuId",
                table: "Siparis");

            migrationBuilder.DropForeignKey(
                name: "FK_Siparis Detayi_Siparis_SiparisId",
                table: "Siparis Detayi");

            migrationBuilder.DropForeignKey(
                name: "FK_Siparis Detayi_Urun_UrunId",
                table: "Siparis Detayi");

            migrationBuilder.DropForeignKey(
                name: "FK_Urun_Siparis_SiparisId",
                table: "Urun");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Siparis Durumu",
                table: "Siparis Durumu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Siparis Detayi",
                table: "Siparis Detayi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sepet Detayi",
                table: "Sepet Detayi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alisveris Sepeti",
                table: "Alisveris Sepeti");

            migrationBuilder.RenameTable(
                name: "Siparis Durumu",
                newName: "SiparisDurumu");

            migrationBuilder.RenameTable(
                name: "Siparis Detayi",
                newName: "SiparisDetayi");

            migrationBuilder.RenameTable(
                name: "Sepet Detayi",
                newName: "SepetDetayi");

            migrationBuilder.RenameTable(
                name: "Alisveris Sepeti",
                newName: "AlisverisSepeti");

            migrationBuilder.RenameIndex(
                name: "IX_Siparis Detayi_UrunId",
                table: "SiparisDetayi",
                newName: "IX_SiparisDetayi_UrunId");

            migrationBuilder.RenameIndex(
                name: "IX_Siparis Detayi_SiparisId",
                table: "SiparisDetayi",
                newName: "IX_SiparisDetayi_SiparisId");

            migrationBuilder.RenameIndex(
                name: "IX_Sepet Detayi_UrunId",
                table: "SepetDetayi",
                newName: "IX_SepetDetayi_UrunId");

            migrationBuilder.RenameIndex(
                name: "IX_Sepet Detayi_AlisverisSepetiId",
                table: "SepetDetayi",
                newName: "IX_SepetDetayi_AlisverisSepetiId");

            migrationBuilder.AlterColumn<int>(
                name: "SiparisId",
                table: "Urun",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SiparisDurumu",
                table: "SiparisDurumu",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SiparisDetayi",
                table: "SiparisDetayi",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SepetDetayi",
                table: "SepetDetayi",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlisverisSepeti",
                table: "AlisverisSepeti",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SepetDetayi_AlisverisSepeti_AlisverisSepetiId",
                table: "SepetDetayi",
                column: "AlisverisSepetiId",
                principalTable: "AlisverisSepeti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SepetDetayi_Urun_UrunId",
                table: "SepetDetayi",
                column: "UrunId",
                principalTable: "Urun",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Siparis_SiparisDurumu_SiparisDurumuId",
                table: "Siparis",
                column: "SiparisDurumuId",
                principalTable: "SiparisDurumu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SiparisDetayi_Siparis_SiparisId",
                table: "SiparisDetayi",
                column: "SiparisId",
                principalTable: "Siparis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SiparisDetayi_Urun_UrunId",
                table: "SiparisDetayi",
                column: "UrunId",
                principalTable: "Urun",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Urun_Siparis_SiparisId",
                table: "Urun",
                column: "SiparisId",
                principalTable: "Siparis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
