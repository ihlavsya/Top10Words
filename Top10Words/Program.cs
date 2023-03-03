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

var top10Words = bookCalculationsLinq.GetTop10FrequentWords();

foreach (var countWordPair in top10Words)
{
    Console.WriteLine(countWordPair);
}
Console.ReadLine();
var countWords = bookCalculationsLinq.GetAllWordsCount();
var countUniqueWords = bookCalculationsDictionary.GetDictionaryWords().Count;

Console.WriteLine($"Total number of words: {countWords}");
Console.WriteLine($"Total number of uniq words: {countUniqueWords}");
