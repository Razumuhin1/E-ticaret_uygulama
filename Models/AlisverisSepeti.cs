using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp.net_proje_denemesi.Models
{
    [Table("AlisverisSepeti")]
    public class AlisverisSepeti
    {
        public int Id { get; set; }

        [Required]

        public string? KullaniciId { get; set; }

        public bool Silindi { get; set; } = false;

        public ICollection<SepetDetayi>? SepetDetaylari { get; set; }
    }
}
