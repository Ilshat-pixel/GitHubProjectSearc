using System.Text.Json.Serialization;
using AutoMapper;
using GitHubProjectSearcher.Application.Interfaces;
using GitHubProjectSearcher.Domain;
using Newtonsoft.Json;

namespace GitHubProjectSearcher.Application.QueryCQRS.Commands.CreateQuery
{
    //public class JsonCard:IMapWith<Card>
    //{
    //    [JsonProperty("id")]
    //    public int CardId { get; set; }
    //    [JsonProperty("owner")]
    //    public JsonOwner Owner { get; set; }
    //    [JsonProperty("stargazers_count")]
    //    public int StargazersCount { get; set; }
    //    [JsonPropertyName("watchers_count")]
    //    public int Watchers { get; set; }
    //    [JsonPropertyName("html_url")]
    //    public string ProjectLink { get; set; }
    //    public void Mapping(Profile profile)
    //    {
    //        profile.CreateMap<JsonCard, Card>()
    //            .ForMember(card => card.CardId,
    //            opt => opt.MapFrom(json => json.CardId))
    //            .ForMember(card => card.Owner,
    //            opt => opt.MapFrom(json => json.Owner))
    //            .ForMember(card => card.StargazersCount,
    //            opt => opt.MapFrom(json => json.StargazersCount))
    //            .ForMember(card => card.Watchers,
    //            opt => opt.MapFrom(json => json.Watchers))
    //            .ForMember(card => card.ProjectLink,
    //            opt => opt.MapFrom(json => json.ProjectLink))
    //            .ReverseMap();
    //    }
    //}
}
