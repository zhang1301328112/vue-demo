using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VueAdminmanager.UI.Model;

namespace VueAdminmanager.UI.ashx
{
    /// <summary>
    /// selectTypeByID 的摘要说明
    /// </summary>
    public class selectTypeByID : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            int ids = int.Parse(context.Request.QueryString["ids"]);
            using (MYAdminManagerEntities1 mb = new MYAdminManagerEntities1())
            {
                if (ids==0)
                {
                    var list = mb.GoodsType.Select(g => new { g.TypeID, g.TypeName }).ToList();
                    context.Response.Write(JsonConvert.SerializeObject(list));
                }
                else
                {
                    GoodsType type = mb.GoodsType.Find(ids);
                    var list = mb.GoodsType.Select(g => new { g.TypeID, g.TypeName }).Where(gs => gs.TypeID == type.TypeID && gs.TypeName == type.TypeName).ToList();
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