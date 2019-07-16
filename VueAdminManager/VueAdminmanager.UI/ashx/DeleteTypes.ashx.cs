using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VueAdminmanager.UI.Model;

namespace VueAdminmanager.UI.ashx
{
    /// <summary>
    /// DeleteTypes 的摘要说明   修改
    /// </summary>
    public class DeleteTypes : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int ids = int.Parse(context.Request.QueryString["ids"]);
            string name = context.Request.QueryString["name"];
            using (MYAdminManagerEntities1 mb = new MYAdminManagerEntities1())
            {
                GoodsType goods = mb.GoodsType.Find(ids);
                goods.TypeName = name;
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