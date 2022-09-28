using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Core.Models;
using WebStore.Core.Services;
using WebStore.Errors;

namespace WebStore.Controllers;
[Authorize]
public class CategoryController : BaseApiController
{
    private readonly CategoryService _categoryService;
    public CategoryController(CategoryService categoryService)
    => _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));

    [HttpGet("id")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var result = await _categoryService.Get(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                Error = new ApiResponse(400),
                message = ex.Message
            });
        }
    }
    [HttpGet("code")]
    public async Task<IActionResult> Get(string code)
    {
        try
        {
            var result = await _categoryService.Get(code);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                Error = new ApiResponse(400),
                Detail = ex.Message
            });
        }
    }
    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await _categoryService.GetAll();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                Error = new ApiResponse(400),
                Detail = ex.Message
            });
        }
    }
    [HttpPost("add")]
    public async Task<IActionResult> Createcategory([FromBody] NewCategory newCategory)
    {
        try
        {
            await _categoryService.Create(newCategory);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                Error = new ApiResponse(400),
                Detail = ex.Message
            });
        }
    }
    [HttpPut("{code}")]
    public async Task<IActionResult> Update([FromBody] UpdateModelBase categorie, string code)
    {
        try
        {
            await _categoryService.Update(categorie, code);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                Error = new ApiResponse(400),
                Detail = ex.Message
            });
        }
    }
    [HttpDelete("delete")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _categoryService.Delete(id);
            return Ok();
        }

        catch (Exception ex)
        {
            return BadRequest(new
            {
                Error = new ApiResponse(400),
                Detail = ex.Message
            });
        }
    }
}
