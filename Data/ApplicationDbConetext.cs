using CodePulseAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CodePulseAPI.Data
{
    public class ApplicationDbConetext : DbContext
    {
        public ApplicationDbConetext(DbContextOptions options) : base(options)
        {     
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
