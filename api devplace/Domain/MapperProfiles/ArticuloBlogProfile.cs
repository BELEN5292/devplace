using AutoMapper;
using DevPlace.Blog.API.Domain.DTOs;
using DevPlace.Blog.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevPlace.Blog.API.Domain.MapperProfiles
{
    public class ArticuloBlogProfile : Profile
    {
        public ArticuloBlogProfile()
        {
            CreateMap<CrearArticuloDto, ArticuloBlog>();
            CreateMap<ArticuloBlog, ArticuloDto>();
        }
    }
}
