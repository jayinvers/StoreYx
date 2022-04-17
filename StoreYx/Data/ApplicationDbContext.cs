using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoreYx.Models;

namespace StoreYx.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Page> Page { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<Career> Career { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}