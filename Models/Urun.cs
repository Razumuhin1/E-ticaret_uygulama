using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp.net_proje_denemesi.Models
{
    [Table("Urun")]
    public class Urun
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string? UrunAdi { get; set; }
        
        [Required]
        [MaxLength(40)]
        public string? Aciklama { get; set; }

        [Required]

        public double Fiyat { get; set; }

        public string? Resim { get; set; }

        [Required]

        public int KategoriId { get; set; }

        public Kategori? Kategori { get; set; }

        public List<SiparisDetayi>? SiparisDetayi { get; set; }

        public List<SepetDetayi>? SepetDetayi { get; set; }

        [NotMapped]
        public string? KategoriAdi { get; set; }
    }
}
