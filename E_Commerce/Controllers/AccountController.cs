using AutoMapper;
using E_Commerce.DTO;
using E_Commerce.Errors;
using E_Commerce.Extentions;
using E_Commerce.Helper;
using ECommerce.Core.Entity.Identity;
using ECommerce.Core.Services.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IAuthService authService,IMapper mapper)
        {
            this.userManager = userManager;
            this._signInManager = signInManager;
            this._authService = authService;
            this._mapper = mapper;
        }
        
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto login)
        {
            var user = await userManager.FindByEmailAsync(login.Email);
            if (user == null)
            {
                return Unauthorized(new ApiResponse(401));
            }
            var pass = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);
            if (pass.Succeeded is false) { return Unauthorized(new ApiResponse(401)); }
            return Ok(new UserDto() { Email = login.Email, DisplayName = user.UserName, Token = await _authService.GenerateTokenAsync(user, userManager) });

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
                return BadRequest(new ApiResponse(404,$"{result.Succeeded.ToString()}"));

            }
            return Ok(new UserDto() { Email = registerDto.Email, DisplayName = user.UserName, Token = await _authService.GenerateTokenAsync(user, userManager) });

        }
        
        [Authorize]
        [CacheAttribute(3)]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        { 
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await userManager.FindByEmailAsync(email);

            var userDto = new UserDto() { Email = email, DisplayName = user.UserName, Token = await _authService.GenerateTokenAsync(user, userManager) };
            return Ok(userDto);
        }
        
        [Authorize]
        [CacheAttribute(3)]
        [HttpGet("address")]
        public async Task<ActionResult<IEnumerable<AddressDto>>> GetUserAddress()
        {
            var user = await userManager.FindUserWithAddressAsync(User);
            return Ok(user.addresses);
        }
        [HttpPost("AddAddress")]
        [Authorize]
        public async Task<ActionResult<AddressDto>> AddAddressForUSer(AddressDto addressDto) 
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var user = await userManager.FindByEmailAsync(userEmail);
            var address = _mapper.Map<AddressDto,Address>(addressDto);
            user.addresses.Add(address);
            var result = await userManager.UpdateAsync(user);
            if (!result.Succeeded) { return BadRequest(new ApiResponse(400)); }
            return Ok(addressDto);
        }
       
        [HttpGet("emailexists")]

        public async Task<ActionResult<bool>> IsEmailExist(string email)
        {
            return await userManager.FindByEmailAsync(email) is not null;
        }
    }
}