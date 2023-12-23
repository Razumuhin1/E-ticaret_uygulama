using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace asp.net_proje_denemesi.Controllers
{
    [Authorize]
    public class KullaniciSiparisController : Controller
    {
        private readonly IKullaniciSiparisRepository _kullaniciSiparisRepository;

        public KullaniciSiparisController(IKullaniciSiparisRepository kullaniciSiparisRepository)
        {
            _kullaniciSiparisRepository = kullaniciSiparisRepository;
        }
        public async Task<IActionResult> KullaniciSiparisleri()
        {
            var siparisler = await _kullaniciSiparisRepository.KullaniciSiparisleri();
            return View(siparisler);
        }
    }
}
