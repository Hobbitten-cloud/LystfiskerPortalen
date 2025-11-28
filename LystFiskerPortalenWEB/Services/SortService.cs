using LystFiskerPortalenWEB.Data;
using LystFiskerPortalenWEB.Models;
using Microsoft.EntityFrameworkCore;

namespace LystFiskerPortalenWEB.Services
{
    public class SortService : ISortService
    {
        private DataContext _context;

        public SortService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Post>> SortByLikes()
        {
            return await _context.Posts.Include(p => p.Profile).OrderByDescending(t => t.Likes).ToListAsync();
        }

        public async Task<List<Post>> SortByCreationDate()
        {
            return await _context.Posts.Include(p => p.Profile).OrderByDescending(t => t.CreationDate).ToListAsync();
        }
    }
}
