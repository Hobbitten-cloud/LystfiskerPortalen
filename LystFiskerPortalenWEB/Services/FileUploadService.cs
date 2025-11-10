namespace LystFiskerPortalenWEB.Services
{
    public class FileUploadService
    {
        async Task<string> UploadFile(IFormFile file)
        {

            //try
            //{
                var folderPath = Path.Combine("/wwwroot/Images");
                var filePath = Path.Combine(folderPath, file.FileName);
                Directory.CreateDirectory(folderPath);
                await using var stream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(stream);
                //string resultMessage = "Upload Succesful";
                return filePath;

            //}
            //catch (Exception ex) 
            //{
            //    resultMessage = ex.Message;
            //}

        }
    }
}
