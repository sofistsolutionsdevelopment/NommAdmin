using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BO
{
    public class ValidateUser
    {
        public DataTable getLoginDetails(string strUserName, string strUserPwd)
        {
            SqlCon SqlConnection = null;
            SqlCommand SqlCommand = null;
            SqlParameter SqlParameter = null;
            SqlDataAdapter SqlDataAdapter = null;
            DataTable dtUserDetails = new DataTable();
            try
            {
                SqlConnection = new SqlCon();

                if (SqlConnection.conn.State != ConnectionState.Open)
                    SqlConnection.conn.Open();

                SqlCommand = new SqlCommand("SPA_ValidateUser", SqlConnection.conn);
                SqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter = new SqlParameter("@UserName", SqlDbType.VarChar);
                SqlParameter.Value = strUserName;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@UserPwd", SqlDbType.VarChar);
                SqlParameter.Value = strUserPwd;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlDataAdapter = new SqlDataAdapter(SqlCommand);
                SqlDataAdapter.Fill(dtUserDetails);

                return dtUserDetails;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlConnection.conn.Close();
                SqlConnection.conn.Dispose();
                SqlConnection = null;
                //SqlParameter = null;
                SqlCommand = null;
            }
        }
    }
}
