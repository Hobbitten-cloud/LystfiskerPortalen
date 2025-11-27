using LystFiskerPortalenWEB.Models;

namespace LystFiskerPortalenWEB.Services
{
    public interface ISortService
    {
        Task<List<Post>> SortByLikes();
        Task<List<Post>> SortByCreationDate();
    }
}
