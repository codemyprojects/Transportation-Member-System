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
    public partial class SetupRole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public void save()
        {
            var role = new ROLE
            {
                Role = txtUserRole.Text.Trim(),
            }; var roleManager = new DistrictManager();
            DataTable tbl = roleManager.CRUD1(role,"i");
           
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            save();
            Clear();

        }

        public void Clear()
        {
            txtUserRole.Text = string.Empty;
        }


    }
}