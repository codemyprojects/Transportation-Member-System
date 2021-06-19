using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAO;


namespace BLL
{
   public  class VDCManager : IMasterActions<VDC>
    {
        public DataTable CRUD(VDC vdc, string flag)
        {

            var cmd = DataAccess.CreateCommand();
            cmd.CommandText = "[Setup].[usp_VDC]";
            cmd.Parameters.AddWithValue("@VdcID", vdc.VdcID);
            cmd.Parameters.AddWithValue("@VDC", vdc.VDCName);
            cmd.Parameters.AddWithValue("@flag", flag);
            return DataAccess.ExecuteReaderCommand(cmd);
        }

        public DataTable GetByVdcId(string DistrictID,string ZoneID)
        {
            var cmd = DataAccess.CreateCommand();
            cmd.CommandText = "[Setup].[usp_VDC]";
            cmd.Parameters.AddWithValue("@Zoneid", ZoneID);
            cmd.Parameters.AddWithValue("@DistrictID", DistrictID);
            cmd.Parameters.AddWithValue("@flag", "z");
            return DataAccess.ExecuteReaderCommand(cmd);
        }

        public DataTable CRUD1(VDC vr, string flag) 
        {

            var cmd = DataAccess.CreateCommand();
            cmd.CommandText = "[Setup].[usp_VDC]";
            cmd.Parameters.AddWithValue("@Zoneid",vr.ZoneID);
            cmd.Parameters.AddWithValue("@DistrictID", vr.DistrictID);
            cmd.Parameters.AddWithValue("@VDC",vr.VDCName);
            cmd.Parameters.AddWithValue("@flag", flag);
            return DataAccess.ExecuteReaderCommand(cmd);
        }

       

        public DataTable SelectById(string VdcID)
        {
            DataTable tbl = new DataTable();

            return tbl;
        }
    }
}
