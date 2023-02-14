namespace Top10Words;

public class DataFromBook
{
    private string _fileName;
    public IEnumerable<string> BookText;

    // public IEnumerable<string> WordsList
    // {
    //     get
    //     {
    //         var wordsList = _bookText.SelectMany(line => line.Split(" "));
    //         return wordsList;
    //     }
    // }


    public DataFromBook(string fileName)
    {
        _fileName = fileName;
        BookText = File.ReadLines(_fileName);
    }

    public IEnumerable<string> GetWordsList()
    {
        var wordsList = BookText
            .Select(Utils.RemoveSpecialCharacters)
            .SelectMany(line => line.Split(' '))
            .Select(word => word.ToLower()); 
        return wordsList;
    }
}