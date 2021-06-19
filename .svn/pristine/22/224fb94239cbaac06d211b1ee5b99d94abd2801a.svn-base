using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAO;

namespace BLL
{
  public   class PostManager : IMasterActions<Post>
    {
        public DataTable CRUD(Post  post, string flag)
        {
           


            var cmd = DataAccess.CreateCommand();
            cmd.CommandText = "[Setup].[usp_Post]";
            cmd.Parameters.AddWithValue("@PostID", post.PostID);
            cmd.Parameters.AddWithValue("@PostName", post.PostName);
            cmd.Parameters.AddWithValue("@Description", post.Description);
            cmd.Parameters.AddWithValue("@flag", flag);
            return DataAccess.ExecuteReaderCommand(cmd);
        }




        public DataTable SelectById(string PostID)
        {
            DataTable tbl = new DataTable();

            return tbl;
        }
    }
}
