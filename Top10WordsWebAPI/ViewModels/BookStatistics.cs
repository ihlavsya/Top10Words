namespace Top10WordsWebAPI.ViewModels
{
    public class BookStatistics
    {
        public IEnumerable<string> Top10Books { get; init; }
        public int TotalWordsCount { get; init; }
        public int TotalUniqueWordsCount { get; init; }
        public long TotalTimeOfProcessing { get; init; }
    }
}
