using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace Top10WordsWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        //[HttpPost]
        //public async Task<IActionResult> UploadBooksAsync(IFormFileCollection files)
        //{
            
        //}
    }
}