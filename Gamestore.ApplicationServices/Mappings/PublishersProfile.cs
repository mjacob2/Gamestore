using AutoMapper;
using Gamestore.ApplicationServices.Models;
using Gamestore.ApplicationServices.Requests.Publishers;
using Gamestore.DataAccess.Entities;

namespace Gamestore.ApplicationServices.Mappings;
public class PublishersProfile : Profile
{
    public PublishersProfile()
    {
        CreateMap<Publisher, PublisherListingModel>()
            .ForMember(dto => dto.Id, y => y.MapFrom(model => model.Id))
            .ForMember(dto => dto.CompanyName, y => y.MapFrom(model => model.CompanyName))
            .ForMember(dto => dto.Description, y => y.MapFrom(model => model.Description))
            .ForMember(dto => dto.HomePage, y => y.MapFrom(model => model.HomePage));

        CreateMap<AddPublisherRequest, Publisher>()
            .ForMember(dto => dto.CompanyName, y => y.MapFrom(model => model.CompanyName))
            .ForMember(dto => dto.Description, y => y.MapFrom(model => model.Description))
            .ForMember(dto => dto.HomePage, y => y.MapFrom(model => model.HomePage));

        CreateMap<Publisher, PublisherDetailsModel>()
             .ForMember(dto => dto.Id, y => y.MapFrom(model => model.Id))
            .ForMember(dto => dto.CompanyName, y => y.MapFrom(model => model.CompanyName))
            .ForMember(dto => dto.Description, y => y.MapFrom(model => model.Description))
            .ForMember(dto => dto.HomePage, y => y.MapFrom(model => model.HomePage));
    }
}
