using LystFiskerPortalenWEB.Models;

namespace LystFiskerPortalenWEB.Repo.IRepos
{
    public interface IPostRepo
    {
        Task CreatePost(Post post);
        Task DeletePost(int id);
        Task<List<Post>> GetAllPosts();
        Task<Post> GetPostById(int id);
        Task UpdatePost(Post post);
    }
}
