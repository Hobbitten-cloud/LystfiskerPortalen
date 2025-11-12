using LystFiskerPortalenWEB.Data;
using LystFiskerPortalenWEB.Models;
using Microsoft.EntityFrameworkCore;


namespace LystFiskerPortalenWEB.Repo
{
    public class TechniqueRepo : ITechniqueRepo
    {
        private List<Technique> Techniques = new List<Technique>();
        private DataContext _context;

        public TechniqueRepo(DataContext context)
        {
            _context = context;
        }

        public async Task CreateTech(Technique technique)
        {
            if (technique == null)
            {
                return;
            }
            _context.Techniques
                .Add(technique);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTech(Technique technique)
        {
            _context.Techniques.Update(technique);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTech(int id)
        {
            var techique = GetTechById(id).Result;

            if (techique != null)
            {
                _context.Techniques.Remove(techique);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Technique>> GetAllTechs()
        {
            return await _context.Techniques.ToListAsync();
        }

        public async Task<Technique> GetTechById(int id)
        {
            return await _context.Techniques.FindAsync(id);
        }

        
    }
}
