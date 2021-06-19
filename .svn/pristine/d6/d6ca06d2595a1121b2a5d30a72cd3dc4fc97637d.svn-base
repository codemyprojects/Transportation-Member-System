using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAO;

namespace BLL
{
  public   class ZoneManager : IMasterActions<Zone>

    {
        public DataTable CRUD(Zone zone, string flag)
        {

            var cmd = DataAccess.CreateCommand();
            cmd.CommandText = "[Setup].[usp_Zone]";
            cmd.Parameters.AddWithValue("@ZoneID", zone.ZoneID);
            cmd.Parameters.AddWithValue("@Zone", zone.ZoneName);
            cmd.Parameters.AddWithValue("@flag", flag);
            return DataAccess.ExecuteReaderCommand(cmd);
        }




        public DataTable SelectById(string ZoneID)
        {
            DataTable tbl = new DataTable();

            return tbl;
        }
    }
}
