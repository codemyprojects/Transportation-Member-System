using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
 public class USER
    {

        public int? UserID { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string Mobile { get; set; }
        public string Post { get; set; }
        public string Role { get; set; }
        public string CreatedBy { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        //public string IsActive { get; set; }
        public bool IsActive { get; set; }


    }
}
