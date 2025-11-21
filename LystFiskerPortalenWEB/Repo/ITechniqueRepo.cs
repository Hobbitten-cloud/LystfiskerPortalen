using LystFiskerPortalenWEB.Models;

namespace LystFiskerPortalenWEB.Repo
{
    public interface ITechniqueRepo
    {

        Task CreateTech(Technique technique);
        Task DeleteTech(int id);
        Task<List<Technique>> GetAllTechs();
        Task<Technique> GetTechById(int id);
        Task UpdateTech(Technique technique);
    }
}
