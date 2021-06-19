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
    public partial class userCreate : System.Web.UI.Page
    {
        //public Boolean b;
        public int Districtid;
        public int Postid;
        public int Roleid;
        public int i = 0;
        public Boolean b;
        public bool IsActive { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetPost(Postid);
                GetDistric(Districtid);
                GetRole(Roleid);
            }

        }

        private void GetPost( int pid)
        {

            var Post = new BLL.Post();
            var PostManager = new BLL.PostManager();
            DataTable tbl = PostManager.CRUD(Post, "s");
            DropPost.DataSource = tbl;
            if (tbl.Rows.Count > 0)
            {
                DropPost.DataValueField = "PostID";
                DropPost.DataTextField = "PostName";
                DropPost.DataBind();
            }


        }


       

        public void GetDistric(int did)
        {
            var district = new BLL.District();
            var districtManager = new DistrictManager();
            DataTable tbl = districtManager.CRUD(district, "s");
            DropAddressDistrictID.DataSource = tbl;
            if (tbl.Rows.Count > 0)
            {
                DropAddressDistrictID.DataValueField = "DistrictID";
                DropAddressDistrictID.DataTextField = "District";
                DropAddressDistrictID.DataBind();
            }
        }

        public void GetRole(int rid)
        {

            var role = new BLL.ROLE();
            var roleManager = new DistrictManager();
            DataTable tbl = roleManager.CRUD1(role,"s");
            DropRole.DataSource = tbl;
            if (tbl.Rows.Count > 0)
            {
               
                    DropRole.DataValueField = "RoleID";
                    DropRole.DataTextField = "Role";
                    DropRole.DataBind();
                
            }


        }

        protected void DropAddressDistrictID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropAddressDistrictID.SelectedValue!=null)
            {
               Districtid= Convert.ToInt32(DropAddressDistrictID.SelectedValue);
               GetDistric(Districtid);
            }
            
        }

        

        public void Status()
        {
            //int i = 0;
            if (i == 1)
            {
                b = true;

            }
            else
            {
                b = false;
            }

        }

        public void save()
        {

            var user = new USER
            {
                UserName = txtUserName.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                District = DropAddressDistrictID.SelectedValue,
                Mobile = txtMobile.Text.Trim(),
                Post = DropPost.SelectedValue,
                Role = DropRole.SelectedValue,
                IsActive = ChekIsActive.Checked,
                CreatedBy = Session["userId"].ToString(),
                

            }; var userManager = new MembershipManager();
            DataTable tbl = userManager.CRUD1(user, "i");
          

            
            if (ChekIsActive.Checked == true)
            {


                IsActive = true;
            }
            else
            {
                IsActive = false;

            }

        }



        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            save();
            Clear();
        }


        public void Clear()
        {

            txtUserName.Text = "";
            txtPassword.Text = "";
            txtMobile.Text = "";
            txtPassword.Text = "";
            txtAddress.Text = "";
           
        }

        protected void DropPost_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropPost.SelectedValue != null)
            {
                Postid = Convert.ToInt32(DropPost.SelectedValue);
                GetPost(Postid);
                
            }
            

        }

        protected void DropRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropRole.SelectedValue !=null)
            {
                Roleid = Convert.ToInt32(DropRole.SelectedValue);
                GetRole(Roleid);
            }

        }

    }
}