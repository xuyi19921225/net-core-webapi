using BestPracticeWeb.WebApi.Common;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BestPracticeWeb.WebApi.Middlewares
{
    public class ExceptionResult : ObjectResult
    {
        public ExceptionResult(int? code, Exception exception)
                : base(new ExceptionResultModel(code, exception))
        {
            StatusCode = code;
        }
    }
}
