using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace BackendAPI.Controllers;

[ApiController]
[Route("api")]
public class DataController : ControllerBase
{
    [HttpGet("admin/data")]
    [Authorize("Admin")]
    public IActionResult GetAdminData()
    {
        return Ok(new
        {
            message = "highly sensitive data for admin",
            timestamp = DateTime.UtcNow
        });
    }


    [HttpGet("user/data")]
    [Authorize("User,Admin")]
    public IActionResult GetUserData()
    {
        return Ok(new
        {
            message = "regilar user dashboard profile"
        });
    }


    [HttpGet("logout")]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Ok(new
        {
            message = "regilar user dashboard profile"
        });
    }

}