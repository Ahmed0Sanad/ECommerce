using E_Commerce.DTO;
using E_Commerce.Errors;
using ECommerce.Core.Entity.Identity;
using ECommerce.Core.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IAuthService _authService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IAuthService authService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this._authService = authService;
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto login)
        {
            var user = await userManager.FindByEmailAsync(login.Email);
            if (user == null)
            {
                return Unauthorized(new ApiResponse(401));
            }
            var pass = await signInManager.CheckPasswordSignInAsync(user, login.Password, false);
            if (pass.Succeeded is false) { return Unauthorized(new ApiResponse(401)); }
            return Ok(new UserDto() { Email = login.Email, Password = login.Password, Token = await _authService.GenerateTokenAsync(user, userManager) });

        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var user = new AppUser()
            {
                Email = registerDto.Email,
                Fname = registerDto.Name,
                LName = registerDto.Name,
                PhoneNumber = registerDto.PhoneNumber,
                UserName = registerDto.Email.Split("@")[0]
            };
            var result = await userManager.CreateAsync(user, registerDto.Password);
            if (result.Succeeded is false)
            {
                return BadRequest(new ApiResponse(401));

            }
            return Ok(new UserDto() { Email = registerDto.Email, Password = registerDto.Password, Token = await _authService.GenerateTokenAsync(user, userManager) });

        }
    }
}