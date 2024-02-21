using AutoMapper;
using Gamestore.ApplicationServices.Models;
using Gamestore.ApplicationServices.Requests.Genres;
using Gamestore.DataAccess.Entities;

namespace Gamestore.ApplicationServices.Mappings;

public class GenresProfile : Profile
{
    public GenresProfile()
    {
        CreateMap<Genre, GenreListingModel>()
            .ForMember(dto => dto.Id, y => y.MapFrom(model => model.Id))
            .ForMember(dto => dto.Name, y => y.MapFrom(model => model.Name));

        CreateMap<Genre, GenreDetailsModel>()
            .ForMember(dto => dto.Id, y => y.MapFrom(model => model.Id))
            .ForMember(dto => dto.Name, y => y.MapFrom(model => model.Name))
            .ForMember(dto => dto.SubGenres, y => y.MapFrom(model => model.SubGenres != null ? model.SubGenres.Select(x => x.Name) : new List<string>()));

        CreateMap<AddGenreRequest, Genre>()
            .ForMember(dto => dto.Name, y => y.MapFrom(model => model.Name))
            .ForMember(dto => dto.ParentGenreId, y => y.MapFrom(model => model.ParentGenreId));

        CreateMap<UpdateGenreRequest, Genre>()
            .ForMember(dto => dto.Id, y => y.MapFrom(model => model.Id))
            .ForMember(dto => dto.Name, y => y.MapFrom(model => model.Name))
            .ForMember(dto => dto.ParentGenreId, y => y.MapFrom(model => model.ParentGenreId));
    }
}
