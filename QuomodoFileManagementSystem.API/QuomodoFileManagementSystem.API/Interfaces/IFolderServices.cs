namespace QuomodoFileManagementSystem.API.Interfaces
{
    public interface IFolderServices
    {
        List<string> GetAllSubFoldersAndFiles(string path);
        List<string> GetAllFolderFiles(string path);
        List<string> GetFolder(string path);
        string AddFolder(string name, string path);
        string DeleteFolder(string name, string path);
        void UpdateFolder(string folderName, string newFolderName, string parentPath);
    }
}
