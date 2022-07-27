using _0_Framework.Application;

namespace HostApplication.Features
{
    public class FileUploader:IFileUploader
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUploader(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadFileAsync(IFormFile? file, string path)
        {
            if (file == null)
                return "";
            var directoryPath = $"{_webHostEnvironment.WebRootPath}//UploadedFiles//{path}";
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
            var fileName = $"{DateTime.Now.ToFileName()}-{file.FileName}";
            var filePath = $"{directoryPath}//{fileName}";
            await using var result=File.Create(filePath);
            await file.CopyToAsync(result);
            
            return  $"{path}//{fileName}";
        }

        public Task<List<string>> UploadFilesAsync(IFormCollection? file, string path)
        {
            throw new NotImplementedException();
        }
    }
}
