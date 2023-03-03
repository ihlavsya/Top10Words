namespace Top10Words;

public class DataFromBook
{
    private readonly string _fileName;
    public IEnumerable<string> BookText;
    
    public DataFromBook(string fileName)
    {
        _fileName = fileName;
        if (_fileName != null) BookText = File.ReadLines(_fileName);
    }
    // remove it from here. this class should be almost empty
    // засунути цей метод в інший клас
    // думай як в тбе можуть бути багато книжок і багато різних імплементацій одного інтерфейсу
}