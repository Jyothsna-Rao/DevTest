﻿
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace DemoTestApplication.Validations
{
    public class ValidateModelAttribute  : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
          
                if (!actionContext.ModelState.IsValid)
                {
                actionContext.Result = new BadRequestObjectResult(actionContext.ModelState);
                }
           
        }
    }
}
