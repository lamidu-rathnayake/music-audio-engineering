using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace BackendAPI.Controllers;

[ApiController]
[Route("api")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLogin request)
    {
        string role = string.Empty;

        if (request.Username == "admin" && request.Password == "admin123")
        {
            role = "Admin";
        }
        else if (request.Username == "user" && request.Password == "user123")
        {
            role = "Client";
        }
        else 
            return Unauthorized(new { message = "Invalid credentials"});
        
        // creating claims
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, request.Username),
            new Claim(ClaimTypes.Role, role)
        };  

        // creating the identity
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        // creating the principle
        var principle = new ClaimsPrincipal(identity);

        // isseing cookie to the browser
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle);

        return Ok(new {role});
    }
}

// dtos
public class UserLogin
{
    public string Username {get; set;} = string.Empty;  
    public string Password {get; set;} = string.Empty;  
}
