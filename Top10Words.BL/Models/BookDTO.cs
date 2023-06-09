using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Top10Words.BL.Models
{
    public class BookDTO
    {
        public IFormFile FormFile { get; set; }
        public string AuthorName { get; set; }
        public int YearOfPublishing { get; set; }
    }
}
