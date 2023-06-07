using Top10Words;

namespace Top10WordsTest;

[TestFixture(@"../../../Book.txt")]
public class BookCalculationsTests
{
    private readonly DataFromBook _dataFromBook;
    private readonly BookCalculationsLinq _bookCalculationsLinq;

    public BookCalculationsTests(string filename)
    {
        _dataFromBook = new DataFromBook(filename);
        var bookProcessor = new BookProcessor();
        _bookCalculationsLinq = new BookCalculationsLinq(_dataFromBook, bookProcessor);
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
        var ienumerable = _bookCalculationsLinq.GetTop10FrequentWords();
        var actual = new Dictionary<string, int>();
        foreach (var countWordPair in ienumerable)
        {
            actual.Add(countWordPair.Word, countWordPair.Count);
        }
        Assert.That(actual, Is.EquivalentTo(expected));
    }
}