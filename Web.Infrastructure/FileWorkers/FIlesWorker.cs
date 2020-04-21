using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Project.Models.Interfaces;

namespace Project.Models.Classes
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