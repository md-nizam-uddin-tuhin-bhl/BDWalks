using BDWalksAPI.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BDWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var identityUser = new IdentityUser()
            {
                UserName = registerDto.UserName,
                Email = registerDto.UserName
            };
           var identityResult =  await userManager.CreateAsync(identityUser,registerDto.Password);

            if(identityResult.Succeeded)
            {
                if(registerDto.Roles !=null && registerDto.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser,registerDto.Roles);
                    if (identityResult.Succeeded)
                    {
                        return Ok("User was registered! Please login.");
                    }
                }
               
            }
            return BadRequest("Something went wrong");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LogIn([FromBody] LoginDto loginDto)
        {
           var user =  await userManager.FindByEmailAsync(loginDto.UserName);
            if(user != null)
            {
               var chickpassResult =  await userManager.CheckPasswordAsync(user,loginDto.Password);
                if (chickpassResult)
                {

                }
            }
            return BadRequest("UserName or PassWord Incorrect");
        }
    }
}
