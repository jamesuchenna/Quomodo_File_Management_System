using FileManagementSystem.Domain.Dtos;
using FileManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementSystem.Core.Interfaces
{
    public interface IFolderRepository
    {
        Task<IEnumerable<Folder>> GetAllFoldersAsync();
        Folder GetFolderAsync(string name, string path);
        Folder GetFolderByPathAsync(string path);
        Task<Folder> AddFolderAsync(Folder folder);
        Task DeleteFolderAsync(string name, string path);
        Task UpdateFolderAsync(string folderName, string newFolderName, string parentPath);
    }
}
