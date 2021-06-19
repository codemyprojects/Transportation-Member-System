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
    public partial class SearchMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            MemberSearch(dropSearchType.SelectedValue.ToString(), txtSearchText.Text.ToString());

        }

        private void MemberSearch(string flag, string text)
        {

            listData.InnerHtml = "";

            var memberSearch = new BLL.MembershipManager();
            DataTable tbl = memberSearch.Search(flag, text);
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
                sb.AppendLine("<th>Membership Name </th>");
                sb.AppendLine("<th>Citizenship Number</th>");
                sb.AppendLine("<th>Father Name</th>");
                sb.AppendLine("<th>License Number</th>");
                sb.AppendLine("<th>Mobile </th>");
                sb.AppendLine("<th>Email</th>");

                sb.AppendLine("</tr>");
                sb.AppendLine("</thead>");
                sb.AppendLine("<tbody>");


                int i = 0;
                foreach (DataRow row in tbl.Rows)
                {
                    string MembershipID = tbl.Rows[i]["MembershipID"].ToString();
                    string Name = tbl.Rows[i]["Name"].ToString();
                    string CitizeShipNo = tbl.Rows[i]["CitizenShipNO"].ToString();
                    string FatherName = tbl.Rows[i]["FatherName"].ToString();
                    string LicenseNo = tbl.Rows[i]["LicenseNo"].ToString();
                    string Mobile = tbl.Rows[i]["Mobile"].ToString();
                    string Email = tbl.Rows[i]["Email"].ToString();




                    sb.AppendLine("<tr><td class='numeric'>" + (i + 1).ToString() + "</td>");
                    sb.AppendLine("<td><a href='/Membership/Detail.aspx?MembershipID=" + MembershipID + "'> " + Name + "</td>");
                    sb.AppendLine("<td>" + CitizeShipNo + "</td>");
                    sb.AppendLine("<td>" + FatherName + "</td>");
                    sb.AppendLine("<td>" + LicenseNo + "</td>");
                    sb.AppendLine("<td>" + Mobile + "</td>");
                    sb.AppendLine("<td>" + Email + "</td>");




                    //sb.AppendLine("<td style='text-align:center'><a href='?MembershipID=" + MembershipID + "'> Export to Excel </a></td>");
                    ////sb.AppendLine("<td style='text-align:center'><a href='?DeleteID=" + MembershipID + "'> Delete </a></td>");

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

    }
}