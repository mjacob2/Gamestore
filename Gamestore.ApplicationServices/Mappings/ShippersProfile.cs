using AutoMapper;
using Gamestore.ApplicationServices.Requests.Shippers;
using Gamestore.DataAccess.Entities;

namespace Gamestore.ApplicationServices.Mappings;
public class ShippersProfile : Profile
{
    public ShippersProfile()
    {
        CreateMap<AddShipperRequest, Shipper>()
            .ForMember(dto => dto.CompanyName, y => y.MapFrom(model => model.CompanyName))
            .ForMember(dto => dto.Phone, y => y.MapFrom(model => model.Phone));

        CreateMap<UpdateShipperRequest, Shipper>()
            .ForMember(dto => dto.ShipperId, y => y.MapFrom(model => model.ShipperId))
            .ForMember(dto => dto.CompanyName, y => y.MapFrom(model => model.CompanyName))
            .ForMember(dto => dto.Phone, y => y.MapFrom(model => model.Phone));
    }
}
