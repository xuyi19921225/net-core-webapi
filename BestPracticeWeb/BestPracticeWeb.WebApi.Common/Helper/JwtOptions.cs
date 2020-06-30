using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BestPracticeWeb.WebApi.Common
{
    public class JwtOptions
    {
        /// <summary>
        /// 签发主体
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// JWT的接收对象
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// JWT的主题
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 加密的key（SecretKey必须大于16个,是大于，不是大于等于）
        /// </summary>
        public string SecretKey { get; set; }
        
        /// <summary>
        /// 失效时间
        /// </summary>
        public DateTime Expiration => IssuedAt.Add(ValidFor);

        /// <summary>
        /// 生效时间
        /// </summary>
        public DateTime NotBefore => DateTime.UtcNow;

        /// <summary>
        /// JWT的签发时间
        /// </summary>
        public DateTime IssuedAt => DateTime.UtcNow;

        /// <summary>
        /// JWT有效时长
        /// </summary>
        public TimeSpan ValidFor { get; set; } = TimeSpan.FromMinutes(120);

        /// <summary>
        /// 编号
        /// </summary>
        public Func<Task<string>> JtiGenerator => () => Task.FromResult(Guid.NewGuid().ToString());


        /// <summary>
        /// 签名凭证
        /// </summary>
        public Func<Task<SigningCredentials>> SigningCredentials=>()=>Task.FromResult(new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey)),SecurityAlgorithms.HmacSha256));
    }
}
