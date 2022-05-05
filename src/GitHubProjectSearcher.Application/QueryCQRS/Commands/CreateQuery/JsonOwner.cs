using System.Text.Json.Serialization;
using AutoMapper;
using GitHubProjectSearcher.Application.Interfaces;
using GitHubProjectSearcher.Domain;

namespace GitHubProjectSearcher.Application.QueryCQRS.Commands.CreateQuery
{
    //public class JsonOwner:IMapWith<Owner>
    //{
    //    [JsonPropertyName("id")]
    //    public int OwnerId { get; set; }
    //    [JsonPropertyName("login")]
    //    public string Login { get; set; }
    //    public void Mapping(Profile profile)
    //    {
    //        profile.CreateMap<JsonOwner, Owner>()
    //            .ForMember(owner => owner.Login,
    //            opt => opt.MapFrom(json => json.Login))
    //            .ForMember(login => login.ow,
    //            opt => opt.MapFrom(json => json.OwnerId))
    //            .ReverseMap();
    //    }
    //}
}
