using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VueAdminmanager.UI.Model;

namespace VueAdminmanager.UI.ashx
{
    /// <summary>
    /// GoodsInfoByID 的摘要说明
    /// </summary>
    public class GoodsInfoByID : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            int ids = int.Parse(context.Request.QueryString["ids"]);
            using (MYAdminManagerEntities1 mb = new MYAdminManagerEntities1())
            {
                if (ids == 0)
                {
                    var list = mb.Goods.Select(g => new { g.GoodsID, g.GoodsName,g.img,g.GoodsType.TypeName,g.CFplace.CFPlaces }).ToList();
                    context.Response.Write(JsonConvert.SerializeObject(list));
                }
                else
                {
                    Goods good = mb.Goods.Find(ids);
                    var list = mb.Goods.Select(g => new { g.GoodsID, g.GoodsName, g.img, g.GoodsType.TypeName, g.CFplace.CFPlaces }).Where(gs => gs.GoodsID == good.GoodsID && gs.GoodsName == good.GoodsName).ToList();
                    context.Response.Write(JsonConvert.SerializeObject(list));
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