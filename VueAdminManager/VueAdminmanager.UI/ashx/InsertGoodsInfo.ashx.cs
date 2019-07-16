using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VueAdminmanager.UI.Model;
using System.IO;
namespace VueAdminmanager.UI.ashx
{
    /// <summary>
    /// InsertGoodsInfo 的摘要说明
    /// </summary>
    public class InsertGoodsInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
     
            HttpPostedFile files = context.Request.Files[0];
           // string url = context.Server.MapPath("~/");
            string name = context.Request["GoodsName"];
            int typeid = int.Parse(context.Request["TypeID"]);
            int cfid = int.Parse(context.Request["CFID"]);

            using (MYAdminManagerEntities1 mb = new MYAdminManagerEntities1())
            {
                Goods good = new Goods();
                GoodsType type = mb.GoodsType.Find(typeid);
                CFplace cf = mb.CFplace.Find(cfid);
               
                files.SaveAs(context.Server.MapPath("~/") + "\\attres\\imgs\\" + files.FileName);
                if (File.Exists(context.Server.MapPath("~/") + "\\attres\\imgs\\" + files.FileName))
                {
                    good.GoodsName = name;
                    good.img = files.FileName;
                    good.CFID = cf.CFID;
                    good.TypeID = type.TypeID;
                    mb.Goods.Add(good);
                    if (mb.SaveChanges() > 0)
                    {
                        context.Response.Write("ok");
                    }
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