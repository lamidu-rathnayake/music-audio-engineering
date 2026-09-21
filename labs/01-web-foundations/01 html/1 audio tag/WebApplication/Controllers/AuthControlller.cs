using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
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
        
        // Hardcoded credentials for learning the architecture
        if (request.Username == "admin" && request.Password == "admin123") 
            role = "Admin";
        else if (request.Username == "user" && request.Password == "user123") 
            role = "User";
        else 
            return Unauthorized(new { message = "Invalid credentials" });

        // Build the User Identity
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, request.Username),
            new Claim(ClaimTypes.Role, role)
        };
        
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        // Issue the secure cookie
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        return Ok(new { role });
    }
}

// Data Transfer Object
public class UserLogin 
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}