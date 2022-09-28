using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Core.Models;
using WebStore.Core.Services;
using WebStore.Errors;

namespace WebStore.Controllers;
[Authorize]
public class StaffController : BaseApiController
{
    private readonly StaffService _staffService;

    public StaffController(StaffService staffService)
       => _staffService = staffService ?? throw new ArgumentNullException(nameof(staffService));

    [HttpGet("id")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var result = await _staffService.Get(id);
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
    [HttpGet("matricule")]
    public async Task<IActionResult> Get(string matricule)
    {
        try
        {
            var result = await _staffService.Get(matricule);
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
            var result = await _staffService.GetAll();
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
    public async Task<IActionResult> Createcategory([FromBody] NewStaff newStaff)
    {
        try
        {
            await _staffService.Create(newStaff);
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
    [HttpPut("{matricule}")]
    public async Task<IActionResult> Update([FromBody] UpdateStaff updateStaff, string matricule)
    {
        try
        {
            await _staffService.Update(updateStaff, matricule);
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
            await _staffService.Delete(id);
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
