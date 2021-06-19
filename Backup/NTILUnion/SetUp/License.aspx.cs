using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using System.Text;

namespace NTILUnion.SetUp
{
    public partial class License : System.Web.UI.Page
    {
        string LicenseID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] == null || Session["username"] == null)
            {
                Response.Redirect("/Login.aspx");
            }
           
            if (!IsPostBack)
            {
                GetLicenseList();

                if (!String.IsNullOrWhiteSpace(Request.QueryString["LicenseID"]))
                {
                    LicenseID = Request.QueryString["LicenseID"];
                    GetLicenseListByID(LicenseID);
                }

                else if (!String.IsNullOrWhiteSpace(Request.QueryString["DeleteID"]))
                {
                    LicenseID = Request.QueryString["DeleteID"];
                    DeleteLicense(LicenseID);
                }
            }
        }

        private void save(string option, string licenseId)
        {
            int licenseid = option == "i" ? 0 : Convert.ToInt32(licenseId);

            var Lic = new BLL.License
            {
                LicenseID = licenseid,
                Licensename = txtLicense.Text.Trim(),
                Description = txtDescription.Text.Trim()
            };

            var licManger = new LicenseManager();
            DataTable tbl = licManger.CRUD(Lic , option);
            message.InnerHtml = "<div class = 'note note-success'>" + "<div class='close-note'>x</div>" + tbl.Rows[0]["mes"].ToString();
             GetLicenseList();
             fieldclear();
        }

        private void GetLicenseList()
        {
            listData.InnerHtml = "";

            var licenseManager = new LicenseManager();
            var Lic = new BLL.License();
            DataTable tbl = licenseManager.CRUD(Lic, "s");

            StringBuilder sb = new StringBuilder();
            if (tbl.Rows.Count > 0)
            {

                sb.AppendLine("<div class='row'>");
                sb.AppendLine("<div class='col-md-12'>");
                sb.AppendLine("<div class='portlet box green'>");
                sb.AppendLine("<div class='portlet-title'>");
                sb.AppendLine("<div class='caption'><i class='fa fa-cogs'></i>License Information</div>");
                sb.AppendLine("<div class='tools'>");
                sb.AppendLine("<a href='javascript:;' class='collapse'></a>");
                sb.AppendLine("<a href='#portlet-config' data-toggle='modal' class='config'></a>");
                sb.AppendLine("<a href='javascript:;' class='reload'></a>");
                sb.AppendLine("<a href='javascript:;' class='remove'></a>");
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");
                sb.AppendLine("<div class='portlet-body flip-scroll'>");

                
                sb.AppendLine("<table class='table table-bordered table-striped table-condensed flip-content'>");
                sb.AppendLine("<thead class='flip-content'>");
                sb.AppendLine("<tr>");
                sb.AppendLine("<th>S.N</th>");
                sb.AppendLine("<th>License </th>");

                sb.AppendLine("<th>Description</th>");

                sb.AppendLine("<th Colspan=2 style='text-align:center'>Actions</th>");
                sb.AppendLine("</tr>");
                sb.AppendLine("</thead>");
                sb.AppendLine("<tbody>");


                int i = 0;
                foreach (DataRow row in tbl.Rows)
                {
                    string LicenseID = tbl.Rows[i]["LicenseID"].ToString();
                    string Licensename = tbl.Rows[i]["License"].ToString();

                    string Description = tbl.Rows[i]["Description"].ToString();

                    sb.AppendLine("<tr><td class='numeric'>" + (i + 1).ToString() + "</td>");
                    sb.AppendLine("<td>" + Licensename + "</td>");
                    sb.AppendLine("<td>" + Description + "</td>");

                    sb.AppendLine("<td style='text-align:center'><a href='?LicenseID=" + LicenseID + "'> Edit </a></td>");
                    sb.AppendLine("<td style='text-align:center'><a href='?DeleteID=" + LicenseID + "'> Delete </a></td>");

                    sb.AppendLine("</tr>");

                    i += 1;
                }



                sb.AppendLine("</tbody>");
                sb.AppendLine("</table>");
                sb.AppendLine(" </div>");
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");
                listData.InnerHtml = sb.ToString();
            }
        }

        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            if (btnSubmit.Text.ToLower() == "update")
            {
                LicenseID = Request.QueryString["LicenseID"];
                save("u", LicenseID);
            }
            else
            {
                save("i", "");
            }
            btnSubmit.Text = "Submit";
            
        }

        private void DeleteLicense(string ID)
        {

            var Lic = new BLL.License
            {

                LicenseID = Convert.ToInt32(ID)
            };

            var licManger = new LicenseManager();
            DataTable tbl = licManger.CRUD(Lic, "d");
            message.InnerHtml = "<div class = 'note note-success'>" + "<div class='close-note'>x</div>" + tbl.Rows[0]["mes"].ToString();
            GetLicenseList();
        }

        private void GetLicenseListByID(string ID)
        {
            var LicenseManager = new LicenseManager();
            var lic = new BLL.License();
            lic.LicenseID = Convert.ToInt32(ID);
            DataTable tbl = LicenseManager.CRUD(lic, "s");

            if (tbl.Rows.Count > 0)
            {
                txtLicense.Text = tbl.Rows[0]["License"].ToString();
                txtDescription.Text = tbl.Rows[0]["Description"].ToString();
                btnSubmit.Text = "Update";
            }

        }

        void fieldclear()
        {
            txtDescription.Text = string.Empty;
            txtLicense.Text = string.Empty;
        }

    }
}