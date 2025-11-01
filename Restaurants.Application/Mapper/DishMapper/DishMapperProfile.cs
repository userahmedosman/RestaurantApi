using AutoMapper;
using Restaurants.Application.Dishes.Commands.CreateDish;
using Restaurants.Application.Dishes.Dto;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Mapper.DishMapper;

public class DishMapperProfile:Profile
{
    public DishMapperProfile()
    {
        CreateMap<Dish, DishDto>().ReverseMap();
        CreateMap<CreateDishCommand, Dish>();
    }
}
