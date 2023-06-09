namespace Top10Words;

public interface IBookCalculations
{
    public IEnumerable<CountWordPair> GetTop10FrequentWords(IEnumerable<string> bookText);
}