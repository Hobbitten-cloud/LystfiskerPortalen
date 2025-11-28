using LystFiskerPortalenWEB.Models;

namespace LystFiskerPortalenWEB.Repo.IRepos
{
    public interface ICommentRepo
    {
        Task CreateComment(Comment comment);
        Task DeleteComment(int id);
        Task<List<Comment>> GetAllComments();
        Task<Comment> GetCommentById(int id);
        Task UpdateComment(Comment comment);
    }
}
