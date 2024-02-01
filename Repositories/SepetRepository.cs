using Microsoft.AspNetCore.Identity;

namespace asp.net_proje_denemesi.Repositories
{
    public class SepetRepository : ISepetRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SepetRepository(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<int> UrunEkle(int urunId, int miktar)
        {
            string kullaniciId = GetUserId();
            using var transaction = _db.Database.BeginTransaction();
            try
            {

                if (string.IsNullOrEmpty(kullaniciId))
                    throw new Exception("Kullanıcı oturum açmadı");

                var sepet = await SepetAlma(kullaniciId);

                if (sepet is null)
                {
                    sepet = new AlisverisSepeti
                    {
                        KullaniciId = kullaniciId
                    };
                    _db.Sepet.Add(sepet);
                }

                _db.SaveChanges();

                var sepetUrun = _db.SepetDetaylari.FirstOrDefault(a => a.AlisverisSepetiId == sepet.Id && a.UrunId == urunId);

                if (sepetUrun is not null)
                {
                    sepetUrun.Miktar += miktar;
                }
                else
                {
                    var urun = _db.Urunler.Find(urunId);
                    sepetUrun = new SepetDetayi
                    {
                        UrunId = urunId,
                        AlisverisSepetiId = sepet.Id,
                        Miktar = miktar,
                        BirimFiyat = urun.Fiyat
                    };
                    _db.SepetDetaylari.Add(sepetUrun);
                }

                _db.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
            }
            var sepettekiUrunSayisi = await GetSepetUrunSayaci(kullaniciId);
            return sepettekiUrunSayisi;
        }

        public async Task<int> UrunKaldir(int urunId)
        {
            string kullaniciId = GetUserId();
            try
            {

                if (string.IsNullOrEmpty(kullaniciId))
                    throw new Exception("Kullanıcı oturum açmadı");

                var sepet = await SepetAlma(kullaniciId);

                if (sepet is null)
                    throw new Exception("Geçersiz sepet");

                var sepetUrun = _db.SepetDetaylari.FirstOrDefault(a => a.AlisverisSepetiId == sepet.Id && a.UrunId == urunId);

                if (sepetUrun is null)
                    throw new Exception("Sepet Boş");

                else if (sepetUrun.Miktar == 1)
                    _db.SepetDetaylari.Remove(sepetUrun);
                else
                    sepetUrun.Miktar = sepetUrun.Miktar - 1;

                _db.SaveChanges();
            }
            catch (Exception ex)
            {
            }
            var sepettekiUrunSayisi = await GetSepetUrunSayaci(kullaniciId);
            return sepettekiUrunSayisi;
        }

        public async Task<AlisverisSepeti> KullaniciSepet()
        {
            var kullaniciId = GetUserId();
            if (kullaniciId == null)
                throw new Exception("geçersiz kullanıcı kimliği");
            var alisverisSepeti = await _db.Sepet
                                    .Include(a => a.SepetDetaylari)
                                    .ThenInclude(a => a.Urun)
                                    .ThenInclude(a => a.Kategori)
                                    .Where(a => a.KullaniciId == kullaniciId).FirstOrDefaultAsync();
            return alisverisSepeti;
        }

        public async Task<AlisverisSepeti> SepetAlma(string kullaniciId)
        {
            var sepet = await _db.Sepet.FirstOrDefaultAsync(x => x.KullaniciId == kullaniciId);
            return sepet;
        }

        public async Task<int> GetSepetUrunSayaci(string kullaniciId = "")
        {
            if (string.IsNullOrEmpty(kullaniciId))
            {
                kullaniciId = GetUserId();
            }
            var data = await (from sepet in _db.Sepet
                              join sepetDetayi in _db.SepetDetaylari
                              on sepet.Id equals sepetDetayi.AlisverisSepetiId
                              where sepet.KullaniciId == kullaniciId
                              select new { sepetDetayi.Id }
                              ).ToListAsync();
            return data.Count;
        }

        public async Task<bool> SatinAl()
        {
            using var transaction = _db.Database.BeginTransaction();
            try
            {
                var kullaniciId = GetUserId();
                if (string.IsNullOrEmpty(kullaniciId))
                    throw new Exception("Kullanıcı oturum açmadı");
                var sepet = await SepetAlma(kullaniciId);
                if (sepet is null)
                    throw new Exception("Geçersiz sepet");
                var sepetDetaylari = _db.SepetDetaylari
                                        .Where(a => a.AlisverisSepetiId == sepet.Id).ToList();
                if (sepetDetaylari.Count == 0)
                    throw new Exception("Sepet boş");
                var siparis = new Siparis
                {
                    KullaniciId = kullaniciId,
                    SatinAlmaTarihi = DateTime.UtcNow,
                    SiparisDurumuId = 1
                };
                _db.Siparisler.Add(siparis);
                _db.SaveChanges();
                foreach (var item in sepetDetaylari)
                {
                    var siparisDetayi = new SiparisDetayi
                    {
                        UrunId = item.UrunId,
                        SiparisId = siparis.Id,
                        Miktar = item.Miktar,
                        BirimFiyat = item.BirimFiyat
                    };
                    _db.SiparisDetaylari.Add(siparisDetayi);
                }
                _db.SaveChanges();

                _db.SepetDetaylari.RemoveRange(sepetDetaylari);
                _db.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private string GetUserId()
        {
            var principal = _httpContextAccessor.HttpContext.User;
            string kullaniciId = _userManager.GetUserId(principal);
            return kullaniciId;
        }
    }
}