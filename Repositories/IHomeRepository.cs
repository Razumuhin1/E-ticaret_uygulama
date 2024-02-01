namespace asp.net_proje_denemesi
{
    public interface IHomeRepository
    {
        Task<IEnumerable<Urun?>> GetUrun(string sTerm = "", int kategoriId = 0);
        Task<IEnumerable<Kategori>> Kategori();
    }
}