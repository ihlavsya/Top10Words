namespace Top10Words;

public class BookProcessor : IBookProcessor
{
    private static readonly char [] _delimiterChars = {
        ' ', ',', '.', ':', '\t'
    };
    public IEnumerable<string> GetWordsList(IEnumerable<string> bookText)
    {
        var wordsList = bookText
            .SelectMany(line => line.Split(_delimiterChars))
            .Where(str => str!=String.Empty)
            .Select(word => word.ToLower());
        return wordsList;
    }
}