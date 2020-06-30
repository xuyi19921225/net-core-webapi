using System;
using System.Collections.Generic;
using System.Text;

namespace BestPracticeWeb.WebApi.Model
{
    public class User
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 所属部门ID
        /// </summary>
        public int DivisionID { get; set; }

        /// <summary>
        /// 所属厂区ID
        /// </summary>
        public int SiteID { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        public string JobNumber { get; set; }

        /// <summary>
        /// 域账号
        /// </summary>
        public string NTID { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 座机
        /// </summary>
        public string SpecialPlane { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public string RoleID { get; set; }
    }
}
