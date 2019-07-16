using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VueAdminmanager.UI.Model;

namespace VueAdminmanager.UI.ashx
{
    /// <summary>
    /// Logincheck 的摘要说明
    /// </summary>
    public class Logincheck : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string phone = context.Request.QueryString["phone"];
            string pwd = context.Request.QueryString["pwd"];

            using (MYAdminManagerEntities1 mb = new MYAdminManagerEntities1())
            {
                var user = mb.AdminUser.Select(u => new { u.UserPhone, u.UserPwd }).Where(u => u.UserPhone == phone).ToList();
                AdminUser ad = new AdminUser();
                ad.UserPhone = user[0].UserPhone;
                ad.UserPwd = user[0].UserPwd;
                if (ad.UserPhone == user[0].UserPhone && ad.UserPwd == user[0].UserPwd)
                    {
                        context.Response.Write("ok");
                    }
                else
                {
                    context.Response.Write("no");
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