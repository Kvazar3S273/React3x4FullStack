using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.IO;
using System.Threading.Tasks;

namespace React3x4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        [HttpGet]
        [Route("getfile/{name}")]
        public async Task<IActionResult> DownloadFile([FromRoute] string name)
        {

            string contentType = "";
            const string DefaultContentType = "application/octet-stream";
            string file = Directory.GetCurrentDirectory() +
                $"/data/{name}";

            var provider = new FileExtensionContentTypeProvider();

            if (!provider.TryGetContentType(file, out contentType))
            {
                contentType = DefaultContentType;
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(file);
            return File(bytes, contentType, Path.GetFileName(file));
        }
    }
}
