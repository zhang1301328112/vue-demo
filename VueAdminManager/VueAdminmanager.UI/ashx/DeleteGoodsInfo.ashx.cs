using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VueAdminmanager.UI.Model;

namespace VueAdminmanager.UI.ashx
{
    /// <summary>
    /// DeleteGoodsInfo 的摘要说明
    /// </summary>
    public class DeleteGoodsInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int ids = int.Parse(context.Request.QueryString["ids"]);

            using (MYAdminManagerEntities1 mb = new MYAdminManagerEntities1())
            {
                Goods good = mb.Goods.Find(ids);
                mb.Goods.Remove(good);
                //var userid= mb.AdminUser.FirstOrDefault(model => model.UserID == user.UserID);
                //user.UserID = int.Parse(userid.ToString());
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