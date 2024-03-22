using API.Application.Contracts.DTOs.API;
using API.Application.Contracts.DTOs.Body;
using API.Application.Contracts.DTOs.Configuration;
using API.Application.Contracts.DTOs.Header;
using API.Application.Contracts.DTOs.HTTPMethod;
using API.Application.Contracts.DTOs.Tag;
using API.Application.Contracts.DTOs.URL;
using API.Domain.Models;
using AutoMapper;
namespace API.DataManager.AutoMapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<API.Domain.Models.API, APIDTO>().ReverseMap();
            CreateMap<APIType, APITypeDTO>().ReverseMap();
            CreateMap<Body, BodyDTO>().ReverseMap();
            CreateMap<BodyTag, BodyTagDTO>().ReverseMap();
            CreateMap<Configuration, ConfigurationDTO>().ReverseMap();
            CreateMap<Header, HeaderDTO>().ReverseMap();
            CreateMap<HeaderTag, HeaderTagDTO>().ReverseMap();
            CreateMap<HTTPMethods, HTTPMethodDTO>().ReverseMap();
            CreateMap<Tag, TagDTO>().ReverseMap();
            CreateMap<URL, URLDTO>().ReverseMap();
            CreateMap<URLTag, URLTagDTO>().ReverseMap();
        }
    }
}
