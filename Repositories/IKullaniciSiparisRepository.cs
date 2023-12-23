namespace asp.net_proje_denemesi.Repositories
{
    public interface IKullaniciSiparisRepository
    {
        Task<IEnumerable<Siparis>> KullaniciSiparisleri();
    }
}