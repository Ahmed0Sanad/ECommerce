using AutoMapper;
using E_Commerce.DTO;
using ECommerce.Core.Entity;
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
        }
    }
}
