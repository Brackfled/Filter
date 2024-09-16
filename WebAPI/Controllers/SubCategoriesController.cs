using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;
using WebAPI.Entities.Dtos;
using WebAPI.Services.Abstract;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubCategoriesController : ControllerBase
{
    private readonly ISubCategoryService _subCategoryService;

    public SubCategoriesController(ISubCategoryService subCategoryService)
    {
        _subCategoryService = subCategoryService;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateSubCategory([FromBody] CreateSubCategoryDto createSubCategoryDto)
    {
        SubCategory subCategory = await _subCategoryService.AddAsync(new SubCategory
        {
            CategoryId = createSubCategoryDto.CategoryId,
            Name = createSubCategoryDto.Name
        });
        return Ok(subCategory);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllSubCategories()
    {
        ICollection<SubCategory> subCategories = await _subCategoryService.GetAllAsync();
        return Ok(subCategories);
    }
}
