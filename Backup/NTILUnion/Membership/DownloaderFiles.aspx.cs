using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BLL;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;

namespace NTILUnion.Membership
{
    public partial class DownloaderFiles : System.Web.UI.Page
    {
        public string downloadid = "";

        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["MembershipID"]))
            {
                downloadid = Request.QueryString["MembershipID"];
                downloadfile(downloadid);
            }


        }

        public void downloadfile(string ID)
        {
            string[] filePath = Directory.GetFiles(Server.MapPath("~\\DocFiles\\" + ID + "\\"));

            foreach (String f in filePath)
            {
                Response.ContentType = "image/jpg";
                System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                response.ClearContent();
                response.Clear();
                //Response.AddHeader("Content-Disposition", string.Format("attachment; filename = \"{0}\"", System.IO.Path.GetFileName(f)));
                Response.AddHeader("Content-Disposition", string.Format("attachment;filename= \"{0}\"", System.IO.Path.GetFileName(f)));
                response.TransmitFile((f));
                response.Flush();
                response.End();
            }
        }
    }
}