using LystFiskerPortalenWEB.Data;
using LystFiskerPortalenWEB.Models;
using Microsoft.EntityFrameworkCore;

namespace LystFiskerPortalenWEB.Repo
{
    public class TechniqueRepo : ITechniqueRepo
    {
        private readonly IDbContextFactory<DataContext> _factory;

        public TechniqueRepo(IDbContextFactory<DataContext> factory)
        {
            _factory = factory;
        }

        public async Task CreateTech(Technique technique)
        {
            if (technique == null)
                return;

            using var context = _factory.CreateDbContext();

            context.Techniques.Add(technique);
            await context.SaveChangesAsync();
        }

        public async Task UpdateTech(Technique technique)
        {
            using var context = _factory.CreateDbContext();

            context.Techniques.Update(technique);
            await context.SaveChangesAsync();
        }

        public async Task DeleteTech(int id)
        {
            using var context = _factory.CreateDbContext();

            var technique = await context.Techniques.FindAsync(id);

            if (technique != null)
            {
                context.Techniques.Remove(technique);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Technique>> GetAllTechs()
        {
            using var context = _factory.CreateDbContext();

            return await context.Techniques.ToListAsync();
        }

        public async Task<Technique?> GetTechById(int id)
        {
            using var context = _factory.CreateDbContext();

            return await context.Techniques.FindAsync(id);
        }
    }
}
