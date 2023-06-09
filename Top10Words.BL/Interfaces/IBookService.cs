using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Top10Words.BL.Models;
using Top10Words.DAL.Entities;

namespace Top10Words.BL
{
    public interface IBookService
    {
        Task AddBook(BookDTO bookDTO);
        Task DeleteBook(int id);
        IEnumerable<DisplayBookDTO> GetBooks();
        BookStatistics GetBookStatistics(int id);
    }
}
