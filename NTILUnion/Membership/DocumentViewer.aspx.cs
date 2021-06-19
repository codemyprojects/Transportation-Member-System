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
    public partial class DocumentViewer : System.Web.UI.Page
    {
        public string imageViewer = "";
        public string downloadid = "";

        protected void Page_Load(object sender, EventArgs e)
        {
           


            // ViewFiles("79");
            if (!string.IsNullOrEmpty(Request.QueryString["MembershipID"]))
            {
                imageViewer = Request.QueryString["MembershipID"];
                ViewFiles(imageViewer);
            }
        }




        public void ViewFiles(string ID)
        {


            StringBuilder sb = new StringBuilder();

            if (Directory.Exists(Server.MapPath("~\\DocFiles\\" + ID + "\\")))
            {

                sb.AppendLine("<ul>");
                ImageViewwer.InnerHtml = sb.ToString();
                string[] fileEntries = Directory.GetFiles(Server.MapPath("~\\DocFiles\\" + ID + "\\"));
                foreach (string fileName in fileEntries)
                {
                    sb.AppendLine("<li>");
                    sb.AppendLine("<figure class='img-wrapper fade'><a class='fancybox' href=/DocFiles/" + ID + "/" + Path.GetFileName(fileName) + ">" + "<img  src='/DocFiles/" + ID + "/" + Path.GetFileName(fileName) + "' width='300' height='240'><h4></h4></a></figure>");
                    sb.AppendLine("</li>");
                }
                sb.AppendLine("</ul>");
                ImageViewwer.InnerHtml = sb.ToString();






            }
            //Response.Redirect("/DcoumentViewer.aspx/id="+ imageViewer);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //if (!string.IsNullOrEmpty(Request.QueryString["MembershipID"]))
            //{
            //    downloadid = Request.QueryString["MembershipID"];

            //    downloadfile(downloadid);

            //}



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

        public void downloadMultiple(string ID)
        {


            //string path = Directory.GetFiles(Server.MapPath("~\\DocFiles\\" + ID + "\\"));

            //System.IO.FileInfo file1 = new System.IO.FileInfo(path);


            //Response.AddHeader("content-disposition", "attachment; filename=" + file1.Name);

            //Response.AddHeader("Content-Length", path.Length.ToString());
            //// Response.ContentType = "application/octet-stream";


            //// Response.ContentType = "application/octet-stream";
            //Response.ContentType = "application/jpg";
            //Response.WriteFile(file1.FullName);

            //Response.End();

        }
    }

}


