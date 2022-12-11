using FileManagementSystem.Domain.Dtos;
using FileManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementSystem.Core.Interfaces
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
