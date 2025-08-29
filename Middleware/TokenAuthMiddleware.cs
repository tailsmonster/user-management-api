namespace userMan.Middleware;

public class TokenAuthMiddleware
{
    private readonly RequestDelegate _next;
    private const string TOKEN_HEADER = "Authorization";
    private const string VALID_TOKEN = "my-secret-token"; // replace with real validation

    public TokenAuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue(TOKEN_HEADER, out var token) || token != VALID_TOKEN)
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsJsonAsync(new { error = "Unauthorized" });
            return;
        }

        await _next(context);
    }
}
