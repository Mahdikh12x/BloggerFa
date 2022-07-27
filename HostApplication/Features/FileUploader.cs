using _0_Framework.Application;

namespace HostApplication.Features
{
    public class FileUploader : IFileUploader
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

            var directoryPath = CreateDirectoryPath(path);

            var fileName = $"{DateTime.Now.ToFileName()}-{file.FileName}";
            var filePath = $"{directoryPath}//{fileName}";
            await using var result = File.Create(filePath);
            await file.CopyToAsync(result);

            return $"{path}//{fileName}";
        }

        public async Task<List<string>>? UploadFilesAsync(IFormCollection? files, string path)
        {
            var pathList = new List<string>();
            if (files == null)
                return pathList;

            var directoryPath = CreateDirectoryPath(path);

            foreach (var file in files.Files)
            {
                var fileName = $"{DateTime.Now.ToFileName()}-{file.FileName}";
                var filePath = $"{directoryPath}//{fileName}";
                await using var result = File.Create(filePath);
                await file.CopyToAsync(result);
                var currentPath = $"{path}//{fileName}";
                pathList.Add(currentPath);
            }

            return pathList;
        }

        private string CreateDirectoryPath(string path)
        {
            var directoryPath = $"{_webHostEnvironment.WebRootPath}//UploadedFiles//{path}";
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
            return directoryPath;
        }




    }
}
