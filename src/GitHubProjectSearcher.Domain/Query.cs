namespace GitHubProjectSearcher.Domain
{
    /// <summary>
    /// Прилетевший запрос на поиск
    /// </summary>
    public class Query
    {
        public int QueryId { get; set; }
        public string SearchString { get; set; }
        public ICollection<Card> Cards { get; set; }

    }
}
