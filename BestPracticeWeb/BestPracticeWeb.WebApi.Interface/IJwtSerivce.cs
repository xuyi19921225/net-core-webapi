using BestPracticeWeb.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BestPracticeWeb.WebApi.IService
{
    public interface IJwtSerivce
    {
        Task<string> GenerateToken(LoginRequestModel model);

    }
}
