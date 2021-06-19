using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAO;

namespace BLL
{
    public class DaoManager
    {

        public static DataTable LoginUser(string UserName, string UserPassword, string UserDistrict)
        {

            var cmd = DataAccess.CreateCommand();
            cmd.CommandText = "[Administartion].[usp_LoginUser]";
            cmd.Parameters.AddWithValue("@flag","l");
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@UserPassword", UserPassword);
            cmd.Parameters.AddWithValue("@UserDistrict", UserDistrict);
            return DataAccess.ExecuteReaderCommand(cmd);   
        }

        //public static DataTable LoginUserk(string UserName, string UserPassword, string UserDistrict)
        //{

        //    var cmd = DataAccess.CreateCommand();
        //    cmd.CommandText = "[Administartion].[usp_LoginUser]";
        //    cmd.Parameters.AddWithValue("@flag", "k");
        //    cmd.Parameters.AddWithValue("@UserName", UserName);
        //    cmd.Parameters.AddWithValue("@UserPassword", UserPassword);
        //    cmd.Parameters.AddWithValue("@UserDistrict", UserDistrict);
        //    return DataAccess.ExecuteReaderCommand(cmd);
        //}


        
    }
}
