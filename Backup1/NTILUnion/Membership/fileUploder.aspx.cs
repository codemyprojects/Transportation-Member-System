using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.IO;
using System.Data;
using System.Data.SqlClient;


namespace NTILUnion.Membership
{
    public partial class fileUploder : System.Web.UI.Page
    {
        string UploaderToFileID = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                UploaderToFileID = Convert.ToString(Request.QueryString["id"]);
                SaveFiles(UploaderToFileID);
        }


        public void SaveFiles(string ID)
        {
            string filepath = (Server.MapPath("\\DocFiles\\" + ID + "\\"));

            HttpFileCollection uploadedFiles = Request.Files;


            for (int i = 0; i < uploadedFiles.Count; i++)
            {
                HttpPostedFile userPostedFile = uploadedFiles[i];

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }


                try
                {
                    if (userPostedFile.ContentLength > 0)
                    {
                        userPostedFile.SaveAs(filepath + Path.GetFileName(userPostedFile.FileName));
                    }
                }
                catch (Exception Ex)
                {
                    Response.Write("<script>alert(" + Ex.Message +")</script>");

                }



            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }

    }
}