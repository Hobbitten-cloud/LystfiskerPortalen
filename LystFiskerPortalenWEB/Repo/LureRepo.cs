using LystFiskerPortalenWEB.Data;
using LystFiskerPortalenWEB.Models;
using Microsoft.EntityFrameworkCore;


namespace LystFiskerPortalenWEB.Repo
{
    public class LureRepo : ILureRepo
    {
        private DataContext _context;

        public LureRepo(DataContext context)
        {
            _context = context;
        }

        public async Task CreateLure(Lure lure)
        {
            if (lure == null)
            {
                return;
            }
            _context.Lures
                .Add(lure);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLure(Lure lure)
        {
            _context.Lures.Update(lure);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLure(int id)
        {
            var lure = await GetLureById(id);

            if (lure != null)
            {
                _context.Lures.Remove(lure);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Lure>> GetAllLures()
        {
            return await _context.Lures.ToListAsync();
        }

        public async Task<Lure> GetLureById(int id)
        {
            return await _context.Lures.FindAsync(id);
        }
    }
}
