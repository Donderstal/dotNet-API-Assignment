using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using XLSXReaderAPI.Services;

namespace XLSXReaderAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UploadController : ControllerBase
    {
        private readonly ILogger<UploadController> _logger;
        private readonly XLSXReader _xlsxReader;
        public UploadController(ILogger<UploadController> logger, XLSXReader xlsxReader )
        {
            _logger     = logger;
            _xlsxReader = xlsxReader;
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
