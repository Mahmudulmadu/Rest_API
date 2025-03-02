using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.DTOs{
    public class CategoryCreateDto
    {
        [Required(ErrorMessage = "Must be fill Name")]
        [StringLength(100, MinimumLength =2, ErrorMessage = "Name Must be have 2 to 100 characters")]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty ;
    }
}