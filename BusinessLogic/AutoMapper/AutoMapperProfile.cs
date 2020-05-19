using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BusinessLogic.DTO;
using DataManagement.Entities;

namespace BusinessLogic.AutoMapper
{
    class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductDTO, Product>().ReverseMap();
            CreateMap<ManagerDTO, Manager>().ReverseMap();
            CreateMap<StoreDTO, Store>().ReverseMap();
            CreateMap<DriverDTO, Driver>().ReverseMap();
        }
    }
}
