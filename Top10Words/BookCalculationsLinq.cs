namespace Top10Words;

public class BookCalculationsLinq:IBookCalculations
{
    private readonly IBookProcessor _bookProcessor;

    public BookCalculationsLinq(IBookProcessor bookProcessor)
    {
        _bookProcessor = bookProcessor;
    }

    public IEnumerable<CountWordPair> GetTop10FrequentWords(IEnumerable<string> bookText)
    {
        var top10Words = 
            (from word in _bookProcessor.GetWordsList(bookText)
                group word by word
                into cgroup
                let count = cgroup.Count()
                orderby count descending
                select new CountWordPair {Count = count, Word = cgroup.Key}).Take(10);
        return top10Words;
    }
}