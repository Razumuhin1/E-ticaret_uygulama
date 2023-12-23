using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace asp.net_proje_denemesi.Models
{
    [Table("Kategori")]
    public class Kategori
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string? KategoriAdi { get; set; }

        public List<Urun>? Urunler { get; set; }
    }
}
