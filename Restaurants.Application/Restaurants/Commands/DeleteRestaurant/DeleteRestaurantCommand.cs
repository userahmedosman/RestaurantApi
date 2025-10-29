using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommand: IRequest
    {
        public int Id { get; set; }
        public DeleteRestaurantCommand(int id)
        {
            Id = id;
        }
    }
}
