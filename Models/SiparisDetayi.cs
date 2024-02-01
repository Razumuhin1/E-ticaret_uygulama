using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp.net_proje_denemesi.Models
{

    [Table("SiparisDetayi")]

    public class SiparisDetayi
    {
        public int Id { get; set; }

        [Required]
        
        public int SiparisId { get; set; }

        [Required]

        public int UrunId { get; set; }

        [Required]

        public int Miktar { get; set; }

        [Required]

        public double BirimFiyat { get; set; }

        public Siparis? Siparis { get; set; }

        public Urun? Urun { get; set; }
    }
}
