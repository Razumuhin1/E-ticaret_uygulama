using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp.net_proje_denemesi.Models
{

    [Table("Siparis")]

    public class Siparis
    {
        public int Id { get; set; }

        [Required]

        public string? KullaniciId { get; set; }

        [Required]

        public DateTime SatinAlmaTarihi { get; set; } = DateTime.UtcNow;

        [Required]
        public int SiparisDurumuId { get; set; }

        public bool Silindi { get; set; } = false;
    
        public SiparisDurumu? SiparisDurumu { get; set; }
    
        public List<SiparisDetayi>? SiparisDetayi { get; set; }
    }
}
