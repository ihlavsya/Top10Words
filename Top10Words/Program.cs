// See https://aka.ms/new-console-template for more information

using System;
using BenchmarkDotNet.Running;
using Top10Words;
//
// var bookFilename = @"../../../Book.txt";
// var dataFromBook = new DataFromBook(bookFilename);
// var bookProcessor = new BookProcessor();
//
// var bookCalculations = new BookCalculationsLinq(dataFromBook, bookProcessor);
// var countWords = bookCalculations.GetAllWordsCount();
//
// var csvFilename = "wordscount.txt";
// var csvText = $"Words count: {countWords}";
// File.WriteAllText(csvFilename, csvText);
//
// var top10Words = bookCalculations.GetTop10FrequentWords();
//
// foreach (var countWordPair in top10Words)
// {
//     Console.WriteLine(countWordPair);
// }
var summary1 = BenchmarkRunner.Run<BookCalculationsLinq>();
var summary2 = BenchmarkRunner.Run<BookCalculationsDictionary>();
Console.ReadLine();