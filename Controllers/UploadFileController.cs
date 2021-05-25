using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace TestApi2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UploadController : ControllerBase
    {
        private readonly ILogger<UploadController> _logger;

        public UploadController(ILogger<UploadController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> OnPostUploadAsync(IFormFile file)
        {
            if (IsProcessableExcelFile(file))
            {
                var filePath = Path.GetTempFileName();

                using (var fileStream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(fileStream);
                }
            }
            else {
                return UnprocessableEntity();
            }

            return Ok();
        }

        private bool IsProcessableExcelFile(IFormFile file)
        {
            string fileExtension = file.FileName.Split('.')[1];
            if ( file == null ) {
                return false;
            }
            if ( file.Length < 1 )
            {
                return false;
            }
            if ( fileExtension != "xlsx" )
            {
                return false;
            }
            return true;
        }
    }
}
