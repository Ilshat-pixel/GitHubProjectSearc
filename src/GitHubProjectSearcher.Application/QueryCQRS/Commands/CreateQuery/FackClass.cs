namespace QuickType
{
    using System;
    using AutoMapper;
    using GitHubProjectSearcher.Application.Interfaces;
    using GitHubProjectSearcher.Domain;
    using Newtonsoft.Json;

    public partial class JsonQuery
    {
        [JsonProperty("total_count")]
        public long TotalCount { get; set; }

        [JsonProperty("incomplete_results")]
        public bool IncompleteResults { get; set; }

        [JsonProperty("items")]
        public Item[] Items { get; set; }
    }

    public partial class Item:IMapWith<Card>
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("owner")]
        public JsonOwner Owner { get; set; }

        [JsonProperty("html_url")]
        public Uri HtmlUrl { get; set; }

        [JsonProperty("stargazers_count")]
        public long StargazersCount { get; set; }

        [JsonProperty("watchers_count")]
        public long WatchersCount { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Item, Card>()
                .ForMember(card => card.CardId,
                opt => opt.MapFrom(json => json.Id))
                .ForMember(card => card.Owner,
                opt => opt.MapFrom(json => json.Owner))
                .ForMember(card => card.StargazersCount,
                opt => opt.MapFrom(json => json.StargazersCount))
                .ForMember(card => card.Watchers,
                opt => opt.MapFrom(json => json.WatchersCount))
                .ForMember(card => card.ProjectLink,
                opt => opt.MapFrom(json => json.HtmlUrl))
                .ForMember(card=>card.Name,
                opt=>opt.MapFrom(json=>json.Name))
                .ReverseMap();
        }

    }

    public partial class JsonOwner:IMapWith<Owner>
    {
        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<JsonOwner, Owner>()
                .ForMember(owner => owner.Login,
                opt => opt.MapFrom(json => json.Login))
                .ForMember(login => login.OwnerId,
                opt => opt.MapFrom(json => json.Id))
                .ReverseMap();
        }
    }



}
