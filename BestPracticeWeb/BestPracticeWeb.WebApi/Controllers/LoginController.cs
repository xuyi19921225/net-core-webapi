using System.Threading.Tasks;
using BestPracticeWeb.WebApi.IService;
using BestPracticeWeb.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BestPracticeWeb.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {


        private readonly IJwtSerivce _jwtFactory;
        private readonly ILDAPService _ladpUtility;

        public LoginController(IJwtSerivce jwtFactory, ILDAPService ladpUtility)
        {
            _jwtFactory = jwtFactory;
            _ladpUtility = ladpUtility;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery]LoginRequestModel model)
        {
            string token;

            if (ModelState.IsValid)
            {
                //// 验证AD 账号
                if (_ladpUtility.ValidADUser(model))
                {
                    token = await _jwtFactory.GenerateToken(model);
                }
                else
                {
                    return BadRequest("账号或密码不正确");
                }
            }
            else
            {
                return BadRequest();
            }

            return new OkObjectResult(token);
        }

    }
}