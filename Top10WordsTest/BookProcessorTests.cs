using Top10Words;

namespace Top10WordsTest;

[TestFixture]
public class BookProcessorTests
{
    private readonly BookProcessor _bookProcessor;

    public BookProcessorTests()
    {
        _bookProcessor = new BookProcessor();
    }

    [Test]
    public void GetWordsListTest()
    {
        var str1 = "Revelation 22:10	And he saith unto me";
        var str2 = "Revelation 22:11	He that is unjust, let him be unjust still: and he which is filthy";

        var arrStr = new[] {str1, str2};

        var expected = new[]
        {
            "revelation", "22", "10", "and", "he", "saith", "unto", "me",
            "revelation", "22", "11", "he", "that", "is", "unjust", "let", "him", "be", "unjust", "still", "and", "he",
            "which", "is", "filthy",
        };
        var actual = _bookProcessor.GetWordsList(arrStr);

        Assert.That(actual, Is.EqualTo(expected));
    }
}