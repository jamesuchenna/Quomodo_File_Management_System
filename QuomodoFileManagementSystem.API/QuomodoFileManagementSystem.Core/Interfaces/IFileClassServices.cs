using FileManagementSystem.Domain.Dtos;
using FileManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace FileManagementSystem.Core.Interfaces
{
    public interface IFileClassServices
    {
        public string AddFile(IFormFile formFile, string folderPath);
        public string DeleteFile(string filePath);
        public List<string> GetFileNamesInFolder(string folderPath);
        public string RenameFile(string fileName, string folderPath, string newFileName);
        string CreateAsync(FileClassDto fileDto);
        Task<FileClass> UpdateAsync(FileClass file);
        Task UploadFile(IFormFile file, string path);
        Task DeleteAsync(FileClass fileClass);
        Task<FileClass> ReadAsync(string name, string path);
        Task<IEnumerable<FileClass>> ReadAllAsync();
    }
}
