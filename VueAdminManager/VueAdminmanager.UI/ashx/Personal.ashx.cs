using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VueAdminmanager.UI.Model;

namespace VueAdminmanager.UI.ashx
{
    /// <summary>
    /// Personal 的摘要说明
    /// </summary>
    public class Personal : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            using (MYAdminManagerEntities1 mb = new MYAdminManagerEntities1())
            {
                var list = mb.AdminUser.Select(g => new { g.UserID, g.UserName, g.UserPhone,g.UserPwd }).Where(g=> g.UserID==1).ToList();
                context.Response.Write(JsonConvert.SerializeObject(list));
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}