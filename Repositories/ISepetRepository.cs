namespace asp.net_proje_denemesi.Repositories
{
    public interface ISepetRepository
    {
        Task<int> UrunEkle(int urunId, int miktar);
        Task<int> UrunKaldir(int urunId);
        Task<AlisverisSepeti> KullaniciSepet();
        Task<int> GetSepetUrunSayaci(string kullaniciId = "");
        Task<AlisverisSepeti> SepetAlma(string kullaniciId);
        Task<bool> SatinAl();
    }
}
