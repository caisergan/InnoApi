using InnoApi.Dtos.Account;
using InnoApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace InnoApi.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUserModel> _userManager;
        public AccountController(UserManager<AppUserModel> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                /*if (!ModelState.IsValid)
                    return BadRequest(ModelState);*/

                var appUser = new AppUserModel
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email,
                    PasswordHash = registerDto.PasswordHash
                };

                //var createdUser = await _userManager.CreateAsync(appUser); // Pass password separately
                IdentityResult result = await _userManager.CreateAsync(appUser);

                if (result.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok("User Created");
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, result.Errors);
                }
            }
            catch (Exception e)
            {
                // Log the exception
                return StatusCode(500, new { message = "An error occurred while processing your request.", exception = e.Message });
            }
        }

    }
}
