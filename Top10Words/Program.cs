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

var bookCalculationsLinq = new BookCalculationsLinq(bookProcessor);
var bookCalculationsDictionary = new BookCalculationsDictionary(bookProcessor);

var watch = System.Diagnostics.Stopwatch.StartNew();

var top10Words = bookCalculationsLinq.GetTop10FrequentWords(dataFromBook.BookText);
var countWords = bookProcessor.GetWordsList(dataFromBook.BookText).Count();
var countUniqueWords = bookCalculationsDictionary.GetDictionaryWords(dataFromBook.BookText).Count;

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