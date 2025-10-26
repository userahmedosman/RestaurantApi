using AutoMapper;
using Restaurants.Application.Dishes.Dto;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Application.Restaurants.Dto;
using Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurants.Application.Mapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile() {
            CreateMap<Restaurant, RestaurantDto>().ReverseMap();
            CreateMap<Dish, DishDto>().ReverseMap();

            CreateMap<CreateRestaurantCommand, Restaurant>().ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address
            {
                City = src.City,
                Street = src.Street,
                PostalCode = src.PostalCode
            }));

            CreateMap<UpdateRestaurantCommand, Restaurant>();
        }
    }
}
