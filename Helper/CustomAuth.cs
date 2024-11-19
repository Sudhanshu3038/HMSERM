using HMSERM.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace HMSERM.Helper
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuth : Attribute, IAuthorizationFilter
    {
        private readonly IList<string> _roles;

        public CustomAuth(string[] roles)
        {
            _roles = roles ?? new string[] { };
        }
        
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            
            var user = (User)context.HttpContext.Items["User"];
            if (user == null)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" })
                { StatusCode = StatusCodes.Status401Unauthorized };
                return;
            }

         
            var userRoleString = user.Role.ToString();  
            if (_roles.Any() && !_roles.Contains(userRoleString))
            {
                context.Result = new JsonResult(new { message = "Forbidden: You do not have the required permissions." })
                { StatusCode = StatusCodes.Status403Forbidden };
            }
        }
    }
}
