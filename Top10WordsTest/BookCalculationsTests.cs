using System.Collections;
using Top10Words;

namespace Top10WordsTest;

[TestFixture]
public class BookCalculationsTests
{
    private DataFromBook _dataFromBook;
    private BookCalculations _bookCalculations;

    [SetUp]
    public void Setup()
    {
        var bookFilename = @"../../../Book.txt";
        _dataFromBook = new DataFromBook(bookFilename);
        _bookCalculations = new BookCalculations(_dataFromBook);
    }

    [Test]
    public void GetAllWordsCount_Return10()
    {
        var expected = 10;
        var actual = _bookCalculations.GetAllWordsCount();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GetTop10FrequentWords_Return3Groups()
    {
        var expected = new Dictionary<string, int>()
        {
            {"the", 5},
            {"in", 3},
            {"beginning", 2}
        };
        var ienumerable = _bookCalculations.GetTop10FrequentWords();
        var actual = new Dictionary<string, int>();
        foreach (var countWordPair in ienumerable)
        {
            actual.Add(countWordPair.Word, countWordPair.Count);
        }
        Assert.That(actual, Is.EquivalentTo(expected));
    }
}