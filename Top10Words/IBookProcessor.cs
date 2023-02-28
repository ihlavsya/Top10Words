using System.Collections.Generic;

namespace Top10Words;

public interface IBookProcessor
{
    public IEnumerable<string> GetWordsList(IEnumerable<string> bookText);
}