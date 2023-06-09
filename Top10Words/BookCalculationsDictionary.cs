namespace Top10Words;

public class BookCalculationsDictionary:IBookCalculations
{
    private readonly IBookProcessor _bookProcessor;
    public BookCalculationsDictionary(IBookProcessor bookProcessor)
    {
        _bookProcessor = bookProcessor;
    }

    public Dictionary<string, int> GetDictionaryWords(IEnumerable<string> bookText)
    {
        var words = _bookProcessor.GetWordsList(bookText);
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

    public IEnumerable<CountWordPair> GetTop10FrequentWords(IEnumerable<string> bookText)
    {
        var dict = GetDictionaryWords(bookText);
        
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