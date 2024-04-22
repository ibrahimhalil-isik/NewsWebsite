using Microsoft.EntityFrameworkCore;
using Shared.Entities;

namespace DataAccess.Context
{
    public class NewsContext : DbContext
    {
        public NewsContext(DbContextOptions<NewsContext> opt) : base(opt)
        {
            
        }
        DbSet<News> News { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Writer> Writers { get; set; }
        DbSet<Slide> Slides { get; set; }
    }
}
