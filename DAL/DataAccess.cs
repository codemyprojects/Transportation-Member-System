using System;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using Connector;
using System.Globalization;

namespace DAO
{
    public class DataAccess
    {


        public static SqlCommand CreateCommand()
        {
            var con = new SqlConnection {ConnectionString = Connect.DoConnect()};
            var cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }

        public static DataTable ExecuteReaderCommand(SqlCommand cmd)
        {
            try
            {
                cmd.Connection.Open();
                
                var rdr = cmd.ExecuteReader();
                var tbl = new DataTable();
                tbl.Load(rdr);
                return tbl;
            }
            finally
            {
                cmd.Connection.Close();
            }
            
        }



        ~DataAccess()
        {
            GC.Collect();
            
        }
    }

    
}
