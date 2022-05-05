namespace GitHubProjectSearcher.Domain
{
    /// <summary>
    /// Прилетевший запрос на поиск
    /// </summary>
    public class Query
    {
        public int QueryId { get; set; }
        public string SearchString { get; set; }
        public IList<Card> Cards { get; set; }

    }
}
