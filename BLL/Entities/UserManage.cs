using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Entities
{
   public  class UserManage
    {


        public int UserID { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public string UseName { get;set;}
        public string UserPhoto{get;set;}
        public bool IsActive { get; set; }
        } 
        
}
