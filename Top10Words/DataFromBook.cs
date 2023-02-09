namespace Top10Words;

public class DataFromBook
{
    private string _fileName;
    private IEnumerable<string> _bookText;
    public DataFromBook(string fileName)
    {
        _fileName = fileName;
        _bookText = File.ReadLines(_fileName);
    }
    
    public int GetAllWordsCount()
    {
        var wordsCount = _bookText.SelectMany(line => line.Split(" ")).Count();
        return wordsCount;
    }

    public IEnumerable<CountWordPair> GetTop10FrequentWords()
    {
        var top10words = 
            (from word in _bookText.SelectMany(line => line.Split(" "))
                group word by word into cgroup
                let count = cgroup.Count()
                orderby count descending
                select new CountWordPair { Count = count, Word = cgroup.Key }).Take(10);

        return top10words;
    }
}