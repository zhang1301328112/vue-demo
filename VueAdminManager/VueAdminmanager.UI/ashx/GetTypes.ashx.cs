using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
using Newtonsoft.Json;
using VueAdminmanager.UI.Model;
namespace VueAdminmanager.UI.ashx
{
    /// <summary>
    /// GetTypes 的摘要说明
    /// </summary>
    public class GetTypes : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            using (MYAdminManagerEntities1 mb = new MYAdminManagerEntities1())
            {
                var list = mb.GoodsType.Select(g => new { g.TypeID, g.TypeName }).ToList();
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