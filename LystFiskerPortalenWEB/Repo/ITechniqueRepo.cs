using LystFiskerPortalenWEB.Models;

namespace LystFiskerPortalenWEB.Repo
{
    public interface ITechniqueRepo
    {

        Task CreateTech(TechniqueRepo technique);
        Task DeleteTech(int id);
        Task<List<TechniqueRepo>> GetAllTechs();
        Task<TechniqueRepo> GetTechById(int id);
        Task UpdateTech(TechniqueRepo technique);
    }
}
