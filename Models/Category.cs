using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace api.Models
{
    public class Category{
    public Guid CategoryId { get; set; }
    public string Name { get; set; }  // Required property
    public string Description { get; set; }= string.Empty;
    public DateTime CreatedAt { get; set; }
    }
}