using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using BLL;
using System.IO;

namespace NTILUnion
{
    public partial class LoginRecords : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SearchMember(dropSearchType.SelectedValue.ToString(), txtSearchText.Text);

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //SearchMember(dropSearchType.SelectedValue.ToString(), txtSearchText.Text);
        }


        private void SearchMember(string flag, string searchText)
        {

            listData.InnerHtml = "";

            var memberSearch = new BLL.MembershipManager();
            DataTable tbl = memberSearch.find("s", searchText);
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
                sb.AppendLine("<th>UserID</th>");
                sb.AppendLine("<th>User Name </th>");
                sb.AppendLine("<th>User Password</th>");
                sb.AppendLine("<th>User Address</th>");
                sb.AppendLine("<th>User Mobile</th>");
                sb.AppendLine("<th>User Email </th>");
                sb.AppendLine("</tr>");
                sb.AppendLine("</thead>");
                sb.AppendLine("<tbody>");


                int i = 0;
                foreach (DataRow row in tbl.Rows)
                {
                    string UserID = tbl.Rows[i]["UserID"].ToString();
                    string userName = tbl.Rows[i]["UserName"].ToString();
                    string UserPassword = tbl.Rows[i]["UserPassword"].ToString();
                    string UserAddress = tbl.Rows[i]["UserAddress"].ToString();
                    string UserMobile = tbl.Rows[i]["UserMobile"].ToString();
                    string UserEmail = tbl.Rows[i]["UserEmail"].ToString();
                    sb.AppendLine("<tr><td class='numeric'>" + (i + 1).ToString() + "</td>");
                    sb.AppendLine("<td><a href='/Membership/LoginRecords.aspx/UserID=" + userName+ "'> " + userName + "</td>");
                    sb.AppendLine("<td>" + UserPassword + "</td>");
                    sb.AppendLine("<td>" + UserAddress + "</td>");
                    sb.AppendLine("<td>" + UserMobile + "</td>");
                    sb.AppendLine("<td>" + UserEmail + "</td>");

                    sb.AppendLine("<td style='text-align:center'><a href='?MembershipTypeID=" + UserID + "'> Edit </a></td>");
                    sb.AppendLine("<td style='text-align:center'><a href='?DeleteID=" + UserID + "'> Delete </a></td>");


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