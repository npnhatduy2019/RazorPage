using Microsoft.EntityFrameworkCore;

namespace RazorWeb.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
        }

        public DbSet<Article> Articles{get;set;}

        
    }
}