using AutoMapper;
using dotnetcoreapi.API.Entities;
using dotnetcoreapi.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcoreapi.API.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityWithoutPoisDto>();
            CreateMap<City,CityDto>();
        }
    }
}
