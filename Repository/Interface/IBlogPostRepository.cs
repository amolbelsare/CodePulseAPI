using CodePulseAPI.Models.Domain;

namespace CodePulseAPI.Repository.Interface
{
    public interface IBlogPostRepository
    {
        Task<BlogPost> CreateAsync(BlogPost blogPost);

        Task<IEnumerable<BlogPost>> GetAllAsync();
    }
}
