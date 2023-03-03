using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Top10Words;

namespace Top10WordsBenchmarkTest;

public class BookCalculationsBenchmark
{
    private readonly Consumer _consumer = new Consumer();
    private readonly BookCalculationsLinq _bookCalculationsLinq = new BookCalculationsLinq();
    private readonly IBookCalculations _bookCalculationsDictionary = new BookCalculationsDictionary();

    [GlobalSetup]
    public void Setup()
    {
        while(!System.Diagnostics.Debugger.IsAttached)
            Thread.Sleep(TimeSpan.FromMilliseconds(100));
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
    
    [Benchmark]
    public void GetAllWordsCount()
    {
        _bookCalculationsLinq.GetAllWordsCount();
    }
}