using Microsoft.AspNetCore.Identity;

namespace asp.net_proje_denemesi.Repositories
{
    public class KullaniciSiparisRepository : IKullaniciSiparisRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public KullaniciSiparisRepository(ApplicationDbContext db, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;

        }
        public async Task<IEnumerable<Siparis>> KullaniciSiparisleri()
        {
            var kullaniciId = GetUserId();
            if (string.IsNullOrEmpty(kullaniciId))
                throw new Exception("Kullanıcı oturum açmadı");
            var siparisler = await _db.Siparisler
                                .Include(x => x.SiparisDurumu)
                                .Include(x => x.SiparisDetayi)
                                .ThenInclude(x => x.Urun)
                                .ThenInclude(x => x.Kategori)
                                .Where(a => a.KullaniciId == kullaniciId)
                                .ToListAsync();
            return siparisler;
        }

        private string GetUserId()
        {
            var principal = _httpContextAccessor.HttpContext.User;
            string kullaniciId = _userManager.GetUserId(principal);
            return kullaniciId;
        }
    }
}
