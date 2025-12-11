using AutoMapper;
using DTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<Product, ProductManagerDTO>();
            CreateMap<Order, OrderDTO>();
            CreateMap<Order, OrderManagerDTO>();
            CreateMap<User, UserDTO>();
        }
    }
}
