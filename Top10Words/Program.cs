// See https://aka.ms/new-console-template for more information

using Top10Words;

var bookFilename = @"../../../Book.txt";
var dataFromBook = new DataFromBook(bookFilename);

var bookCalculations = new BookCalculations(dataFromBook);
var countWords = bookCalculations.GetAllWordsCount();

var csvFilename = "wordscount.txt";
var csvText = $"Words count: {countWords}";
File.WriteAllText(csvFilename, csvText);

var top10words = bookCalculations.GetTop10FrequentWords();

foreach (var countWordPair in top10words)
{
    Console.WriteLine(countWordPair);
}
Console.ReadLine();