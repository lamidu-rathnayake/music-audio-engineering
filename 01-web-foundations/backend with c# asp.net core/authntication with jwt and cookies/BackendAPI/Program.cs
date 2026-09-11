using Microsoft.AspNetCore.Authentication.Cookies;

// crreating the application builder to configure the settings and services
var builder = WebApplication.CreateBuilder(args);

// allowing the local host frontend domain to access the backend for any operatoin mentioned in the method chaining statement on below
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://127.0.0.1:5500","http://localhost:5500").
        AllowAnyHeader().
        AllowAnyMethod().
        AllowCredentials();
    });
});

// adding the controllers into the server   
builder.Services.AddControllers();

// cookie authentication configuration
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name= "AuthSession";
        options.Cookie.HttpOnly = true; // preventing js to read and write the cookie
        options.Cookie.SameSite = SameSiteMode.Strict; // preventing browser for sending the cooki to other external sites 
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // cookie can be sent via only https conncetion

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

// registering the authorization for the server
builder.Services.AddAuthorization();

// order matters here
var app = builder.Build();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

