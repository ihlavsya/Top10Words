using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;

namespace Top10Words;

public class BookCalculationsDictionary:IBookCalculations
{
    private DataFromBook _dataFromBook;
    private IBookProcessor _bookProcessor;
    private readonly Consumer _consumer = new Consumer();
    // public BookCalculationsDictionary(DataFromBook dataFromBook, IBookProcessor bookProcessor)
    // {
    //     _dataFromBook = dataFromBook;
    //     _bookProcessor = bookProcessor;
    // }
    public BookCalculationsDictionary()
    {
        _dataFromBook = new DataFromBook(@"/Users/mariialeos/RiderProjects/Top10Words/Top10Words/Book.txt");
        _bookProcessor = new BookProcessor();
    }
    
    [Benchmark]
    public void GetTop10FrequentWords()
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
        
        // you also need to take first 10 elements
        List<CountWordPair> countWordPairs = new List<CountWordPair>();
        foreach (var countWordPair in dict)
        {
            countWordPairs.Add(new CountWordPair(){Count = countWordPair.Value, Word = countWordPair.Key});
        }

        countWordPairs.OrderByDescending(x => x.Count).Take(10).Consume(_consumer);
    }
}