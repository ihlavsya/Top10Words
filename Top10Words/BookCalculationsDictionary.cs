namespace Top10Words;

public class BookCalculationsDictionary:IBookCalculations
{
    private readonly DataFromBook _dataFromBook;
    private readonly IBookProcessor _bookProcessor;
    public BookCalculationsDictionary(DataFromBook dataFromBook, IBookProcessor bookProcessor)
    {
        _dataFromBook = dataFromBook;
        _bookProcessor = bookProcessor;
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