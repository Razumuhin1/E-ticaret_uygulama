using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp.net_proje_denemesi.Models
{

    [Table("SepetDetayi")]

    public class SepetDetayi
    {
        public int Id { get; set; }

        [Required]

        public int AlisverisSepetiId { get; set; }
        
        [Required]
        
        public int UrunId { get; set; }

        [Required]

        public int Miktar { get; set; }
        [Required]
        public double BirimFiyat { get; set; }

        public Urun? Urun { get; set; }

        public AlisverisSepeti? AlisverisSepeti { get; set; }
    }
}
