using Microsoft.EntityFrameworkCore;
using sonsuzKategori.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sonsuzKategori.contexts
{
    public class SqlDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\MsSqlLocalDb;database=ETicaret;Trusted_Connection=true;");
        }

        public DbSet<urunKategorileri> urunKategorileri { get; set; }
    }
}
