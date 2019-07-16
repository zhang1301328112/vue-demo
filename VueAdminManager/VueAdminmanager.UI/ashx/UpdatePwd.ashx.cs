using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VueAdminmanager.UI.Model;

namespace VueAdminmanager.UI.ashx
{
    /// <summary>
    /// UpdatePwd 的摘要说明
    /// </summary>
    public class UpdatePwd : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int ids = int.Parse(context.Request["ids"]);
            string pwd = context.Request["pwd1"];
            string rpwd=context.Request["rpwd1"];
            using (MYAdminManagerEntities1 mb = new MYAdminManagerEntities1())
            {
                AdminUser user = mb.AdminUser.Find(ids);
                if (pwd==user.UserPwd)
	            {
		              user.UserPwd = rpwd ;
                      if (mb.SaveChanges() > 0)
                      {
                          context.Response.Write("ok");
                      }
                      else
                      {
                          context.Response.Write("no");
                      }
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