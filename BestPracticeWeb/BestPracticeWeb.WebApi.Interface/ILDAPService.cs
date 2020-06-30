using BestPracticeWeb.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BestPracticeWeb.WebApi.IService
{
    public interface ILDAPService
    {
        bool ValidADUser(LoginRequestModel requestModel);
    }
}
