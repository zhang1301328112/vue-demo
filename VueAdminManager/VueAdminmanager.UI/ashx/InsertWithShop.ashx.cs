using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VueAdminmanager.UI.Model;

namespace VueAdminmanager.UI.ashx
{
    /// <summary>
    /// InsertWithShop 的摘要说明
    /// </summary>
    public class InsertWithShop : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string name = context.Request["name"];
            string times = context.Request["time"];
            using (MYAdminManagerEntities1 mb = new MYAdminManagerEntities1())
            {
                Buyer buyer = new Buyer();
                buyer.BuyerName = name;
                buyer.HZTime = DateTime.Parse(times);
                mb.Buyer.Add(buyer);
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