using BestPracticeWeb.WebApi.Common;
using BestPracticeWeb.WebApi.IService;
using BestPracticeWeb.WebApi.Model;
using Microsoft.Extensions.Options;
using System;
using System.DirectoryServices.AccountManagement;

namespace BestPracticeWeb.WebApi.Service
{
    public class LDAPService:ILDAPService
    {
        private readonly LDAPOptions _ladpOptinos;
        public LDAPService(IOptions<LDAPOptions> ladpOptinos)
        {
            _ladpOptinos = ladpOptinos.Value;
        }

        /// <summary>
        /// 验证AD账号是否存在
        /// </summary>
        /// <param name="requesInfo">登录请求实体</param>
        /// <returns></returns>
        public bool ValidADUser(LoginRequestModel requesInfo)
        {
            try
            {
                using (var context = new PrincipalContext(ContextType.Domain, _ladpOptinos.LdapDomain, requesInfo.NTID, requesInfo.Password))
                {
                    if (context.ValidateCredentials(requesInfo.NTID, requesInfo.Password))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
