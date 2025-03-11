using AutoMapper;
using E_Commerce.DTO;
using ECommerce.Core.Entity;
using ECommerce.Core.Entity.Identity;
using ECommerce.Core.Entity.OrderEntitys;
using ECommerce.Core.Entity.rides;

namespace E_Commerce.Helper
{
    public class MappingProfile:Profile
    {
        public MappingProfile(string URL) {
            CreateMap<Product, ProductDTO>().ForMember(d=>d.Brand,o=>o.MapFrom(p=>p.Brand.Name)).
                ForMember(d=>d.Category,o=>o.MapFrom(p=>p.Category.Name)).
                ForMember(d=>d.PictureUrl,o=>o.MapFrom(p=>$"{URL}/{p.PictureUrl}"));

            CreateMap<CustomerBasketDTO, CustomerBasket>();

            CreateMap<BasketProductDTO, BasketProduct>();
            CreateMap<AddressDto, ECommerce.Core.Entity.Identity.Address>().
                ForMember(d=>d.Lname,o=>o.MapFrom(o=>o.LastName)).
                ForMember(d => d.FName, o => o.MapFrom(o => o.FirstName));
            // orderAddress
            CreateMap<AddressDto, ECommerce.Core.Entity.OrderEntitys.Address>();
            CreateMap<Order,OrderToReturnDto>().ForMember(d=>d.DeliveryMethod , o =>o.MapFrom(o=>o.DeliveryMethod.ShortName))
                .ForMember(d=>d.DeliveryMethodCost ,o=>o.MapFrom(o=>o.DeliveryMethod.Cost));
            CreateMap<OrderItem, OrderItemDto>().ForMember(d => d.ProductId, o => o.MapFrom(o => o.Product.Id))
                .ForMember(d => d.ProductName, o => o.MapFrom(o => o.Product.ProductName)).
                ForMember(d => d.PictureUrl, o => o.MapFrom(o => $"{URL}/{o.Product.PictureUrl}"));
        }
    }
}
