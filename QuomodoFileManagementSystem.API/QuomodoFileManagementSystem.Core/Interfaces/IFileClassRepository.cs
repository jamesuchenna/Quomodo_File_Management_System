using Microsoft.AspNetCore.Http;

namespace FileManagementSystem.Core.Interfaces
{
    public interface IFileClassRepository
    {
        public string Upload(IFormFile file, string folderPath);
        public string Delete(string filePath);
        public string Rename(string fileName, string folderPath, string newFileName);
    }
}
