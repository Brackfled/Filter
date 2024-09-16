using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;
using WebAPI.Services.Abstract;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateCategory([FromBody] string name)
    {
        Category category = new() { Name = name };
        Category addedCategory = await _categoryService.AddAsync(category);
        return Ok(category);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllCategories()
    {
        ICollection<Category> categories = await _categoryService.GetAllAsync(include:c => c.Include(opt => opt.Products!));
        return Ok(categories);
    }
}
