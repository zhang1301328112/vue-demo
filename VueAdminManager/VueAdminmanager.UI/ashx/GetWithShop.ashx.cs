using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VueAdminmanager.UI.Model;

namespace VueAdminmanager.UI.ashx
{
    /// <summary>
    /// GetWithShop 的摘要说明
    /// </summary>
    public class GetWithShop : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            using (MYAdminManagerEntities1 mb = new MYAdminManagerEntities1())
            {
                Buyer buy=new Buyer ();
                
                var list = mb.Buyer.Select(g => new { g.BuyID, g.BuyerName, g.HZTime }).OrderByDescending(g=>g.HZTime).ToList();
                
              
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