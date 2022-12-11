using Microsoft.AspNetCore.Mvc;
using QuomodoFileManagementSystem.API.Interfaces;
using System.Net;

namespace QuomodoFileManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderController : ControllerBase
    {
        private readonly IFolderServices _services;

        public FolderController(IFolderServices services)
        {
            _services = services;
        }

        [HttpPost("create-folder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateFolderAsync([FromQuery] string name, string path)
        {
            var newFolder = _services.AddFolder(name, path);
            return Ok(newFolder);
        }

        [HttpGet("get-all-files-in-folder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ReadAllFolderFilesAsync([FromQuery] string path)
        {
            var folders = _services.GetAllFolderFiles(path);
            return Ok(folders);
        }

        [HttpGet("get-all-subFolders")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ReadFolder(string path)
        {
            var folder = _services.GetFolder(path);
            return Ok(folder);
        }

        [HttpGet("get-all-subFolders-and-file")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAllSubFoldersAndFiles(string path)
        {
            var files = _services.GetAllSubFoldersAndFiles(path);
            return StatusCode((int)HttpStatusCode.OK, files);
        }

        [HttpPut("rename-folder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult RenameFolder(string folderName, string newFolderName, string parentPath)
        {
            _services.UpdateFolder(folderName, newFolderName, parentPath);
            return StatusCode((int)HttpStatusCode.NoContent);
        }

        [HttpDelete("delete-folder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteFolder(string name, string path)
        {
            _services.DeleteFolder(name, path);
            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}
