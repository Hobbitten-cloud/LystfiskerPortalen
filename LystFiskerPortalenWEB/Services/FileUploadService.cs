namespace LystFiskerPortalenWEB.Services
{
    public class FileUploadService : IFileUploadService
    {
        public async Task<string> UploadFile(IFormFile file)
        {
            try
            {
                var folderPath = Path.Combine("/Public/TestPictures/");
                var filePath = Path.Combine(folderPath, file.FileName);
                Directory.CreateDirectory(folderPath);
                await using var stream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(stream);
                return filePath;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
