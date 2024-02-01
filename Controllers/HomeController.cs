using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using asp.net_proje_denemesi.Models;
using asp.net_proje_denemesi.Models.DTOs;

namespace asp.net_proje_denemesi.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHomeRepository _homeRepository;

    public HomeController(ILogger<HomeController> logger, IHomeRepository homeRepository)
    {
        _logger = logger;
        _homeRepository = homeRepository;
    }

    public async Task<IActionResult> Index(string sterm="", int kategoriId=0)
    {
        IEnumerable<Urun> urun = await _homeRepository.GetUrun(sterm, kategoriId);
        IEnumerable<Kategori> kategoriler = await _homeRepository.Kategori();
        UrunGoruntulemeModeli urunmodel = new UrunGoruntulemeModeli()
        {
            Urun = urun,
            Kategori = kategoriler,
            STerm = sterm,
            KategoriId = kategoriId
        };
        return View(urunmodel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
