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
    public partial class MembershipType : System.Web.UI.Page
    {
        string MemberTypeID;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["userId"] == null || Session["username"] == null)
            {
                Response.Redirect("/Login.aspx");
            }
            if (!IsPostBack)
            {
                GetMembershipTypeList();

                if (!String.IsNullOrWhiteSpace(Request.QueryString["MemberTypeID"]))
                {
                    MemberTypeID = Request.QueryString["MemberTypeID"];
                    GetMemberTypelistbyID(MemberTypeID);
                }

                else if (!String.IsNullOrWhiteSpace(Request.QueryString["DeleteID"]))
                {
                    MemberTypeID = Request.QueryString["DeleteID"];
                    DeleteMembershiptype(MemberTypeID);
                }
            }
        }

        private void save(string option, string MembershipeTypeId)
        {
            int MembershipeTypeid = option == "i" ? 0 : Convert.ToInt32(MembershipeTypeId);
            var Memtype = new BLL.MembershipType
            {
                MemberTypeID = MembershipeTypeid,
                MemberTypeName  = txtMemberTypeName.Text.Trim(),
                Description = txtDescription.Text.Trim()
            };

            var MemtypeManager = new BLL.MembershipTypeManager();
            DataTable tbl = MemtypeManager.CRUD(Memtype, option);
            message.InnerHtml = "<div class = 'note note-success'>" + "<div class='close-note'>x</div>" + tbl.Rows[0]["mes"].ToString();
            GetMembershipTypeList();
            fieldClear();


        }

        private void GetMembershipTypeList()
        {

            listData.InnerHtml = "";
            var MemtypeManager = new MembershipTypeManager();
            var mem = new BLL.MembershipType();
            DataTable tbl = MemtypeManager.CRUD(mem, "s");
            StringBuilder sb = new StringBuilder();
            if (tbl.Rows.Count > 0)
            {
                sb.AppendLine("<div class='row'>");
                sb.AppendLine("<div class='col-md-12'>");
                sb.AppendLine("<div class='portlet box green'>");
                sb.AppendLine("<div class='portlet-title'>");
                sb.AppendLine("<div class='caption'><i class='fa fa-cogs'></i>Membership Type Information</div>");
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
            sb.AppendLine("<th>Member Type Name </th>");

            sb.AppendLine("<th>Description</th>");

            sb.AppendLine("<th Colspan=2 style='text-align:center'>Actions</th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");


            int i = 0;
            foreach (DataRow row in tbl.Rows)
            {
                string MemberTypeID = tbl.Rows[i]["MemberTypeID"].ToString();
                string MemberTypeName = tbl.Rows[i]["MemberTypeName"].ToString();

                string Description = tbl.Rows[i]["Description"].ToString();

                sb.AppendLine("<tr><td class='numeric'>" + (i + 1).ToString() + "</td>");
                sb.AppendLine("<td>" + MemberTypeName + "</td>");
                sb.AppendLine("<td>" + Description + "</td>");

                sb.AppendLine("<td style='text-align:center'><a href='?MemberTypeID=" + MemberTypeID + "'> Edit </a></td>");
                sb.AppendLine("<td style='text-align:center'><a href='?DeleteID=" + MemberTypeID + "'> Delete </a></td>");

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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text.ToLower() == "update")
            {
                MemberTypeID = Request.QueryString["MemberTypeID"];
                save("u", MemberTypeID);
            }
            else
            {
                save("i", "");
            }
            btnSubmit.Text = "Submit";
            
        }

        private void DeleteMembershiptype(string ID)
        {

            var Memtype = new BLL.MembershipType
            {

                MemberTypeID = Convert.ToInt32(ID)
            };

            var MemtypeManager = new BLL.MembershipTypeManager();
            DataTable tbl = MemtypeManager.CRUD(Memtype, "d");
            message.InnerHtml = "<div class = 'note note-success'>" + "<div class='close-note'>x</div>" + tbl.Rows[0]["mes"].ToString();
            GetMembershipTypeList();
        }

        private void GetMemberTypelistbyID(string ID)
        {
            var MemTypeManager = new MembershipTypeManager();
            var mem = new BLL.MembershipType();
            mem.MemberTypeID = Convert.ToInt32(ID);
            DataTable tbl = MemTypeManager.CRUD(mem, "s");

            if (tbl.Rows.Count > 0)
            {
                txtMemberTypeName.Text = tbl.Rows[0]["MemberTypeName"].ToString();
                txtDescription.Text = tbl.Rows[0]["Description"].ToString();
                btnSubmit.Text = "Update";
            }
        }

        private void fieldClear()
        {
            txtDescription.Text = string.Empty;
            txtMemberTypeName.Text = string.Empty;
        }
       
    }
}