using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.DTOs{
    public class CategoryUpdateDto
    {
        public string Name { get; set; } =string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}