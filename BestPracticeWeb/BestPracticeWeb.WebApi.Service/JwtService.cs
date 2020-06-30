using BestPracticeWeb.WebApi.Common;
using BestPracticeWeb.WebApi.IService;
using BestPracticeWeb.WebApi.Model;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
namespace BestPracticeWeb.WebApi.Service
{
    public class JwtService : IJwtSerivce
    {
        private readonly JwtOptions _jwtOptions;

        public JwtService(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }

        /// <summary>
        /// 生成Token
        /// </summary>
        /// <param name="username">用户</param>
        /// <param name="identity">身份</param>
        /// <returns></returns>
        public async Task<string> GenerateToken(LoginRequestModel model)
        {
            try
            {
                var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId,model.NTID),
                new Claim(JwtRegisteredClaimNames.Sub,_jwtOptions.Subject),
                new Claim(JwtRegisteredClaimNames.Jti,await _jwtOptions.JtiGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat,_jwtOptions.IssuedAt.ToString())
            };

                var jwt = new JwtSecurityToken(
                    issuer: _jwtOptions.Issuer,
                    audience: _jwtOptions.Audience,
                    claims: claims,
                    notBefore: _jwtOptions.NotBefore,
                    expires: _jwtOptions.Expiration,
                    signingCredentials: await _jwtOptions.SigningCredentials()
                    );

                var encodeJwt = new JwtSecurityTokenHandler().WriteToken(jwt);


                var response = new
                {
                    auth_token = encodeJwt,
                    expires_in = (int)_jwtOptions.ValidFor.TotalSeconds,
                    token_type = "Bearer"
                };

                return JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented });
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }


    }
}
