using HMSERM.Data;
using HMSERM.Helper;

namespace HMSERM.MiddleWare
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task InvokeAsync(HttpContext context, IConfiguration configuration, ApplicationDbContext dbContext)
        {
            var token = context.Request.Headers["Authentication"].FirstOrDefault()?.Split(" ").Last();
            var userId = JwtHelper.ValidateJwtToken(token, configuration.GetValue<string>("JWT:IssuerSigningKey"));
            if (userId != null)
            {
                context.Items["User"] = dbContext.Users.FirstOrDefault(x => x.UserId == userId);
            }

            return _next(context);
        }
    }
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class JwtMiddlewareExtensions
    {
        public static IApplicationBuilder UseJwtMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JwtMiddleware>();
        }
    }
}
