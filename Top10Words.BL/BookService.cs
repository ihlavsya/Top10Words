using AutoMapper;
using System.Collections;
using System.IO;
using System.Text;
using Top10Words.BL.Models;
using Top10Words.DAL;
using Top10Words.DAL.Entities;

namespace Top10Words.BL
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IRepository<Book> bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task DeleteBook(int id)
        {
            await _bookRepository.Delete(id);
        }

        public async Task AddBook(BookDTO bookDTO)
        {
            string bookText;
            using (var stream = new MemoryStream())
            {
                await bookDTO.FormFile.CopyToAsync(stream);
                var bytes = stream.ToArray();
                bookText = Encoding.UTF8.GetString(bytes);

            }
            var book = new Book()
            {
                AuthorName = bookDTO.AuthorName,
                YearOfPublishing = bookDTO.YearOfPublishing,
                BookText = bookText,
                FileName = bookDTO.FormFile.FileName,
            };
            await _bookRepository.Create(book);
        }

        public IEnumerable<DisplayBookDTO> GetBooks()
        {
            var books = _bookRepository.Find(b => true);
            var booksDTO = _mapper.Map<IEnumerable<DisplayBookDTO>>(books);
            return booksDTO;
        }

        public BookStatistics GetBookStatistics(int id)
        {
            var book = _bookRepository.FindFirst(b => b.BookId == id);
            var bookProcessor = new BookProcessor();

            var bookCalculationsLinq = new BookCalculationsLinq(bookProcessor);
            var bookCalculationsDictionary = new BookCalculationsDictionary(bookProcessor);

            var bookText = book.BookText.Split("\n");

            var watch = System.Diagnostics.Stopwatch.StartNew();

            var top10Words = bookCalculationsLinq.GetTop10FrequentWords(bookText);
            var countWords = bookProcessor.GetWordsList(bookText).Count();
            var countUniqueWords = bookCalculationsDictionary.GetDictionaryWords(bookText).Count;

            watch.Stop();
            var statistics = new BookStatistics()
            {
                FileName = book.FileName,
                Top10Words = top10Words,
                CountWords = countWords,
                CountUniqueWords = countUniqueWords,
                TotalTimeOfProcessing = watch.ElapsedMilliseconds,
            };
            return statistics;
        }

    }
}