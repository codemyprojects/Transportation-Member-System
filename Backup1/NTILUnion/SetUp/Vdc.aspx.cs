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

using System.Text;


namespace NTILUnion.SetUp
{
    public partial class Vdc : System.Web.UI.Page
    {
        public int zoneID;
        public int DistricID;






        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                GetZone();

            }

            

        }

        private void GetZone()
        {

            var zone = new BLL.Zone();
            var zoneManager = new BLL.ZoneManager();
            DataTable tbl = zoneManager.CRUD(zone, "s");
            DropAddressZoneID.DataSource = tbl;
            if (tbl.Rows.Count > 0)
            {
                DropAddressZoneID.DataValueField = "ZoneID";
                DropAddressZoneID.DataTextField = "Zone";
                DropAddressZoneID.DataBind();
                
            }

            else
            {
                DropAddressZoneID.Items.Insert(0, new ListItem("-- select  Zone -- ", ""));

            }
            
        }

        private void GetDistrict(string zoneID)
        {
            var district = new BLL.District();
            var districtManager = new DistrictManager();
            DataTable tbl = districtManager.GetByZoneId(zoneID);
            DropAddressDistrictID.DataSource = tbl;
            DropAddressDistrictID.DataValueField = "DistrictID";
            DropAddressDistrictID.DataTextField = "District";
            DropAddressDistrictID.DataBind();

        }

        protected void DropAddressDistrictID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropAddressDistrictID.SelectedValue != null)
            {
                DistricID = Convert.ToInt32(DropAddressDistrictID.SelectedValue);
            }

        }


        protected void DropAddressZoneID_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (DropAddressZoneID.SelectedValue != null)
            {
                zoneID = Convert.ToInt32(DropAddressZoneID.SelectedValue);

            }
            GetDistrict(DropAddressZoneID.SelectedValue);


        }


        public void Save()
        {

            var mem = new BLL.VDC
            {
                ZoneID = Convert.ToInt32(DropAddressZoneID.SelectedValue.ToString()),
                DistrictID = Convert.ToInt32(DropAddressDistrictID.SelectedValue.ToString()),
                VDCName = txtVDC.Text.Trim(),
                
            };
            var vdcManager = new VDCManager();
            DataTable tbl = vdcManager.CRUD1(mem, "i");
            fieldClear();
        }


        public void fieldClear()
        {
            
            txtVDC.Text = string.Empty;

        }

        private void GetVDCList()
        {
            var vdcList = new VDCManager();
            var list = new BLL.VDC();
            DataTable tbl = vdcList.CRUD1(list, "s");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div class='row'>");
            sb.AppendLine("<div class='col-md-12'>");
            sb.AppendLine("<div class='portlet box green'>");
            sb.AppendLine("<div class='portlet-title'>");
            sb.AppendLine("<div class='caption'><i class='fa fa-cogs'></i>Passengers Info</div>");
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
            sb.AppendLine("<th>Zone </th>");
            sb.AppendLine("<th>District </th>");
            sb.AppendLine("<th>VDC</th>");
            //sb.AppendLine("<th>Current City</th>");
            //sb.AppendLine("<th>Gender</th>");
            sb.AppendLine("<th Colspan=2 style='text-align:center'>Actions</th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");

            int i = 0;
            foreach (DataRow row in tbl.Rows)
            {
                string ZoneID = tbl.Rows[i]["ZoneID"].ToString();
                string DistrictID = tbl.Rows[i]["DistrictID"].ToString();
                //string VDCName = tbl.Rows[i]["VDC"].ToString();


                sb.AppendLine("<tr><td class='numeric'>" + (i + 1).ToString() + "</td>");

                sb.AppendLine("<td>" + ZoneID + "</td>");
                sb.AppendLine("<td>" + DistrictID + "</td>");
                //sb.AppendLine("<td>" + VDCName + "</td>");

                //sb.AppendLine("<td>" + CurrentCity + "</td>");
                //sb.AppendLine("<td>" + Gender + "</td>");

                //sb.AppendLine("<td style='text-align:center'><a href='?MembershipTypeID=" + MembershipID + "'> Edit </a></td>");
                // sb.AppendLine("<td style='text-align:center'><a href='?DeleteID=" + MembershipID + "'> Delete </a></td>");

                sb.AppendLine("</tr>");

                i += 1;
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
            Save();

        }

    


    }


   }


