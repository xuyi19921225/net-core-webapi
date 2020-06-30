using System;
using System.Collections.Generic;
using System.Text;

namespace BestPracticeWeb.WebApi.Model
{
    public class LoginResponseModel
    {
        public string UserName { get; set; }
        
        public string Auth { get; set; }

        public List<Menu> list { get; set; }
    }

    public class Menu 
    {

    }
}
