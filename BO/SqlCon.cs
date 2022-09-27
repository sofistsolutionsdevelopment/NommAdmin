using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace BO
{
    class SqlCon
    {
        private String connString = "";

        public String ConnString
        {
            get { return connString; }
        }

        public SqlConnection conn;
        public SqlCon()
        {
            string constr = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            connString = constr;
            conn = new SqlConnection(connString);
            conn.Open();
        }
    }
}
