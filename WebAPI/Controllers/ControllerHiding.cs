using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Hosting;

namespace WebAPI.Controllers
{
    public class ControllerHidingConvention : IControllerModelConvention
    {
        IWebHostEnvironment env;

        public ControllerHidingConvention(IWebHostEnvironment env)
        {
            env = this.env;
        }

    
        public void Apply(ControllerModel controller)
        {
            if (env.IsDevelopment())
            {
                if (controller.ControllerName == "Auth")
                {
                    controller.ApiExplorer.IsVisible = true;
                }
            }
        }
    }
}
