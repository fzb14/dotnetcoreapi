﻿using AutoMapper;
using dotnetcoreapi.API.Entities;
using dotnetcoreapi.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcoreapi.API.Profiles
{
    public class PoiProfile : Profile
    {
        public PoiProfile()
        {
            CreateMap<PointOfInterest, PointOfInterestDto>();
            CreateMap<PointOfInterest, PointOfInterestForCreateDto>().ReverseMap();
            CreateMap<PointOfInterestDto, PointOfInterest>();
            //CreateMap<PointOfInterestForCreateDto, PointOfInterest>();
        }
    }
}
