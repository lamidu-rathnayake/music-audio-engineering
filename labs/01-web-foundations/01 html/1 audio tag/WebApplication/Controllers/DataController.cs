using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers;

[ApiController]
[Route("api")]
public class DataController : ControllerBase
{
    // Matches: GET /api/admin/data
    [HttpGet("admin/data")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetAdminData()
    {
        return Ok(new { 
            message = "Highly sensitive admin system data.",
            timestamp = DateTime.UtcNow
        });
    }

    // Matches: GET /api/user/data
    [HttpGet("user/data")]
    [Authorize(Roles = "User,Admin")] 
    public IActionResult GetUserData()
    {
        return Ok(new { 
            message = "Regular user dashboard profile.",
            timestamp = DateTime.UtcNow
        });
    }

    // Matches: POST /api/logout
    [HttpPost("logout")]
    [Authorize] 
    public async Task<IActionResult> Logout()
    {
        // Instructs the browser to destroy the cookie
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Ok(new { message = "Logged out successfully" });
    }
}