using AutoMapper;
using Gamestore.ApplicationServices.Models;
using Gamestore.ApplicationServices.Requests.Platforms;
using Gamestore.DataAccess.Entities;

namespace Gamestore.ApplicationServices.Mappings;
public class PlatformsProfile : Profile
{
    public PlatformsProfile()
    {
        CreateMap<Platform, PlatformListingModel>()
            .ForMember(dto => dto.Id, y => y.MapFrom(model => model.Id))
            .ForMember(dto => dto.Type, y => y.MapFrom(model => model.Type.ToString()));

        CreateMap<Platform, PlatformDetailsModel>()
            .ForMember(dto => dto.Id, y => y.MapFrom(model => model.Id))
            .ForMember(dto => dto.Type, y => y.MapFrom(model => model.Type.ToString()))
            .ForMember(dto => dto.Games, y => y.MapFrom(model => model.Games != null ? model.Games.Select(x => x.GameAlias) : new List<string>()));

        CreateMap<AddPlatformRequest, Platform>()
             .ForMember(dto => dto.Type, y => y.MapFrom(model => model.Type))
             .ForMember(dto => dto.Description, y => y.MapFrom(model => model.Description));

        CreateMap<UpdatePlatformRequest, Platform>()
            .ForMember(dto => dto.Id, y => y.MapFrom(model => model.Id))
            .ForMember(dto => dto.Type, y => y.MapFrom(model => model.Type))
            .ForMember(dto => dto.Description, y => y.MapFrom(model => model.Description));
    }
}
