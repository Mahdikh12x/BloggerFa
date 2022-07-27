using Microsoft.AspNetCore.Http;

namespace _0_Framework.Application
{
    public interface IFileUploader
    {
        Task<string> UploadFileAsync(IFormFile? file, string path);
        Task<List<string>>? UploadFilesAsync(IFormCollection? file, string path);
    }
}
