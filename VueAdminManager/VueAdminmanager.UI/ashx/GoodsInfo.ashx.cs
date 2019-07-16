using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VueAdminmanager.UI.Model;

namespace VueAdminmanager.UI.ashx
{
    /// <summary>
    /// GoodsInfo 的摘要说明
    /// </summary>
    public class GoodsInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            using (MYAdminManagerEntities1 mb = new MYAdminManagerEntities1())
            {
                var list = mb.Goods.Select(g => new { g.GoodsID, g.GoodsName, g.img, g.GoodsType.TypeName, g.CFplace.CFPlaces }).ToList();
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