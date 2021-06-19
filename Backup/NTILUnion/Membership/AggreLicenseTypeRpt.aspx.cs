using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BLL;
using System.IO;

namespace NTILUnion.Membership
{
    public partial class AggreLicenseTypeRpt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void MemberSearch(string flag)
        {

            listData.InnerHtml = "";

            var memberSearch = new BLL.MembershipManager();
            DataTable tbl = memberSearch.Report(flag);
            if (tbl.Rows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<div class='row'>");
                sb.AppendLine("<div class='col-md-12'>");
                sb.AppendLine("<div class='portlet box green'>");
                sb.AppendLine("<div class='portlet-title'>");
                sb.AppendLine("<div class='caption'><i class='fa fa-cogs'></i>Search Result</div>");
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
                sb.AppendLine("<th>License Type </th>");
                sb.AppendLine("<th>Total No. of Members</th>");

                sb.AppendLine("</tr>");
                sb.AppendLine("</thead>");
                sb.AppendLine("<tbody>");


                int i = 0;
                foreach (DataRow row in tbl.Rows)
                {
                   
                    string LicenseType = tbl.Rows[i]["LicenseType"].ToString();

                  
                    string Total = tbl.Rows[i]["Total"].ToString();

                    sb.AppendLine("<tr><td class='numeric'>" + (i + 1).ToString() + "</td>");
                  
                    sb.AppendLine("<td>" + LicenseType + "</td>");
                    //sb.AppendLine("<td>" + Gender + "</td>");
                    sb.AppendLine("<td>" + Total + "</td>");




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
            else
            {
                listData.InnerHtml = "No record Found" + "<div class='close-note'></div>";
            }



        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                MemberSearch(dropSearchType.SelectedValue.ToString());
            }

        }
    }
}