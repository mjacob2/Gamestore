using AutoMapper;
using Gamestore.ApplicationServices.Models;
using Gamestore.ApplicationServices.Requests.Games;
using Gamestore.DataAccess.Entities;

namespace Gamestore.ApplicationServices.Mappings;

public class GamesProfile : Profile
{
    public GamesProfile()
    {
        CreateMap<Game, GameListingModel>()
            .ForMember(dto => dto.GameAlias, y => y.MapFrom(model => model.GameAlias))
            .ForMember(dto => dto.Name, y => y.MapFrom(model => model.Name))
            .ForMember(dto => dto.Price, y => y.MapFrom(model => model.Price))
            .ForMember(dto => dto.UnitInStock, y => y.MapFrom(model => model.UnitInStock))
            .ForMember(dto => dto.Discontinued, y => y.MapFrom(model => model.Discontinued))
            .ForMember(dto => dto.GenresNames, y => y.MapFrom(model => model.Genres.Select(c => c.Name).ToList()))
            .ForMember(dto => dto.Publisher, y => y.MapFrom(model => model.Publisher.CompanyName))
            .ForMember(dto => dto.PublishDate, y => y.MapFrom(model => model.PublishDate))
            .ForMember(dto => dto.CreationDate, y => y.MapFrom(model => model.CreationDate))
            .ForMember(dto => dto.ViewCount, y => y.MapFrom(model => model.ViewCount))
            .ForMember(dto => dto.PlatformsNames, y => y.MapFrom(model => model.Platforms.Select(c => c.Type).ToList()));

        CreateMap<Game, GameDetailsModel>()
            .ForMember(dto => dto.GameAlias, y => y.MapFrom(model => model.GameAlias))
            .ForMember(dto => dto.Name, y => y.MapFrom(model => model.Name))
            .ForMember(dto => dto.Price, y => y.MapFrom(model => model.Price))
            .ForMember(dto => dto.UnitInStock, y => y.MapFrom(model => model.UnitInStock))
            .ForMember(dto => dto.Discontinued, y => y.MapFrom(model => model.Discontinued))
            .ForMember(dto => dto.Genres, y => y.MapFrom(model => model.Genres))
            .ForMember(dto => dto.Publisher, y => y.MapFrom(model => model.Publisher.CompanyName))
            .ForMember(dto => dto.Platforms, y => y.MapFrom(model => model.Platforms))
            .ForMember(dto => dto.Description, y => y.MapFrom(model => model.Description))
            .ForMember(dto => dto.PublisherId, y => y.MapFrom(model => model.PublisherId));

        CreateMap<AddGameRequest, Game>()
           .ForMember(dto => dto.GameAlias, y => y.MapFrom(model => model.GameAlias))
           .ForMember(dto => dto.Name, y => y.MapFrom(model => model.Name))
           .ForMember(dto => dto.Description, y => y.MapFrom(model => model.Description))
           .ForMember(dto => dto.Price, y => y.MapFrom(model => model.Price))
           .ForMember(dto => dto.UnitInStock, y => y.MapFrom(model => model.UnitInStock))
           .ForMember(dto => dto.Discontinued, y => y.MapFrom(model => model.Discontinued))
           .ForMember(dto => dto.PublisherId, y => y.MapFrom(model => model.PublisherId))
           ;

        CreateMap<UpdateGameRequest, Game>()
           .ForMember(dto => dto.GameAlias, y => y.MapFrom(model => model.GameAlias))
           .ForMember(dto => dto.Name, y => y.MapFrom(model => model.Name))
           .ForMember(dto => dto.Description, y => y.MapFrom(model => model.Description))
           .ForMember(dto => dto.Price, y => y.MapFrom(model => model.Price))
           .ForMember(dto => dto.UnitInStock, y => y.MapFrom(model => model.UnitInStock))
           .ForMember(dto => dto.Discontinued, y => y.MapFrom(model => model.Discontinued))
           .ForMember(dto => dto.PublisherId, y => y.MapFrom(model => model.PublisherId));
    }
}
