using FileManagementSystem.Core.Interfaces;
using Microsoft.AspNetCore.Http;

namespace QuomodoFileManagementSystem.Infrastructure.Repository
{
    public class FileRepository : IFileClassRepository
    {
        public string Upload(IFormFile file, string folderPath)
        {
            var filePath = Path.Combine(folderPath, file.FileName);
            using (FileStream fs = File.Create(filePath))
                return file.Name;
        }
        public string Delete(string filePath)
        {
            File.Delete(filePath);
            return "sucessfully deleted";
        }
        public string Rename(string fileName, string folderPath, string newFileName)
        {
            File.Move(Path.Combine(folderPath, fileName), Path.Combine(folderPath, newFileName));
            return "update successful";
        }
    }
}
