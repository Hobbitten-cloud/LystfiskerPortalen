using LystFiskerPortalenWEB.Models;
using LystFiskerPortalenWEB.Data;
using Microsoft.EntityFrameworkCore;
using LystFiskerPortalenWEB.Repo.IRepos;

namespace LystFiskerPortalenWEB.Repo
{
    public class PostRepo : IPostRepo
    {
        private DataContext _context;

        public PostRepo(DataContext context)
        {
            _context = context;
        }

        public async Task LikePost(Post post)
        {
            if (post == null)
            {
                return;
            }
            post.Likes = (post.Likes ?? 0) + 1;
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
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
            var post = await GetPostById(id);

            if (post != null)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Post>> GetAllPosts()
        {
            var posts = await _context.Posts
                .Include(p => p.Profile)
                .Include(p => p.Comments)
                .OrderByDescending(t => t.CreationDate)
                .ToListAsync();

            foreach (var post in posts)
            {
                post.Comments = post.Comments
                    .OrderBy(c => c.CreationDate)
                    .ToList();
            }

            return posts;
        }

        public async Task<Post> GetPostById(int id)
        {
            return await _context.Posts.Include(p => p.Profile).FirstAsync(p => p.Id == id);
        }

        public async Task<List<Post>> GetPostsByUser(string userId)
        {
            return await _context.Posts
                .Where(p => p.ProfileID == userId)
                .Include(p => p.Profile)
                .OrderByDescending(p => p.CreationDate)
                .ToListAsync();
        }
        public async Task<Post?> GetPostWithComments(int id)
        {
            return await _context.Posts
                .Include(p => p.Profile)
                .Include(p => p.Comments)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task DeleteComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
