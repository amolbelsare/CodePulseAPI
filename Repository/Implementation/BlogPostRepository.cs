using CodePulseAPI.Data;
using CodePulseAPI.Models.Domain;
using CodePulseAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CodePulseAPI.Repository.Implementation
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly ApplicationDbConetext _dbConetext;

        public BlogPostRepository(ApplicationDbConetext dbConetext)
        {
            this._dbConetext = dbConetext;
        }

        public async Task<BlogPost> CreateAsync(BlogPost blogPost)
        {
            await _dbConetext.BlogPosts.AddAsync(blogPost);
            await _dbConetext.SaveChangesAsync();
            return blogPost;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
           return await _dbConetext.BlogPosts.ToListAsync();
        }
    }
}
