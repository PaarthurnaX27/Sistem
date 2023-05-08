using System;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataAccessLayer.Concrete
{
    public class SmSecContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConfigurationsSmSec.ConnectionString);
        }

        public DbSet<Kullanici> Kullanicis { get; set; }
        public DbSet<SecCmp> SecCmps { get; set; }
        public DbSet<KullaniciFirma> KullaniciFirmas { get; set; }
    }


}


