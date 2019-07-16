using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VueAdminmanager.UI.Model;

namespace VueAdminmanager.UI.ashx
{
    /// <summary>
    /// UpdateGoodsInfo 的摘要说明
    /// </summary>
    public class UpdateGoodsInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            int ids = int.Parse(context.Request.QueryString["ids"]);
            string name = context.Request["name"];
            string places = context.Request["places"];
            using (MYAdminManagerEntities1 mb = new MYAdminManagerEntities1())
            {
                Goods good = mb.Goods.Find(ids);
               var list=mb.CFplace.Select(c => new { c.CFID, c.CFPlaces }).Where(cfs=>cfs.CFPlaces==places ).ToList();
               good.GoodsName = name;
               good.CFID = list[0].CFID;
      
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