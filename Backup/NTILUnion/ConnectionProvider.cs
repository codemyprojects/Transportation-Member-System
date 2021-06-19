using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace NTILUnion
{
    public class ConnectionProvider
    {

        public static string ProvideCS()
        {
            return  ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
        }
    }
}