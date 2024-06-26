// Source: https://stackoverflow.com/questions/55337045/where-to-set-custom-claimsprincipal-for-all-httprequests
using System.Security.Claims;

public class CustomMiddleware
{
    private readonly RequestDelegate _next;

    public CustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    // DI per request: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/write?view=aspnetcore-5.0#per-request-middleware-dependencies
    public async Task InvokeAsync(HttpContext httpContext)
    {
        var сlaimsIdentity = httpContext.User.Identity as ClaimsIdentity;
        сlaimsIdentity?.AddClaim(new Claim("EmployeeNumber", "12345"));

        await _next(httpContext);
    }
}