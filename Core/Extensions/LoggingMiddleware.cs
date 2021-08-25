using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace WebAPI.Log
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _request;

        public LoggingMiddleware(RequestDelegate request)
        {
            _request = request;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _request(context);
            
            }
            finally
            {
                string timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.ff",
                    CultureInfo.InvariantCulture);
               
                
                string logText =
                    $"{context.Request?.Method}{context.Request?.Path.Value}=>{context.Response?.StatusCode}{timestamp}{Environment.NewLine}";
                File.AppendAllText("log.txt",logText);
            }
        }
    }
}
