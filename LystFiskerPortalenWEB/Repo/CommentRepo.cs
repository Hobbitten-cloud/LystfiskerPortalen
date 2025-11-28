using LystFiskerPortalenWEB.Data;
using LystFiskerPortalenWEB.Models;
using LystFiskerPortalenWEB.Repo.IRepos;
using Microsoft.EntityFrameworkCore;

namespace LystFiskerPortalenWEB.Repo
{
    public class CommentRepo : ICommentRepo
    {
        private DataContext _context;

        public CommentRepo(DataContext context)
        {
            _context = context;
        }

        public async Task CreateComment(Comment comment)
        {
            if (comment == null)
            {
                return;
            }
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteComment(int id)
        {
            var comment = await GetCommentById(id);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Comment>> GetAllComments()
        {
            return await _context.Comments.OrderByDescending(c => c.CreationDate).ToListAsync();
        }

        public async Task<Comment> GetCommentById(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task UpdateComment(Comment comment)
        {
            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();
        }
    }
}
