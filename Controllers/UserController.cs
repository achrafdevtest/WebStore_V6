using Microsoft.AspNetCore.Mvc;
using WebStore.Core.Models;
using WebStore.Core.Services;
using WebStore.Errors;

namespace WebStore.Controllers;
public class UserController :BaseApiController
{
    private readonly AccountService _accountService;    
    public UserController(AccountService accountService)
     => _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
   

    [HttpPost("login")]
    public async Task<IActionResult> login([FromQuery] LoginDto loginDto)
    {
        try
        {
            var result = await _accountService.Login(loginDto); 
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
   
    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
        try
        {
            var result = await _accountService.Register(registerDto);
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
}
