using Microsoft.AspNetCore.Identity;
using WebStore.Core.Interface;
using WebStore.Core.Models;

namespace WebStore.Core.Services;
public class AccountService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ITokenService _tokenService;
    public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
    }
    public async Task<string> Login(LoginDto loginDto)
    {
        try
        {
            if (loginDto == null)
                  throw new InvalidOperationException(nameof(loginDto));

            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
                throw new InvalidOperationException("Email invalide!");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
                throw new InvalidOperationException("Authentification invalide!");

            return _tokenService.GenerateToken(user);
        }
        catch
        {
            throw;
        }
       
    }

    public async Task<string> Register(RegisterDto registerDto)
    {
        try
        {
            if (registerDto == null)
                  throw new InvalidOperationException(nameof(registerDto));

            if (registerDto.Email == null)
                  throw new InvalidOperationException(nameof(registerDto.Email));

            var userExists = await _userManager.FindByEmailAsync(registerDto.Email);

            if (userExists != null)
                throw new InvalidOperationException("Email existe déjà");

            var user = new AppUser
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.Email
            };
            await _userManager.CreateAsync(user, registerDto.Password);
            return _tokenService.GenerateToken(user);
        }
        catch 
        {

            throw;
        }
       
    }
}
