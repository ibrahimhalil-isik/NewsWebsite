using Microsoft.EntityFrameworkCore;
using Shared.Entities;

namespace DataAccess.Context
{
    public class NewsContext : DbContext
    {
        public NewsContext(DbContextOptions<NewsContext> opt) : base(opt) { }       
        
        public DbSet<News> News { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Slide> Slides { get; set; }
    }
}
