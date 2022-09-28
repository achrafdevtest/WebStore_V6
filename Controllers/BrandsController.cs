using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Core.Models;
using WebStore.Core.Services;
using WebStore.Errors;

namespace WebStore.Controllers;
[Authorize]
public class BrandsController : BaseApiController
{
    private readonly BrandService _brandService;
    public BrandsController(BrandService brandService)
    {
        _brandService = brandService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await _brandService.GetAll();
            return Ok(result);
        }
        catch
        {
            return BadRequest(new ApiResponse(400));
        }

    }
    [HttpGet("id")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var result = await _brandService.GetBrand(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                message = ex.Message
            });
        }
    }

    [HttpGet("code")]
    public async Task<IActionResult> Get(string code)
    {
        try
        {
            var result = await _brandService.GetBrand(code);
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
    public async Task<IActionResult> CreateBrand([FromBody] NewBrand newBrand)
    {
        try
        {
            await _brandService.Create(newBrand);
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
    public async Task<IActionResult> UpdateBrand([FromBody] UpdateModelBase brand, string code)
    {
        try
        {
            await _brandService.Update(brand, code);
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
    public async Task<IActionResult> DeleteBrand(int id)
    {
        try
        {
            await _brandService.Delete(id);
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

