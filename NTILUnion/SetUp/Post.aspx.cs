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
    public partial class Post : System.Web.UI.Page
    {
        string PostID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] == null || Session["username"] == null)
            {
                Response.Redirect("/Login.aspx");
            }
            
            if (!IsPostBack)
            {
                GetPostList();

                if (!String.IsNullOrWhiteSpace(Request.QueryString["PostID"]))
                {
                    PostID = Request.QueryString["PostID"];
                    getlistbyPostID(PostID);
                }

                else if (!String.IsNullOrWhiteSpace(Request.QueryString["DeleteID"]))
                {
                    PostID = Request.QueryString["DeleteID"];
                    Deletepost(PostID);
                }
            }
        }

        private void save(string option, string PostId)
        {
            int postid = option == "i" ? 0 : Convert.ToInt32(PostId);

            var pos = new BLL.Post
            {
                PostID = postid,
                PostName = txtPost.Text.Trim(),
                Description = txtDescription.Text.Trim()
            };

            var PosManager = new PostManager ();
            DataTable tbl = PosManager.CRUD(pos, option);
            message.InnerHtml  = "<div class = 'note note-success'>" + "<div class='close-note'>x</div>" + tbl.Rows[0]["mes"].ToString();
            GetPostList();
            fieldclear();
        }

         private void GetPostList()
         {

             listData.InnerHtml = "";

             var posManger = new PostManager();
             var pos = new BLL.Post();
             DataTable tbl = posManger.CRUD(pos, "s");

             StringBuilder sb = new StringBuilder();
             if (tbl.Rows.Count > 0)
             {
                 sb.AppendLine("<div class='row'>");
                 sb.AppendLine("<div class='col-md-12'>");
                 sb.AppendLine("<div class='portlet box green'>");
                 sb.AppendLine("<div class='portlet-title'>");
                 sb.AppendLine("<div class='caption'><i class='fa fa-cogs'></i>Post Information</div>");
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
                 sb.AppendLine("<th>Post </th>");

                 sb.AppendLine("<th>Description</th>");

                 sb.AppendLine("<th Colspan=2 style='text-align:center'>Actions</th>");
                 sb.AppendLine("</tr>");
                 sb.AppendLine("</thead>");
                 sb.AppendLine("<tbody>");


                 int i = 0;
                 foreach (DataRow row in tbl.Rows)
                 {
                     string PostID = tbl.Rows[i]["PostID"].ToString();
                     string PostName = tbl.Rows[i]["PostName"].ToString();

                     string PostDescription = tbl.Rows[i]["Description"].ToString();

                     sb.AppendLine("<tr><td class='numeric'>" + (i + 1).ToString() + "</td>");
                     sb.AppendLine("<td>" + PostName + "</td>");
                     sb.AppendLine("<td>" + PostDescription + "</td>");

                     sb.AppendLine("<td style='text-align:center'><a href='?PostID=" + PostID + "'> Edit </a></td>");
                     sb.AppendLine("<td style='text-align:center'><a href='?DeleteID=" + PostID + "'> Delete </a></td>");

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
                 PostID = Request.QueryString["PostID"];
                 save("u", PostID);
             }
             else
             {
                 save("i", "");
             }
             btnSubmit.Text = "Submit";
         }

         protected void getlistbyPostID(string ID)
         {
             var PostManager = new PostManager();
             var post = new BLL.Post();
             post.PostID = Convert.ToInt32(ID);
             DataTable tbl = PostManager.CRUD(post, "s");

             if (tbl.Rows.Count > 0)
             {
                 txtPost.Text = tbl.Rows[0]["PostName"].ToString();
                 txtDescription.Text = tbl.Rows[0]["Description"].ToString();
                 btnSubmit.Text = "Update";
             }

         }

         private void Deletepost(string ID)
         {

             var pos = new BLL.Post
             {

                PostID = Convert.ToInt32(ID)
             };

             var PosManager = new PostManager();
             DataTable tbl = PosManager.CRUD(pos, "d");
             message.InnerHtml = "<div class = 'note note-success'>" + "<div class='close-note'>x</div>" + tbl.Rows[0]["mes"].ToString();
             GetPostList();
         }

         void fieldclear()
         {
             txtDescription.Text = string.Empty;
             txtPost.Text = string.Empty;
         }
    }
}

