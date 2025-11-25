using LystFiskerPortalenWEB.Models;

namespace LystFiskerPortalenWEB.Repo
{
    public interface ILureRepo
    {
        Task CreateLure(Lure lure);
        Task DeleteLure(int id);
        Task<List<Lure>> GetAllLures();
        Task<Lure> GetLureById(int id);
        Task UpdateLure(Lure lure);
    }
}

