using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;

namespace Top10Words;

public class BookCalculationsLinq
{
    private DataFromBook _dataFromBook;
    private IBookProcessor _bookProcessor;
    private readonly Consumer _consumer = new Consumer();
    public BookCalculationsLinq()
    {
        _dataFromBook = new DataFromBook(@"/Users/mariialeos/RiderProjects/Top10Words/Top10Words/Book.txt");
        _bookProcessor = new BookProcessor();
    }

    // public BookCalculationsLinq(DataFromBook dataFromBook, IBookProcessor bookProcessor)
    // {
    //     _dataFromBook = dataFromBook;
    //     _bookProcessor = bookProcessor;
    // }
    [Benchmark]
    public int GetAllWordsCount()
    {
        var wordsCount = _bookProcessor.GetWordsList(_dataFromBook.BookText).Count();
        return wordsCount;
    }

    [Benchmark]
    public void GetTop10FrequentWords()
    {
        (from word in _bookProcessor.GetWordsList(_dataFromBook.BookText)
                group word by word
                into cgroup
                let count = cgroup.Count()
                orderby count descending
                select new CountWordPair {Count = count, Word = cgroup.Key}).Take(10).Consume(_consumer);
    }
}