using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BestPracticeWeb.WebApi.Middlewares
{
   public  class ExceptionAttribute: IExceptionFilter
    {
        private readonly ILogger<ExceptionAttribute> _logger;
        public ExceptionAttribute(ILogger<ExceptionAttribute> logger) 
        {
            this._logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;

            _logger.LogError(context.Exception.Message);

            context.ExceptionHandled = true;
            context.Result = new ExceptionResult((int)status, context.Exception);
        }
    }
}
