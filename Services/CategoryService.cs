using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controllers;
using api.Data;
using api.DTOs;
using api.interfaces;
using api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class CategoryService : ICategoryService
    {
        // private static readonly  List<Category> _categories =
        //  new List<Category>();

        private readonly AppDbContext _appDbContext;

        private readonly IMapper _mapper;

        public CategoryService(AppDbContext appDbContext,IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
         public async Task<PaginatedResult<CategoryReadDto>> GetAllCategories(int pageNumber, int pageSize, string? search = null){

                IQueryable<Category> query = _appDbContext.Categories;

                if(!string.IsNullOrWhiteSpace(search)){
                    var formattedSearch = $"%{search.Trim()}%";
                    query = query.Where( c => EF.Functions.ILike(c.Name, formattedSearch) || EF.Functions.ILike(c.Description,formattedSearch));
                }

                 var totalCount = await query.CountAsync();
                
                var item = await query.Skip((pageNumber-1)* pageSize).Take(pageSize).ToListAsync();

               
                var result = _mapper.Map<List<CategoryReadDto>>(item);

                return new PaginatedResult<CategoryReadDto>{
                    Items = result,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
         }      

         public async Task <CategoryReadDto?> getCategoryById(Guid categoryId){
            var Category = await _appDbContext.Categories.FindAsync
            (categoryId);

            return Category == null ? null: _mapper.Map<CategoryReadDto>(Category);
      
        }

         public async Task <CategoryReadDto> CreateCategory(CategoryCreateDto categoryData)
         {
    
            var newCategory = _mapper.Map<Category>(categoryData);
            newCategory.CategoryId = Guid.NewGuid();
            newCategory.CreatedAt = DateTime.UtcNow;

            await _appDbContext.Categories.AddAsync(newCategory);
            await _appDbContext.SaveChangesAsync();
           
            return _mapper.Map<CategoryReadDto>(newCategory);
         }
         public async Task<CategoryReadDto?> UpdateCategory(Guid categoryId, CategoryUpdateDto categoryData)
         {
             var foundCategory = await _appDbContext.Categories.FindAsync
            (categoryId);

            if(foundCategory == null)
            {
                return null;
            }
         _appDbContext.Categories.Update(foundCategory);

            await _appDbContext.SaveChangesAsync();
            _mapper.Map(categoryData,foundCategory);

            return _mapper.Map<CategoryReadDto>(foundCategory);
         }

         public async Task<bool> DeleteCategory(Guid categoryId)
         {
             var foundCategory = await _appDbContext.Categories.FindAsync
            ( categoryId);

            if(foundCategory == null)
            {
                return  false;
            }
             _appDbContext.Categories.Remove(foundCategory);
             await _appDbContext.SaveChangesAsync();

            return true;
         }

      
    }
}