﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BestPracticeWeb.WebApi.Common
{
    public class ExceptionResultModel : BaseResultModel
    {
        public ExceptionResultModel(int? code, Exception exception)
        {
            Code = code;
            Message = exception.InnerException != null ?
                exception.InnerException.Message :
                exception.Message;
            Result = exception.Message;
            ReturnStatus = ReturnStatus.Error;
        }
    }
}
