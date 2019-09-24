using ImageGallery.BLL.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ImageGallery.Middleware
{
    public class ResizeMiddleware
    {
        public RequestDelegate _next;
        private byte[] img;

        public ResizeMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, IImageService imageService,IHostingEnvironment hostingEnviroment)
        {
            Regex r = new Regex(@"\?id=[\d]+&width=[\d]+&height=[\d]+");
            if (r.IsMatch(context.Request.QueryString.Value))
            {
                string query = context.Request.QueryString.Value.Replace("?", "");
                var go = FormatQuery(query);
               img= await imageService.Resize(Convert.ToInt32(go[1]),Convert.ToInt32(go[2]),Convert.ToInt32(go[3]),hostingEnviroment);
            }
            await _next(context);
            if (img != null)
            {
                await context.Response.WriteAsync(System.Text.Encoding.UTF8.GetString(img));
                img = null;
            }
        }

        private string[] FormatQuery(string query)
        {
             return Regex.Split(query, @"[a-z=&]+");
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
