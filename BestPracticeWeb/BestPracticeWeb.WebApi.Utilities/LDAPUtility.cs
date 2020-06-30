using BestPracticeWeb.WebApi.Interface;
using BestPracticeWeb.WebApi.Model;
using BestPracticeWeb.WebApi.Service;
using Microsoft.Extensions.Options;
using System;
using System.DirectoryServices.AccountManagement;

namespace BestPracticeWeb.WebApi.Utilities
{
    public class LDAPUtility:ILDAPUtility
    {
        private readonly LDAPOptions _ladpOptinos;
        public LDAPUtility(IOptions<LDAPOptions> ladpOptinos)
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
