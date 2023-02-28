using System.Collections.Generic;
using System.Linq;

namespace Top10Words;

public class BookProcessor:IBookProcessor
{
    public IEnumerable<string> GetWordsList(IEnumerable<string> bookText)
    {
        var wordsList = bookText
            .Select(Utils.RemoveSpecialCharacters)
            .SelectMany(line => line.Split(' '))
            .Select(word => word.ToLower()); 
        return wordsList;
    }
}