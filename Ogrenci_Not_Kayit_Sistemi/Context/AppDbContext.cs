using Microsoft.EntityFrameworkCore;
using Ogrenci_Not_Kayit_Sistemi.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Ogrenci_Not_Kayit_Sistemi.Context
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Ders> TblDers { get; set; }
        public DbSet<Kullanici> TblKullanici { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Ders>()
                .ToTable("TBL_DERS")
                .HasKey(x => x.OgrId);

            modelBuilder.Entity<Kullanici>()
                .ToTable("TBL_KULLANICI")
                .HasKey(x => x.KullaniciId);
        }
    }
}
