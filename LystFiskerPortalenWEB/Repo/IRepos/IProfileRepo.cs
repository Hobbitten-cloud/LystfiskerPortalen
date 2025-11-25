using LystFiskerPortalenWEB.Models;

namespace LystFiskerPortalenWEB.Repo.IRepos
{
    public interface IProfileRepo
    {
        Task AddProfile(Profile profile);
        Task DeleteProfile(string id);
        Task<List<Profile>> GetAllProfiles();
        Task<Profile> GetProfileById(string id);
        Task UpdateProfile(Profile profile);
        
    }
}