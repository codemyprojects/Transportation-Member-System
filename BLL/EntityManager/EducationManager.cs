using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAO;

namespace BLL
{
    public class EducationManager : IMasterActions<Education>

    {

        public DataTable CRUD(Education Edu, string flag)
        {
            
            var cmd = DataAccess.CreateCommand();
            cmd.CommandText = "[Setup].[usp_Education]";
            cmd.Parameters.AddWithValue("@EducationID", Edu.EducationID);
            cmd.Parameters.AddWithValue("@EducationName", Edu.EducationName);
            cmd.Parameters.AddWithValue("@EducationDescription", Edu.EducationDescription);
            cmd.Parameters.AddWithValue("@flag", flag);
            return DataAccess.ExecuteReaderCommand(cmd);
        }




        public DataTable SelectById(string EducationID)
        {
            DataTable tbl = new DataTable();

            return tbl;
        }
    }
}
