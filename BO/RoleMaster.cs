using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BO
{
    public class RoleMaster
    {
        public DataTable getRoleDetails(int intRoleId, string strRoleDescription, char chrStatus, int intCreatedBy, int intModifiedBy, string strOperation)
        {
            SqlCon SqlConnection = null;
            SqlCommand SqlCommand = null;
            SqlParameter SqlParameter = null;
            SqlDataAdapter SqlDataAdapter = null;
            DataTable dtGetUserDetails = new DataTable();
            try
            {
                SqlConnection = new SqlCon();

                if (SqlConnection.conn.State != ConnectionState.Open)
                    SqlConnection.conn.Open();


                SqlCommand = new SqlCommand("SPA_RoleMaster_VIU", SqlConnection.conn);
                SqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter = new SqlParameter("@RoleId", SqlDbType.Int);
                SqlParameter.Value = intRoleId;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@RoleDescription", SqlDbType.VarChar);
                SqlParameter.Value = strRoleDescription;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@Status", SqlDbType.Char);
                SqlParameter.Value = chrStatus;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@CreatedBy", SqlDbType.Int);
                SqlParameter.Value = intCreatedBy;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@ModifiedBy", SqlDbType.Int);
                SqlParameter.Value = intModifiedBy;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@Operation", SqlDbType.VarChar);
                SqlParameter.Value = strOperation;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlDataAdapter = new SqlDataAdapter(SqlCommand);
                SqlDataAdapter.Fill(dtGetUserDetails);

                return dtGetUserDetails;

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

        public bool insertRoleMaster(int intRoleId, string strRoleDescription, char chrStatus, int intCreatedBy, int intModifiedBy, string strOperation)
        {
            SqlCon SqlConnection = null;
            SqlCommand SqlCommand = null;
            SqlParameter SqlParameter = null;
            try
            {
                SqlConnection = new SqlCon();

                if (SqlConnection.conn.State != ConnectionState.Open)
                    SqlConnection.conn.Open();


                SqlCommand = new SqlCommand("SPA_RoleMaster_VIU", SqlConnection.conn);
                SqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter = new SqlParameter("@RoleId", SqlDbType.Int);
                SqlParameter.Value = intRoleId;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@RoleDescription", SqlDbType.VarChar);
                SqlParameter.Value = strRoleDescription;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@Status", SqlDbType.Char);
                SqlParameter.Value = chrStatus;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@CreatedBy", SqlDbType.Int);
                SqlParameter.Value = intCreatedBy;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@ModifiedBy", SqlDbType.Int);
                SqlParameter.Value = intModifiedBy;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@Operation", SqlDbType.VarChar);
                SqlParameter.Value = strOperation;
                SqlCommand.Parameters.Add(SqlParameter);

                if (SqlCommand.ExecuteNonQuery() != -1)
                    return true;


                return false;
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
                SqlParameter = null;
                SqlCommand = null;
            }
        }
    }
}
