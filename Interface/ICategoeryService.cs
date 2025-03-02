using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controllers;
using api.DTOs;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.interfaces
{
    public interface ICategoryService
    {
        //In c# for asynchronous use task
        Task<PaginatedResult<CategoryReadDto>> GetAllCategories(int pageNumber, int pageSize, string? search = null);
        Task <CategoryReadDto?> getCategoryById(Guid categoryId);
        Task <CategoryReadDto> CreateCategory(CategoryCreateDto categoryData);
        Task <CategoryReadDto?> UpdateCategory(Guid categoryId, CategoryUpdateDto categoryData);
        Task <bool> DeleteCategory(Guid categoryId);
    }
    
}