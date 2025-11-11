using LystFiskerPortalenWEB.Data;
using LystFiskerPortalenWEB.Models;
using Microsoft.EntityFrameworkCore;
namespace LystFiskerPortalenWEB.Repo
{
    public class ProfileRepo : IProfileRepo
    {
        private static List<Profile> profiles = new List<Profile>();

        private DataContext _context;

        public ProfileRepo(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Profile>> GetAllProfiles()
        {
            return await _context.Profiles.ToListAsync();
        }

        public async Task<Profile> GetProfileById(string id)
        {
            return await _context.Profiles.FindAsync(id);
        }
        public async Task AddProfile(Profile profile)
        {
            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateProfile(Profile profile)
        {
            _context.Profiles.Update(profile);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProfile(string id)
        {
            var profile = GetProfileById(id).Result;

            if (profile != null)
            {
                _context.Profiles.Remove(profile);
                await _context.SaveChangesAsync();
            }
        }
    }
}
