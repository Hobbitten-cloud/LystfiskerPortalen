using LystFiskerPortalenWEB.Models;
using Microsoft.EntityFrameworkCore;

namespace LystFiskerPortalenWEB.Repo.IRepos
{
    public interface IPostRepo
    {
        Task LikePost(Post post);
        Task CreatePost(Post post);
        Task DeletePost(int id);
        Task<List<Post>> GetAllPosts();
        Task<Post> GetPostById(int id);
        Task UpdatePost(Post post);
        Task<List<Post>> GetPostsByUser(string userId);
        
    }
}
