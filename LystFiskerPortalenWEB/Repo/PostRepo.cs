using LystFiskerPortalenWEB.Models;
using LystFiskerPortalenWEB.Data;
using Microsoft.EntityFrameworkCore;

namespace LystFiskerPortalenWEB.Repo
{
    public class PostRepo : IPostRepo
    {
        private DataContext _context;

        public PostRepo(DataContext context)
        {
            _context = context;
        }

        public async Task CreatePost(Post post)
        {
            if (post == null)
            {
                return;
            }
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePost(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePost(int id)
        {
            var post = GetPostById(id).Result;

            if (post != null)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Post>> GetAllPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post> GetPostById(int id)
        {
            return await _context.Posts.FindAsync(id);
        }

    }
}
