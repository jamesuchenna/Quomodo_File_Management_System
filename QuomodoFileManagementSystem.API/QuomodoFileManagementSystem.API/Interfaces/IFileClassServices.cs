namespace QuomodoFileManagementSystem.API.Interfaces
{
    public interface IFileClassServices
    {
        string UploadFile(IFormFile formFile, string folderPath);
        string DeleteFile(string filePath);
        string RenameFile(string fileName, string folderPath, string newFileName);
    }
}
