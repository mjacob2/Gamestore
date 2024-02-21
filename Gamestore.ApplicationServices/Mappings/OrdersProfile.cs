using AutoMapper;
using Gamestore.ApplicationServices.Models;
using Gamestore.DataAccess.Entities;

namespace Gamestore.ApplicationServices.Mappings;
public class OrdersProfile : Profile
{
    public OrdersProfile()
    {
        CreateMap<Order, OrderDetailsModel>().PreserveReferences();
    }
}
