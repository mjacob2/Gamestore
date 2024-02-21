using AutoMapper;
using Gamestore.ApplicationServices.Models;
using Gamestore.DataAccess.Entities;

namespace Gamestore.ApplicationServices.Mappings;
public class OrderItemsProfile : Profile
{
    public OrderItemsProfile()
    {
        CreateMap<OrderItem, OrderItemDetailsModel>()
            .ForMember(dto => dto.Id, y => y.MapFrom(model => model.Id))
            .ForMember(dto => dto.ProductId, y => y.MapFrom(model => model.ProductId))
            .ForMember(dto => dto.ProductName, y => y.MapFrom(model => model.ProductName))
            .ForMember(dto => dto.Quantity, y => y.MapFrom(model => model.Quantity))
            .ForMember(dto => dto.ProductPrice, y => y.MapFrom(model => model.ProductPrice))
            .ForMember(dto => dto.OrderId, y => y.MapFrom(model => model.OrderId));
    }
}
