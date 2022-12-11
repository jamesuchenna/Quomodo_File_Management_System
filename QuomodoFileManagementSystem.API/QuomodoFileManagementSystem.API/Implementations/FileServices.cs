using QuomodoFileManagementSystem.API.Interfaces;

namespace FileManagementSystem.Core.Services
{
    public class FileServices : IFileServices
    {
        private readonly ILogger _logger;

        public FileServices(ILogger<FileServices> logger)
        {
            _logger = logger;
        }

        public string UploadFile(IFormFile file, string folderPath)
        {
            try
            {
                _logger.LogInformation($"Attempting to retrieve subfolders from {folderPath}");
                if (!Directory.Exists(folderPath))
                {
                    return "folder not found";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, $"Unable to create folder");
                return $"File not uploaded.";
            }

            var filePath = Path.Combine(folderPath, file.FileName);
            using (FileStream fs = File.Create(filePath))
                return file.Name;
        }
        public string DeleteFile(string filePath)
        {
            try
            {
                if (filePath == null)
                {
                    _logger.LogInformation($"File path is null.");
                    return "File path cannot be null.";
                }

                _logger.LogInformation($"Verifying {filePath} existence");
                if (!File.Exists(filePath))
                {
                    return "File path not found";
                }

                _logger.LogInformation($"File successfully deleted.");
                File.Delete(filePath);
                return "File sucessfully deleted.";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, $"Unable to delete file");
                return "File not deleted.";
            }
        }
        public string RenameFile(string fileName, string folderPath, string newFileName)
        {
            try
            {
                _logger.LogInformation($"Verifying {folderPath} existence");
                if (!Directory.Exists(folderPath))
                {
                    _logger.LogInformation($"{folderPath} does nont exist.");
                    return "file not found";
                }

                File.Move(Path.Combine(folderPath, fileName), Path.Combine(folderPath, newFileName));
                _logger.LogInformation($"{fileName} successfully renamed.");
                return "update successful";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, $"Unable to delete file");
                return $"Unable to rename {fileName}.";
            }
        }

    }
}
