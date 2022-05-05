namespace GitHubProjectSearcher.Domain
{
    /// <summary>
    /// Карточка проекта
    /// </summary>
    public class Card
    {
        public int CardId { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
        public int StargazersCount {get;set;}
        public int Watchers { get; set; }
        public string ProjectLink { get; set; }
        public string Name { get; set; }
    }
}
