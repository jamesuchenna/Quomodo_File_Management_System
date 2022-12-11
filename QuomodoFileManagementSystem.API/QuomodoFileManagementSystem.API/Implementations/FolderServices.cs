namespace QuomodoFileManagementSystem.API.Interfaces
{
    public class FolderServices : IFolderServices
    {
        public FolderServices()
        {

        }
        public string AddFolderAsync(string name, string path)
        {
            try
            {
                if (!Directory.Exists(Path.Combine(path, name)))
                {
                    Directory.CreateDirectory(Path.Combine(path, name));
                }
                return $"{name} folder Created successfully";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteFolder(string name, string path)
        {
            try
            {
                var dir = Path.Combine(path, name);
                if (Directory.Exists(dir))
                {
                    Directory.Delete(dir, true);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<string> GetAllFolderFilesAsync(string path)
        {
            try
            {
                List<string> result = new List<string>();
                string[] filePaths = Directory.GetFiles(path);

                foreach (string ss in filePaths)
                {
                    var d = (Path.GetFileName(ss));
                    result.Add(d);
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<string> GetAllSubFoldersAndFiles(string path)
        {
            try
            {
                List<string> result = new List<string>();
                string[] filePaths = Directory.GetFiles(path);

                foreach (string ss in filePaths)
                {
                    var d = (Path.GetFileName(ss));
                    result.Add(d);
                }

                string[] dirs = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly);
                foreach (string ss in dirs)
                {
                    var d = (Path.GetFileName(ss));
                    result.Add(d);
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<string> GetFolderAsync(string path)
        {
            try
            {
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
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateFolderAsync(string folderName, string newFolderName, string parentPath)
        {
            try
            {
                Directory.Move(Path.Combine(parentPath, folderName), Path.Combine(parentPath, newFolderName));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
