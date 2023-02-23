namespace Top10Words;

public class CountWordPair
{
    public int Count { get; init; }
    public string? Word { get; init; }

    public override string ToString()
    {
        var countWordPair = $"count: {Count}, word: {Word}";
        return countWordPair;
    }
}