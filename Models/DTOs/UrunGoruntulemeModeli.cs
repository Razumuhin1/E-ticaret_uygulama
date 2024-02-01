namespace asp.net_proje_denemesi.Models.DTOs
{
    public class UrunGoruntulemeModeli
    {
        public IEnumerable<Urun> Urun { get; set; }

        public IEnumerable<Kategori> Kategori { get; set; }

        public string STerm { get; set; } = "";

        public int KategoriId { get; set; } = 0;
    }
}
