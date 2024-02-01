using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asp.net_proje_denemesi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Addedtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlisverisSepeti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KullaniciId = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlisverisSepeti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kategori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KategoriAdi = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiparisDurumu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DurumAdi = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiparisDurumu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Siparis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KullaniciId = table.Column<string>(type: "TEXT", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SiparisDurumuId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Siparis_SiparisDurumu_SiparisDurumuId",
                        column: x => x.SiparisDurumuId,
                        principalTable: "SiparisDurumu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Urun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UrunAdi = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    Fiyat = table.Column<double>(type: "REAL", nullable: false),
                    Resim = table.Column<string>(type: "TEXT", nullable: true),
                    KategoriId = table.Column<int>(type: "INTEGER", nullable: false),
                    SiparisId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urun", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Urun_Kategori_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Urun_Siparis_SiparisId",
                        column: x => x.SiparisId,
                        principalTable: "Siparis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SepetDetayi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AlisverisSepetiId = table.Column<int>(type: "INTEGER", nullable: false),
                    UrunId = table.Column<int>(type: "INTEGER", nullable: false),
                    Miktar = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SepetDetayi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SepetDetayi_AlisverisSepeti_AlisverisSepetiId",
                        column: x => x.AlisverisSepetiId,
                        principalTable: "AlisverisSepeti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SepetDetayi_Urun_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urun",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SiparisDetayi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SiparisId = table.Column<int>(type: "INTEGER", nullable: false),
                    UrunId = table.Column<int>(type: "INTEGER", nullable: false),
                    Miktar = table.Column<int>(type: "INTEGER", nullable: false),
                    BirimFiyat = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiparisDetayi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiparisDetayi_Siparis_SiparisId",
                        column: x => x.SiparisId,
                        principalTable: "Siparis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SiparisDetayi_Urun_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urun",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SepetDetayi_AlisverisSepetiId",
                table: "SepetDetayi",
                column: "AlisverisSepetiId");

            migrationBuilder.CreateIndex(
                name: "IX_SepetDetayi_UrunId",
                table: "SepetDetayi",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_SiparisDurumuId",
                table: "Siparis",
                column: "SiparisDurumuId");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisDetayi_SiparisId",
                table: "SiparisDetayi",
                column: "SiparisId");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisDetayi_UrunId",
                table: "SiparisDetayi",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_Urun_KategoriId",
                table: "Urun",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Urun_SiparisId",
                table: "Urun",
                column: "SiparisId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SepetDetayi");

            migrationBuilder.DropTable(
                name: "SiparisDetayi");

            migrationBuilder.DropTable(
                name: "AlisverisSepeti");

            migrationBuilder.DropTable(
                name: "Urun");

            migrationBuilder.DropTable(
                name: "Kategori");

            migrationBuilder.DropTable(
                name: "Siparis");

            migrationBuilder.DropTable(
                name: "SiparisDurumu");
        }
    }
}
