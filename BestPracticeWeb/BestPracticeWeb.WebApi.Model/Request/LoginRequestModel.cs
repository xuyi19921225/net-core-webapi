using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BestPracticeWeb.WebApi.Model
{
    public class LoginRequestModel
    {
        [Required(ErrorMessage = "NTID不能为空！")]
        public string NTID { get; set; }

        [Required(ErrorMessage = "密码不能为空！")]
        public string Password { get; set; }
    }
}
