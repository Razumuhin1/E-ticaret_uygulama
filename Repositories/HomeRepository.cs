using System.Diagnostics.Eventing.Reader;

namespace asp.net_proje_denemesi.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext _db;

        public HomeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Kategori>> Kategori()
        {
            return await _db.Kategoriler.ToListAsync();
        }
        public async Task<IEnumerable<Urun?>> GetUrun(string sTerm = "", int kategoriId = 0)
        {
            sTerm = sTerm.ToLower();
            IEnumerable<Urun> urunler = await (from urun in _db.Urunler
                           join kategori in _db.Kategoriler
                           on urun.KategoriId equals kategori.Id
                           where string.IsNullOrWhiteSpace(sTerm) || (urun !=null && urun.UrunAdi.ToLower().StartsWith(sTerm))
                           select new Urun
                           {
                               Id = urun.Id,
                               Resim = urun.Resim,
                               Aciklama = urun.Aciklama,
                               UrunAdi = urun.UrunAdi,
                               KategoriId = urun.KategoriId,
                               Fiyat = urun.Fiyat,
                               KategoriAdi = kategori.KategoriAdi,
                           }
                           ).ToListAsync();
            if(kategoriId > 0)
            {
                urunler = urunler.Where(a => a.KategoriId == kategoriId).ToList();
            }
            return urunler;
        }
    }
}
