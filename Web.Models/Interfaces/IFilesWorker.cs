using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Web.Models.Interfaces
{
    public interface IFilesWorker
    {
        Task createFile(IFormFile file,string path);
        void deleteFile(string path); 
    }
}