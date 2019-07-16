using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VueAdminmanager.UI.Model;

namespace VueAdminmanager.UI.ashx
{
    /// <summary>
    /// CFplacesInfo 的摘要说明
    /// </summary>
    public class CFplacesInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            using (MYAdminManagerEntities1 mb = new MYAdminManagerEntities1())
            {
                var list = mb.CFplace.Select(g => new { g.CFID, g.CFPlaces }).ToList();
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