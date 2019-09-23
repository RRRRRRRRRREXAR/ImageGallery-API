using ImageGallery.BLL.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGallery.Middleware
{
    public class ResizeMiddleware
    {
        public RequestDelegate _next;

        public ResizeMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, IImageService imageService)
        {
            FormatQuery(context.Request);
            await _next(context);
        }

        public void FormatQuery(HttpRequest request)
        {
            var separated= request.QueryString.Value.Split("&");
        }
    }

    public static class ResizeMiddlewareExtensions
    {
        public static IApplicationBuilder UseResize(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ResizeMiddleware>();
        }
    }
}
