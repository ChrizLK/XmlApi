using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using XmlApi.Models;
using static Azure.Core.HttpHeader;

namespace XmlApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
