using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Top10Words.DAL.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string FileName { get; set; }
        public string BookText { get; set; }
        public string AuthorName { get; set; }
        public int YearOfPublishing { get; set; }
    }
}
