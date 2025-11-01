using AutoMapper;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Application.Restaurants.Dto;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Mapper.RestaurantMapper;

public class RestaurantMapperProfile : Profile
{
    public RestaurantMapperProfile()
    {
        CreateMap<Restaurant, RestaurantDto>().ReverseMap();


        CreateMap<CreateRestaurantCommand, Restaurant>().ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address
        {
            City = src.City,
            Street = src.Street,
            PostalCode = src.PostalCode
        }));

        CreateMap<UpdateRestaurantCommand, Restaurant>();


    }
}
