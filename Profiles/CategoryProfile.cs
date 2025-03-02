using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;
using api.DTOs;
using api.interfaces;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace api.Profiles
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile(){
            CreateMap<Category, CategoryReadDto>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
        }

    }

    
}