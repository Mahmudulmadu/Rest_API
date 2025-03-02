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

namespace api.Controllers{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase{

        private  ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService){
            _categoryService = categoryService;
        }
       
        [HttpGet]
        public async Task <IActionResult> GetCategories([FromQuery] int 
        pageNumber=1, [FromQuery] int pageSize=5,[FromQuery] string? search = null){

            var categoryList = await _categoryService.GetAllCategories(pageNumber, pageSize, search);

            return Ok(ApiResponse<PaginatedResult<CategoryReadDto>>.SuccessResponse(
                categoryList,200,"categories returned successfully"));
        }

        [HttpGet("{categoryId}")]
        public async Task <IActionResult> GetCategoryById(Guid categoryId){

             var category =await _categoryService.getCategoryById(categoryId);

            return Ok(ApiResponse<CategoryReadDto>.SuccessResponse(
                category,200,"category returned successfully"));
        }

        [HttpPost]
        public async Task <IActionResult> CreateCategory([FromBody] CategoryCreateDto categoryData)
        {
            var category = await _categoryService.CreateCategory(categoryData);

            return Created($"/api/categories/{category.CategoryId}",
            ApiResponse<CategoryReadDto>.SuccessResponse(
                category,201,"categories create successfully"));
        }

        [HttpDelete("{categoryId}")]
        public async Task <IActionResult> DeleteCategory(Guid categoryId)
        {
            var category = await _categoryService.DeleteCategory(categoryId);
            if(!category){
                return NotFound(ApiResponse<object>.ErrorResponse(new List<string>
                { "Category with this id doesnot exist"},404,"Validation failed" ));
            }
            return Ok(ApiResponse<object>.SuccessResponse(null,204,"Category Deleted Succesfully"));
        }

        [HttpPut("{categoryId}")]
        public async Task <IActionResult> UpdateCategory(Guid categoryId, [FromBody] CategoryUpdateDto categoryData)
        {
            var category = await _categoryService.UpdateCategory(categoryId, categoryData);
            
            return Ok(ApiResponse<object>.SuccessResponse(category,204,"Category Updated Succesfully"));
        }
    }
}