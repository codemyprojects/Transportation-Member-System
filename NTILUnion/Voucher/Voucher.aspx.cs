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

namespace NTILUnion.Voucher
{
    public partial class Voucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetDistric();
            Getuser();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            save();
        }

        public void save()
        {
            var mem = new BLL.Voucher
            {
            Amount = txtAmount.ToString(),
            VoucherDate = txtDate.ToString(),
            VoucherNo = txtVoucherNo.ToString(),
            Narration = txtNarration.ToString(),
            Purpose = txtPurpose.ToString(),
            UserID = DropDownUser.SelectedValue.ToString(),
            District = DropAddressDistrictID.SelectedValue.ToString(),


            };

            var memManager = new MembershipManager();
            DataTable tbl = memManager.CRUDV(mem, "i");

        }


        public void GetDistric()
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

        private void Getuser()
        {
            var User = new BLL.USER();
            var UserManager = new BLL.MembershipManager();
            DataTable tbl = UserManager.CRUD2(User, "s");
            DropDownUser.DataSource = tbl;
            DropDownUser.DataValueField = "UserID";
            DropDownUser.DataTextField = "UserName";
            DropDownUser.DataBind();


        }
    }
}