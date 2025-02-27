using E_Commerce.DTO;
using E_Commerce.Errors;
using ECommerce.Core.Entity.Identity;
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

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto login)
        {
            var email = await userManager.FindByEmailAsync(login.Email);
            if (email == null)
            {
                return Unauthorized(new ApiResponse(401));
            }
            var pass = await signInManager.CheckPasswordSignInAsync(email, login.Password, false);
            if (pass.Succeeded is false) { return Unauthorized(new ApiResponse(401)); }
            return Ok(new UserDto() { Email = login.Email, Password = login.Password, Token = "this is token" });

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
            return Ok(new UserDto() { Email = registerDto.Email, Password = registerDto.Password, Token = "this is token" });

        }
    }
}