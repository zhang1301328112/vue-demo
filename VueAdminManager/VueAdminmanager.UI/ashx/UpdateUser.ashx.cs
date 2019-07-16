using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VueAdminmanager.UI.Model;

namespace VueAdminmanager.UI.ashx
{
    /// <summary>
    /// UpdateUser 的摘要说明
    /// </summary>
    public class UpdateUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int ids = int.Parse(context.Request.QueryString["ids"]);
            string name = context.Request["name"];
            string phone = context.Request["phone"];
            using (MYAdminManagerEntities1 mb = new MYAdminManagerEntities1())
            {
                AdminUser user = mb.AdminUser.Find(ids);
                user.UserName = name;
                user.UserPhone = phone;
               
                if (mb.SaveChanges()>0)
                {
                     context.Response.Write("ok");
                }
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