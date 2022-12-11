using Microsoft.AspNetCore.Mvc;
using QuomodoFileManagementSystem.API.Interfaces;
using System.Net;

namespace QuomodoFileManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileServices _services;
        public FileController(IFileServices services)
        {
            _services = services;
        }

        [HttpPost("upload-file")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UploadFile(IFormFile fileForm, string path)
        {
            var file = _services.UploadFile(fileForm, path);
            return StatusCode((int)HttpStatusCode.Created, file);
        }

        [HttpDelete("delete-file")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteFile(string filePath)
        {
            var file = _services.DeleteFile(filePath);
            return StatusCode((int)HttpStatusCode.OK, file);
        }

        [HttpPut("rename-file")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RenameFile(string fileName, string folderPath, string newFileName)
        {
            var file = _services.RenameFile(fileName, folderPath, newFileName);
            return StatusCode((int)HttpStatusCode.NoContent, file);
        }
    }
}
