using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAO;

 
namespace BLL
{

  public   class MembershipTypeManager  :  IMasterActions<MembershipType >
    { 
        public DataTable CRUD(MembershipType membertype, string flag)
        {

            var cmd = DataAccess.CreateCommand();
            cmd.CommandText = "[Setup].[usp_MemberType]";
            cmd.Parameters.AddWithValue("@MemberTypeID", membertype.MemberTypeID);
            cmd.Parameters.AddWithValue("@MemberTypeName", membertype.MemberTypeName);
            cmd.Parameters.AddWithValue("@Description", membertype.Description);
            cmd.Parameters.AddWithValue("@flag", flag);
            return DataAccess.ExecuteReaderCommand(cmd);
        }




        public  DataTable SelectById(string MembershipTypeID)
        {
            DataTable tbl = new DataTable();

            return tbl;
        }
    }
}
