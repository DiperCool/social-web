using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Web.Models.Interfaces;

namespace Web.Infrastructure.FileWorkers
{
    public class FilesWorker : IFilesWorker
    {
        public async Task createFile(IFormFile photo, string path)
        {
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await photo.CopyToAsync(fileStream);
            }
        }
        public void deleteFile(string path)
        {
            System.IO.File.Delete(path);        
        }
    }
}