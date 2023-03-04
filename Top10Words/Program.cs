// See https://aka.ms/new-console-template for more information
using Top10Words;

//../../../Book.txt
var bookFilename = Console.ReadLine();
if (bookFilename == null)
{
    Console.WriteLine("you did not specify book filename");
    return;
}
var dataFromBook = new DataFromBook(bookFilename);
var bookProcessor = new BookProcessor();

var bookCalculationsLinq = new BookCalculationsLinq(dataFromBook, bookProcessor);
var bookCalculationsDictionary = new BookCalculationsDictionary(dataFromBook, bookProcessor);

var watch = System.Diagnostics.Stopwatch.StartNew();

var top10Words = bookCalculationsLinq.GetTop10FrequentWords();
var countWords = bookCalculationsLinq.GetAllWordsCount();
var countUniqueWords = bookCalculationsDictionary.GetDictionaryWords().Count;

watch.Stop();
var elapsedMs = watch.ElapsedMilliseconds;
foreach (var countWordPair in top10Words)
{
    Console.WriteLine(countWordPair);
}   
Console.ReadLine();
Console.WriteLine($"Total number of words: {countWords}");
Console.WriteLine($"Total number of uniq words: {countUniqueWords}");
Console.WriteLine($"Total time of processing milliseconds: {elapsedMs}");