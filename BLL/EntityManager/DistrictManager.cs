using System.Data;
using DAO;

namespace BLL
{
   public  class DistrictManager : IMasterActions<District>

    {
        public DataTable CRUD(District  district, string flag)
        {

            var cmd = DataAccess.CreateCommand();
            cmd.CommandText = "[Setup].[usp_District]";
            cmd.Parameters.AddWithValue("@DistrictID", district.DistrictID);
            cmd.Parameters.AddWithValue("@District", district.Districtname);
            cmd.Parameters.AddWithValue("@ZoneID", district.ZoneID);
            cmd.Parameters.AddWithValue("@flag", flag);
            return DataAccess.ExecuteReaderCommand(cmd);
            
        }


        public DataTable CRUD1(ROLE role, string flag)
        {

            var cmd = DataAccess.CreateCommand();
            cmd.CommandText = "[dbo].[uspRole]";
            cmd.Parameters.AddWithValue("@RoleID",role.RoleID);
            cmd.Parameters.AddWithValue("@Role",role.Role);
            cmd.Parameters.AddWithValue("@flag", flag);
            return DataAccess.ExecuteReaderCommand(cmd);

        }

        public DataTable GetByRoleId(string RoleID)
        {
            DataTable tbl = new DataTable();

            return tbl;

        }
        
        public DataTable GetByZoneId(string zoneId)
        {
            var cmd = DataAccess.CreateCommand();
            cmd.CommandText = "[Setup].[usp_District]";
            cmd.Parameters.AddWithValue("@ZoneID", zoneId);
            cmd.Parameters.AddWithValue("@flag", "z");
            return DataAccess.ExecuteReaderCommand(cmd);
        }


        //public DataTable roleSelect(string Roleid)
        //{
        //    var cmd = DataAccess.CreateCommand();
        //    cmd.CommandText = "[dbo].[uspRole]";
        //    cmd.Parameters.AddWithValue("@RoleID", Roleid);
        //    cmd.Parameters.AddWithValue("@flag", "s");

        //    return DataAccess.ExecuteReaderCommand(cmd);
        //}

       

        public DataTable SelectById(string DistrictID)
        {
            DataTable tbl = new DataTable();

            return tbl;
        }

       
    }
}
