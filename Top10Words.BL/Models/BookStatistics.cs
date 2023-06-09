using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Top10Words;

namespace Top10Words.BL.Models
{
    public class BookStatistics
    {
        public string FileName { get; set; }
        public IEnumerable<CountWordPair> Top10Words { get; set; }
        public int CountWords { get; set; }
        public int CountUniqueWords { get; set; }
        public long TotalTimeOfProcessing { get; init; }
    }
}
