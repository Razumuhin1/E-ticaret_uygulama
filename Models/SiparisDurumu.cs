using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp.net_proje_denemesi.Models
{

    [Table("SiparisDurumu")]

    public class SiparisDurumu
    {
        internal object? Urun;

        public int Id { get; set; }
        
        [Required, MaxLength(20)]

        public string? DurumAdi { get; set; }

        [Required]
        public int SiparisDurumuId { get; set; }


    }
}
