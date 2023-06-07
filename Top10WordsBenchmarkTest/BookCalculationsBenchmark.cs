using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Top10Words;

namespace Top10WordsBenchmarkTest;

public class BookCalculationsBenchmark
{
    private readonly Consumer _consumer = new Consumer();

    private readonly IBookCalculations _bookCalculationsLinq;
    private readonly IBookCalculations _bookCalculationsDictionary;

    public BookCalculationsBenchmark()
    {
        var path = "Book.txt";
        var _dataFromBook = new DataFromBook(path);
        var _bookProcessor = new BookProcessor();
        _bookCalculationsDictionary = new BookCalculationsDictionary(_dataFromBook, _bookProcessor);
        _bookCalculationsLinq = new BookCalculationsLinq(_dataFromBook, _bookProcessor);
    }

    [Benchmark]
    public void GetTop10FrequentWordsLinq()
    {
        _bookCalculationsLinq.GetTop10FrequentWords().Consume(_consumer);
    }
    
    [Benchmark]
    public void GetTop10FrequentWordsDictionary()
    {
        _bookCalculationsDictionary.GetTop10FrequentWords().Consume(_consumer);
    }
}