namespace Top10Words;

public class BookCalculations
{
    private DataFromBook _dataFromBook;
    public BookCalculations(DataFromBook dataFromBook)
    {
        _dataFromBook = dataFromBook;
    }
    
    public int GetAllWordsCount()
    {
        var wordsCount = _dataFromBook.GetWordsList().Count();
        return wordsCount;
    }

    public IEnumerable<CountWordPair> GetTop10FrequentWords()
    {
        var top10words = 
                (from word in _dataFromBook.GetWordsList()
                    group word by word into cgroup
                    let count = cgroup.Count()
                    orderby count descending
                    select new CountWordPair { Count = count, Word = cgroup.Key }).Take(10);

            return top10words;
    }

    public IEnumerable<CountWordPair> GetTop10FrequentWords2()
    {
        var lines = new List<string>();
        var dict = new Dictionary<string, int>();
        foreach (var line in _dataFromBook.BookText)
        {
            var words = line.Split(" ");
            lines.AddRange(words);
        }

        foreach (var line in lines)
        {
            if (dict.ContainsKey(line))
            {
                dict[line]++;
            }
            else
            {
                dict[line] = 1;
            }
        }
        
        // you also need to take first 10 elements
        List<CountWordPair> countWordPairs = new List<CountWordPair>();
        foreach (var countWordPair in dict)
        {
            countWordPairs.Add(new CountWordPair(){Count = countWordPair.Value, Word = countWordPair.Key});
        }

        var countWordPairsEnumerable = countWordPairs.OrderByDescending(x => x.Count).Take(10);
        return countWordPairsEnumerable;
    }
}