using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VueAdminmanager.UI.Model;

namespace VueAdminmanager.UI.ashx
{
    /// <summary>
    /// InsertCFplaces 的摘要说明
    /// </summary>
    public class InsertCFplaces : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string name = context.Request["name"];
          
            using (MYAdminManagerEntities1 mb = new MYAdminManagerEntities1())
            {
                CFplace cf = new CFplace();
                cf.CFPlaces = name;
                mb.CFplace.Add(cf);
                if (mb.SaveChanges() > 0)
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