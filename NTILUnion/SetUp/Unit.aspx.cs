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
    public partial class Unit : System.Web.UI.Page
    {
        string UnitID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] == null || Session["username"] == null)
            {
                Response.Redirect("/Login.aspx");
            }
            if (!IsPostBack)
            {
                GetUnitList();

                if (!String.IsNullOrWhiteSpace(Request.QueryString["UnitID"]))
                {
                    UnitID = Request.QueryString["UnitID"];
                    getlistbyUnitID(UnitID);
                    
                }

                else if (!String.IsNullOrWhiteSpace(Request.QueryString["DeleteID"]))
                {
                    UnitID = Request.QueryString["DeleteID"];
                    DeleteUnit(UnitID);
                }
            }

        }

        private void save( string option, string unitId)
        {
            int unitid= option == "i" ? 0 : Convert.ToInt32(unitId);
            
            var unit = new BLL.Unit
            {
                UnitID = unitid,
                UnitName = txtUnit.Text.Trim(),
                Description = txtDescription.Text.Trim()
            };

            var unitManager = new UnitManager ();
            DataTable tbl = unitManager.CRUD(unit, option);
            message.InnerHtml = "<div class = 'note note-success'>" + "<div class='close-note'>x</div>" + tbl.Rows[0]["mes"].ToString();
            GetUnitList();
            fieldclear();
        }

        private void GetUnitList()
        {
            listData.InnerHtml = "";
            var unitManager = new UnitManager();
            var unit = new BLL.Unit();
            DataTable tbl = unitManager.CRUD(unit, "s");

            StringBuilder sb = new StringBuilder();

            if (tbl.Rows.Count > 0)
            {
                sb.AppendLine("<div class='row'>");
                sb.AppendLine("<div class='col-md-12'>");
                sb.AppendLine("<div class='portlet box green'>");
                sb.AppendLine("<div class='portlet-title'>");
                sb.AppendLine("<div class='caption'><i class='fa fa-cogs'></i>Unit Information</div>");
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
            sb.AppendLine("<th>Unit </th>");
            sb.AppendLine("<th>Description </th>");

            

            sb.AppendLine("<th Colspan=2 style='text-align:center'>Actions</th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");


            int i = 0;
            foreach (DataRow row in tbl.Rows)
            {
                string UnitID = tbl.Rows[i]["UnitID"].ToString();
                string UnitName = tbl.Rows[i]["UnitName"].ToString();
                string Description = tbl.Rows[i]["Description"].ToString();

                sb.AppendLine("<tr><td class='numeric'>" + (i + 1).ToString() + "</td>");
                sb.AppendLine("<td>" + UnitName + "</td>");
                sb.AppendLine("<td>" + Description + "</td>");

                sb.AppendLine("<td style='text-align:center'><a href='?UnitID=" + UnitID + "'> Edit </a></td>");
                sb.AppendLine("<td style='text-align:center'><a href='?DeleteID=" + UnitID + "'> Delete </a></td>");

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

        private void DeleteUnit(string ID)
        {

            var unit = new BLL.Unit
            {

                UnitID = Convert.ToInt32(ID)
                
            };

            var unitManager = new UnitManager();
            DataTable tbl = unitManager.CRUD(unit, "d");

            message.InnerHtml = "<div class = 'note note-success'>" + "<div class='close-note'>x</div>" + tbl.Rows[0]["mes"].ToString();
           
            GetUnitList();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text.ToLower() == "update")
            {
                 UnitID = Request.QueryString["UnitID"];
                 save("u", UnitID);
            }
            else
            {
                save("i", "");
            }
            btnSubmit.Text = "Submit";
            
        }

        protected void getlistbyUnitID(string ID)
        {
            var unitManager = new UnitManager();
            var unit = new BLL.Unit();
            unit.UnitID = Convert.ToInt32(ID);
            DataTable tbl = unitManager.CRUD(unit, "s");

            if (tbl.Rows.Count > 0)
            {
                txtUnit.Text = tbl.Rows[0]["UnitName"].ToString();
                txtDescription.Text = tbl.Rows[0]["Description"].ToString();
                btnSubmit.Text = "Update";
            }

        }


        void fieldclear()
        {
            txtDescription.Text = string.Empty;
            txtUnit.Text = string.Empty;
        }
    }
}