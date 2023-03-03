namespace Top10Words;

public class BookCalculationsLinq:IBookCalculations
{
    private readonly DataFromBook _dataFromBook;
    private IBookProcessor _bookProcessor;
    public BookCalculationsLinq()
    {
        var path = "../../../Book.txt";
        string fullPath = Path.GetFullPath(path);
        _dataFromBook = new DataFromBook(fullPath);
        _bookProcessor = new BookProcessor();
    }

    public BookCalculationsLinq(DataFromBook dataFromBook, IBookProcessor bookProcessor)
    {
        _dataFromBook = dataFromBook;
        _bookProcessor = bookProcessor;
    }

    public int GetAllWordsCount()
    {
        var wordsCount = _bookProcessor.GetWordsList(_dataFromBook.BookText).Count();
        return wordsCount;
    }
    
    public IEnumerable<CountWordPair> GetTop10FrequentWords()
    {
        var top10Words = 
            (from word in _bookProcessor.GetWordsList(_dataFromBook.BookText)
                group word by word
                into cgroup
                let count = cgroup.Count()
                orderby count descending
                select new CountWordPair {Count = count, Word = cgroup.Key}).Take(10);
        return top10Words;
    }
}