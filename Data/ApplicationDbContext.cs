using asp.net_proje_denemesi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace asp.net_proje_denemesi.Data
{
    
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Urun> Urunler { get; set; }

        public DbSet<Kategori> Kategoriler { get; set; }

        public DbSet<AlisverisSepeti> Sepet { get; set; }

        public DbSet<SepetDetayi> SepetDetaylari { get; set; }

        public DbSet<Siparis> Siparisler { get; set; }

        public DbSet<SiparisDetayi> SiparisDetaylari { get; set; }

        public DbSet<SiparisDurumu> SiparisDurumlari { get; set; }
    }
}