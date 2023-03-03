namespace Top10Words;

public class BookCalculationsDictionary:IBookCalculations
{
    private DataFromBook _dataFromBook;
    private IBookProcessor _bookProcessor;
    public BookCalculationsDictionary(DataFromBook dataFromBook, IBookProcessor bookProcessor)
    {
        _dataFromBook = dataFromBook;
        _bookProcessor = bookProcessor;
    }
    
    public BookCalculationsDictionary()
    {
        var path = "../../../Book.txt";
        string fullPath = Path.GetFullPath(path);
        _dataFromBook = new DataFromBook(fullPath);
        _bookProcessor = new BookProcessor();
    }

    public Dictionary<string, int> GetDictionaryWords()
    {
        var words = _bookProcessor.GetWordsList(_dataFromBook.BookText);
        var dict = new Dictionary<string, int>();

        foreach (var word in words)
        {
            if (dict.ContainsKey(word))
            {
                dict[word]++;
            }
            else
            {
                dict[word] = 1;
            }
        }

        return dict;
    }

    public IEnumerable<CountWordPair> GetTop10FrequentWords()
    {
        var dict = GetDictionaryWords();
        
        // you also need to take first 10 elements
        List<CountWordPair> countWordPairs = new List<CountWordPair>();
        foreach (var countWordPair in dict)
        {
            countWordPairs.Add(new CountWordPair(){Count = countWordPair.Value, Word = countWordPair.Key});
        }

        var top10Words = countWordPairs.OrderByDescending(x => x.Count).Take(10);
        return top10Words;
    }
}