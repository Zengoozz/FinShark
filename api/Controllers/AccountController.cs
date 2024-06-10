using api.Dtos.Account;
using api.Interfaces;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

#region Register Tasks
// Add Route, ApiController ☑
// Inherit from ControllerBase ☑
// Inject UserManager ☑
// Create RegisterDto with required fields (Username?, Email?, Password) in Account Folder ☑
// Add Seeding for the identityRoles when creating model (AdminRole, UserRole)  -- ContextFile ☑
// Create Register Method (CheckModelState, CreateNewUser) ☑
#endregion

#region Login Tasks 
// Create Login Method ☑
// Create Login Dto ☑
// Check ModelState ☑
// Find User using UserManager ☑
// Check Password using SignInManager ☑
// Add Swagger Configuration to Program File ☑
#endregion

namespace api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _UserManager;
        private readonly ITokenService _TokenService;
        private readonly SignInManager<AppUser> _SignInManager;
        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
        {
            _UserManager = userManager;
            _TokenService = tokenService;
            _SignInManager = signInManager;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var appUser = new AppUser
                {
                    UserName = model.Username,
                    Email = model.Email
                };

                var CreatedUser = await _UserManager.CreateAsync(appUser, model.Password ?? "");

                if (CreatedUser.Succeeded)
                {
                    var roleResult = await _UserManager.AddToRoleAsync(appUser, "User");

                    if (roleResult.Succeeded)
                        return Ok(
                            new NewUserDto
                            {
                                Username = appUser.UserName ?? "",
                                Email = appUser.Email ?? "",
                                Token = _TokenService.CreateToken(appUser)
                            }
                        );
                    else
                        return StatusCode(500, roleResult.Errors);
                }
                else
                    return StatusCode(500, CreatedUser.Errors);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }


        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _UserManager.Users.FirstOrDefaultAsync(u => u.UserName == model.Username.ToLower());

            if (user == null) 
                 return Unauthorized("Username not found");

            var response = await _SignInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (!response.Succeeded)
                return Unauthorized("Username and/or Password not valid");

            return Ok(
                new NewUserDto
                {
                    Username = user.UserName,
                    Email = user.Email,
                    Token = _TokenService.CreateToken(user)
                });
        }
    }
}