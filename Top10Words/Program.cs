// See https://aka.ms/new-console-template for more information

using Top10Words;

Console.WriteLine("Hello, World!");

var bookFilename = @"../../../Book.txt";
var dataFromBook = new DataFromBook(bookFilename);

var countWords = dataFromBook.GetAllWordsCount();

var csvFilename = "wordscount.txt";
var csvText = $"Words count: {countWords}";
File.WriteAllText(csvFilename, csvText);

var top10words = dataFromBook.GetTop10FrequentWords();

foreach (var countWordPair in top10words)
{
    Console.WriteLine(countWordPair);
}
Console.ReadLine();