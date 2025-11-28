using LystFiskerPortalenWEB.Data;
using LystFiskerPortalenWEB.Models;
using LystFiskerPortalenWEB.Repo.IRepos;
using Microsoft.EntityFrameworkCore;

namespace LystFiskerPortalenWEB.Repo
{
    public class LureRepo : ILureRepo
    {
        private readonly IDbContextFactory<DataContext> _factory;

        public LureRepo(IDbContextFactory<DataContext> factory)
        {
            _factory = factory;
        }

        public async Task CreateLure(Lure lure)
        {
            if (lure == null)
                return;

            using var context = _factory.CreateDbContext();

            context.Lures.Add(lure);
            await context.SaveChangesAsync();
        }

        public async Task UpdateLure(Lure lure)
        {
            using var context = _factory.CreateDbContext();

            context.Lures.Update(lure);
            await context.SaveChangesAsync();
        }

        public async Task DeleteLure(int id)
        {
            using var context = _factory.CreateDbContext();

            var lure = await context.Lures.FindAsync(id);

            if (lure != null)
            {
                context.Lures.Remove(lure);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Lure>> GetAllLures()
        {
            using var context = _factory.CreateDbContext();

            return await context.Lures.ToListAsync();
        }

        public async Task<Lure?> GetLureById(int id)
        {
            using var context = _factory.CreateDbContext();

            return await context.Lures.FindAsync(id);
        }
    }
}
