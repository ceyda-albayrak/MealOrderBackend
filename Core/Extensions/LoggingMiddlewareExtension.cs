using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace WebAPI.Log
{
    public static class LoggingMiddlewareExtension
    {
        public static IApplicationBuilder UseLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}
