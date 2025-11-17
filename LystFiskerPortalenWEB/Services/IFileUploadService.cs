
using Microsoft.AspNetCore.Components.Forms;

namespace LystFiskerPortalenWEB.Services
{
    public interface IFileUploadService
    {
        Task<string> UploadFile(IBrowserFile file);
    }
}