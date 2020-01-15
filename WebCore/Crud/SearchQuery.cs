namespace WebCore.Crud
{
    public class SearchQuery : SearchQueryBase
    {
        public string Keyword { get; set; }
    }

    public class SearchQueryBase
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; } = 20;

        public string SortField { get; set; }

        public bool IsDesc { get; set; }
    }
}
