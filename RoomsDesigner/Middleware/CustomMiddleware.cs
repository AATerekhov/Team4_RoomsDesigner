using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;

namespace RoomsDesigner.Api.Middleware
{
    public class CustomMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            var user = context.User;
            //TODO: добавить передачу Id пользователя для регистрации сущностей с ним связанных.
            //Место для проверки передаваемых данных.
            var r = user.IsInRole("Seller");
            var isAuthenticated = user.Identity.IsAuthenticated;
            var userClaims = user.Claims;
            await next(context);
        }
    }

    public static class Extensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            if (builder is null) 
                throw new ArgumentNullException(nameof(builder));
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}
