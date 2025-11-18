using Microsoft.AspNetCore.Components.Forms;

namespace LystFiskerPortalenWEB.Services
{
	public class FileUploadService : IFileUploadService
	{
		public async Task<string> UploadFile(IBrowserFile file, string endPath)
		{
			try
			{
				var folderPath = Path.Combine($"wwwroot/public/Images/{endPath}");

				var filePath = Path.Combine(folderPath, file.Name);
				filePath = filePath.Replace(@"\", "/");
				Directory.CreateDirectory(folderPath);
				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					await file.OpenReadStream(10 * 1024 * 1024).CopyToAsync(stream);
				}

				return filePath.Replace("wwwroot", "");
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}
	}
}