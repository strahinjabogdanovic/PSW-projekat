using Integration.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration
{
    public class MyDbContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Drugs> DrugsInPharmacy { get; set; }
        public DbSet<Storage> DrugsInStorage { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(true);
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
