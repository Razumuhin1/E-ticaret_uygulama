using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace asp.net_proje_denemesi.Controllers
{
    [Authorize]
    public class SepetController : Controller
    {
        private readonly ISepetRepository _sepetRepo;

        public SepetController(ISepetRepository sepetRepo)
        {
            _sepetRepo = sepetRepo;
        }
        public async Task<IActionResult> UrunEkle(int urunId, int miktar = 1, int redirect = 0)
        {
            var sepetSayi = await _sepetRepo.UrunEkle(urunId, miktar);
            if (redirect == 0)
                return Ok(sepetSayi);
            return RedirectToAction("KullaniciSepet");
        }

        public async Task<IActionResult> UrunKaldir(int urunId)
        {
            var sepetSayi = await _sepetRepo.UrunKaldir(urunId);
            return RedirectToAction("KullaniciSepet");
        }

        public async Task<IActionResult> KullaniciSepet()
        {
            var sepet = await _sepetRepo.KullaniciSepet();
            return View(sepet);
        }

        public async Task<IActionResult> SepettekiToplamUrun()
        {
            int sepetUrun = await _sepetRepo.GetSepetUrunSayaci();
            return View(sepetUrun);
        }

        public async Task<IActionResult> SatinAl()
        {
            bool satinAlindi = await _sepetRepo.SatinAl();
            if (!satinAlindi)
                throw new Exception("Sunucu tarafında sıkıntı var");
            return RedirectToAction("Index", "Home");
        }
    }
}