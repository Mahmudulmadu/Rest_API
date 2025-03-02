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

namespace api.Controllers
{
    public class PaginatedResult<T>
    {
        public IEnumerable<T> Items {get; set;} = new List<T>();

        public int TotalCount {get; set;}
        public int PageNumber {get; set;}
        public int PageSize {get; set;}
        public int TotalPage => (int)Math.Ceiling((double)TotalCount/PageSize);
    }
}