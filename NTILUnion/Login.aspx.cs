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

namespace NTILUnion
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDistric();
            }

        }



        protected void btnLogin_Click(object sender, EventArgs e)
        {

            if ((!string.IsNullOrEmpty(txtUserName.Text.Trim())) && (!string.IsNullOrEmpty(txtPassword.Text.Trim())) && (!string.IsNullOrEmpty(DropAddressDistrictID.SelectedValue.Trim())))
            {

                DataTable tbl = BLL.DaoManager.LoginUser(txtUserName.Text, txtPassword.Text, DropAddressDistrictID.SelectedValue);

                if (tbl.Rows.Count > 0 || tbl.Rows.Count < 75)
                {
                    if (tbl.Rows[0]["errorcode"].ToString() == "1")
                    {
                        //Session["userId"] = tbl.Rows[0]["UserID"].ToString();
                        //Session["username"] = tbl.Rows[0]["UserName"].ToString();
                        //Session["districtID"] = tbl.Rows[0]["districtId"].ToString();
                        //Response.Redirect("/Default.aspx");

                        Session["userId"] = tbl.Rows[0]["UserID"].ToString();
                        Session["username"] = tbl.Rows[0]["UserName"].ToString();
                        Session["districtID"] = tbl.Rows[0]["districtId"].ToString();
                        Response.Redirect("/Default.aspx");



                    }
                    else if (tbl.Rows[0]["errorcode"].ToString() == "1")
                    {
                        //Session["userId"] = tbl.Rows[0]["UserID"].ToString();
                        //Session["username"] = tbl.Rows[0]["UserName"].ToString();
                        //Session["districtID"] = tbl.Rows[0]["districtId"].ToString();
                        //Response.Redirect("/Default.aspx");


                    }
                }

                else
                {
                    msg.InnerHtml = "<div class='alert alert-danger'> <button class='close' data-close='alert'></button><span> Enter any username and password.</span> </div>";
                }
            }

        }





        protected void DropAddressDistrictID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void GetDistric()
        {
            var district = new BLL.District();
            var districtManager = new DistrictManager();
            DataTable tbl = districtManager.CRUD(district, "s");
            DropAddressDistrictID.DataSource = tbl;
            DropAddressDistrictID.DataValueField = "DistrictID";
            DropAddressDistrictID.DataTextField = "District";
            DropAddressDistrictID.DataBind();
        }
    }
}