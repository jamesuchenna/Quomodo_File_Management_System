using System.IO;

namespace QuomodoFileManagementSystem.API.Interfaces
{
    public class FolderServices : IFolderServices
    {
        private readonly ILogger _logger;

        public FolderServices(ILogger<FolderServices> logger)
        {
            _logger = logger;
        }
        public string AddFolder(string name, string path)
        {
            try
            {
                _logger.LogInformation($"Checking for {path} existence");
                if (!Directory.Exists(Path.Combine(path, name)))
                {
                    _logger.LogInformation($"Creating {path} as it does not exist");
                    Directory.CreateDirectory(Path.Combine(path, name));
                }
                _logger.LogInformation($"{path} sucessfully created");
                return $"{name} folder Created successfully";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, $"Unable to create folder");
                return $"{name} folder not created";
            }
        }

        public string DeleteFolder(string name, string path)
        {
            var dir = Path.Combine(path, name);
            try
            {
                _logger.LogInformation($"Checking for {dir} existence");
                if (Directory.Exists(dir))
                {
                    _logger.LogInformation($"{name} folder successfully deleted");
                    Directory.Delete(dir, true);
                }
                return $"{name} folder successfully deleted";
            }
            catch (Exception)
            {
                return $"Unable to delete {name} folder.";

            }
        }

        public List<string> GetAllFolderFiles(string path)
        {
            List<string> result = new List<string>();
            try
            {
                _logger.LogInformation($"Attempting to retrieve subfolders from {path}");
                string[] filePaths = Directory.GetFiles(path);

                foreach (string ss in filePaths)
                {
                    var d = (Path.GetFileName(ss));
                    result.Add(d);
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, $"Unable to retieve subfolders from {path}");
                throw;
            }
        }
        public List<string> GetAllSubFoldersAndFiles(string path)
        {
            try
            {
                _logger.LogInformation($"Attempting to retrieve subfolders and files from {path}");
                List<string> result = new List<string>();
                string[] filePaths = Directory.GetFiles(path);

                foreach (string folder in filePaths)
                {
                    var directory = (Path.GetFileName(folder));
                    result.Add(directory);
                }

                string[] dirs = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly);
                foreach (string folder in dirs)
                {
                    var directory = (Path.GetFileName(folder));
                    result.Add(directory);
                }
                return result;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message, $"Unable to retieve subfolders and files from {path}");
                throw;
            }
        }

        public List<string> GetFolder(string path)
        {
            try
            {
                _logger.LogInformation($"Attempting to retrieve subfolders from {path}");
                List<string> result = new List<string>();
                var dir = path;
                string[] filePaths = Directory.GetFiles(dir);

                string[] dirs = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly);

                foreach (string ss in dirs)
                {
                    var d = (Path.GetFileName(ss));
                    result.Add(d);
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, $"Unable to create folder");
                throw;
            }
        }

        public void UpdateFolder(string folderName, string newFolderName, string path)
        {
            try
            {
                _logger.LogInformation($"Attempting to rename {folderName} folder");
                Directory.Move(Path.Combine(path, folderName), Path.Combine(path, newFolderName));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, $"Unable to rename folder");
                throw;
            }
        }
    }
}
