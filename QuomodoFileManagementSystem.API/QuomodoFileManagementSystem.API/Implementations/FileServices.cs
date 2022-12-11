using QuomodoFileManagementSystem.API.Interfaces;

namespace FileManagementSystem.Core.Services
{
    public class FileServices : IFileClassServices
    {

        public FileServices()
        {

        }

        public string UploadFile(IFormFile file, string folderPath)
        {
            try
            {

            if (!Directory.Exists(folderPath))
            {
                return "folder not found";
            }
            }
            catch (Exception)
            {

                throw;
            }

            var filePath = Path.Combine(folderPath, file.FileName);
            using (FileStream fs = File.Create(filePath))
                return file.Name;
        }
        public string DeleteFile(string filePath)
        {
            try
            {

            if (!File.Exists(filePath))
            {
                return "folder not found";
            }
            if (filePath == null)
            {
                return "specify file path";
            }

            File.Delete(filePath);
            return "sucessfully deleted";
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string RenameFile(string fileName, string folderPath, string newFileName)
        {
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    return "file not found";
                }
            File.Move(Path.Combine(folderPath, fileName), Path.Combine(folderPath, newFileName));
            return "update successful";
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
