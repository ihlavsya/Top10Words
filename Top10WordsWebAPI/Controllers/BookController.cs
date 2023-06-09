using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using Top10Words.BL;
using Top10Words.BL.Models;
using Top10WordsWebAPI.ViewModels;

namespace Top10WordsWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IMapper _mapper;
        private readonly IBookService _bookService;

        public BookController(ILogger<BookController> logger, IBookService bookService, IMapper mapper)
        {
            _logger = logger;
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> UploadBookAsync([FromForm] FileViewModel file)
        {
            BookDTO book = _mapper.Map<BookDTO>(file);
            await _bookService.AddBook(book);
            return Ok(book);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookService.DeleteBook(id);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _bookService.GetBooks();
            return Ok(books);
        }

        [HttpGet]
        [Route("statistics")]
        public IActionResult GetStatistics(int id)
        {
            var books = _bookService.GetBookStatistics(id);
            return Ok(books);
        }
    }
}