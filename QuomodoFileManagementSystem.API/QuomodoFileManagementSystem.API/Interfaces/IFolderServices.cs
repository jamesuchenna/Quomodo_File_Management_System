namespace QuomodoFileManagementSystem.API.Interfaces
{
    public interface IFolderServices
    {
        List<string> GetAllSubFoldersAndFiles(string path);
        List<string> GetAllFolderFilesAsync(string path);
        List<string> GetFolderAsync(string path);
        string AddFolderAsync(string name, string path);
        void DeleteFolder(string name, string path);
        void UpdateFolderAsync(string folderName, string newFolderName, string parentPath);
    }
}
