using Microsoft.AspNetCore.Authentication.Cookies;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// 2. Register Controller Services
builder.Services.AddControllers();

builder.Services.AddOpenApi();

// 1. Add and configure HTTP logging services
builder.Services.AddHttpLogging(logging =>
{
    // Choose what details you want to log
    logging.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestPropertiesAndHeaders | 
    Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.ResponsePropertiesAndHeaders;
});

// NO NEED OF CORS FOR SAME ORIGIN (we put the html files to the wwwwroot - it use the same origin and same port)

// 3. Cookie Authentication Configuration
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "__Host-AuthSession"; // __Host- prevents subdomai hijacking
        options.Cookie.HttpOnly = true;                  
        options.Cookie.SameSite = SameSiteMode.Strict;   
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Requires HTTPS for fetching
        
        // Return raw HTTP status codes instead of redirecting to HTML login pages
        options.Events.OnRedirectToLogin = context =>
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        };
        options.Events.OnRedirectToAccessDenied = context =>
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            return Task.CompletedTask;
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); 
    app.MapScalarApiReference();
}

// 4. Middleware Pipeline (Order is strictly enforced)
// removed cors statement
app.UseHttpLogging();
app.UseDefaultFiles(); // looks for index.html in wwwwroot when user hitting "/"
app.UseStaticFiles(); // looks css and js
app.UseHttpsRedirection(); // Redirects HTTP to HTTPS            
app.UseAuthentication();    
app.UseAuthorization();    
app.MapControllers();      
app.Run();  