using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BO
{
    public class UserMaster
    {
        public DataTable getBranchwiseLocations(int intBranchId)
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


                SqlCommand = new SqlCommand("SPA_GetBranchwiseLocations", SqlConnection.conn);
                SqlCommand.CommandType = CommandType.StoredProcedure;
   
                SqlParameter = new SqlParameter("@BranchId", SqlDbType.Int);
                SqlParameter.Value = intBranchId;
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
        public int InsertUpdateUserMasterDetails(int intUserKey, /*int intBranchId,*/ string strUserName, string strUserId, int intRoleId, string strUserEMail, string strUserContactNo, string strAddress, int intStatus, int intCreatedBy, int intModifiedBy, string strOperation)
        {
            SqlCon SqlConnection = null;
            SqlCommand SqlCommand = null;
            SqlParameter SqlParameter = null;
            try
            {
                SqlConnection = new SqlCon();

                if (SqlConnection.conn.State != ConnectionState.Open)
                    SqlConnection.conn.Open();


                SqlCommand = new SqlCommand("SPA_UserMaster_InsertUpdate", SqlConnection.conn);
                SqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter = new SqlParameter("@User_Key", SqlDbType.Int);
                SqlParameter.Value = intUserKey;
                SqlCommand.Parameters.Add(SqlParameter);

                //SqlParameter = new SqlParameter("@BranchId", SqlDbType.Int);
                //SqlParameter.Value = intBranchId;
                //SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@User_Name", SqlDbType.VarChar);
                SqlParameter.Value = strUserName;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@User_Id", SqlDbType.VarChar);
                SqlParameter.Value = strUserId;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@Role_Id", SqlDbType.Int);
                SqlParameter.Value = intRoleId;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@User_EMail", SqlDbType.VarChar);
                SqlParameter.Value = strUserEMail;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@User_ContactNo", SqlDbType.VarChar);
                SqlParameter.Value = strUserContactNo;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@Address", SqlDbType.VarChar);
                SqlParameter.Value = strAddress;
                SqlCommand.Parameters.Add(SqlParameter);


                SqlParameter = new SqlParameter("@Status", SqlDbType.Int);
                SqlParameter.Value = intStatus;
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

                SqlParameter = new SqlParameter("@Result", SqlDbType.Int) { Direction = ParameterDirection.Output };
                SqlParameter.Value = 0;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlCommand.ExecuteNonQuery();

                int ret = int.Parse(SqlCommand.Parameters["@Result"].Value.ToString());

                return ret;
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
        public bool insertUpdateUserLocation(int intUserKey, int intBranchLocationId, string strOperation)
        {
            SqlCon SqlConnection = null;
            SqlCommand SqlCommand = null;
            SqlParameter SqlParameter = null;
            try
            {
                SqlConnection = new SqlCon();

                if (SqlConnection.conn.State != ConnectionState.Open)
                    SqlConnection.conn.Open();


                SqlCommand = new SqlCommand("SPA_InsertUpdateUserLocationMaster", SqlConnection.conn);
                SqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter = new SqlParameter("@User_Key", SqlDbType.Int);
                SqlParameter.Value = intUserKey;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@BranchLocationId", SqlDbType.VarChar);
                SqlParameter.Value = intBranchLocationId;
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
        public DataTable getUserLocationDetails(int intUserKey, int intBranchLocationId, string strOperation)
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


                SqlCommand = new SqlCommand("SPA_InsertUpdateUserLocationMaster", SqlConnection.conn);
                SqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter = new SqlParameter("@User_Key", SqlDbType.Int);
                SqlParameter.Value = intUserKey;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@BranchLocationId", SqlDbType.VarChar);
                SqlParameter.Value = intBranchLocationId;
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
        public DataTable getUserDetails(int intUserKey, /*int intBranchId,*/ string strUserName, string strUserId, int intRoleId, string strUserEMail, string strUserContactNo, string strAddress, int IntStatus, int intCreatedBy, int intModifiedBy, string strOperation)
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


                SqlCommand = new SqlCommand("SPA_UserMaster_VS", SqlConnection.conn);
                SqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter = new SqlParameter("@User_Key", SqlDbType.Int);
                SqlParameter.Value = intUserKey;
                SqlCommand.Parameters.Add(SqlParameter);

                //SqlParameter = new SqlParameter("@BranchId", SqlDbType.Int);
                //SqlParameter.Value = intBranchId;
                //SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@User_Name", SqlDbType.VarChar);
                SqlParameter.Value = strUserName;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@User_Id", SqlDbType.VarChar);
                SqlParameter.Value = strUserId;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@Role_Id", SqlDbType.Int);
                SqlParameter.Value = intRoleId;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@User_EMail", SqlDbType.VarChar);
                SqlParameter.Value = strUserEMail;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@User_ContactNo", SqlDbType.VarChar);
                SqlParameter.Value = strUserContactNo;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@Address", SqlDbType.VarChar);
                SqlParameter.Value = strAddress;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@Status", SqlDbType.Int);
                SqlParameter.Value = IntStatus;
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
        public bool insertUpdateUserBranch(int intUserKey, int intBranchId, string strOperation)
        {
            SqlCon SqlConnection = null;
            SqlCommand SqlCommand = null;
            SqlParameter SqlParameter = null;
            try
            {
                SqlConnection = new SqlCon();

                if (SqlConnection.conn.State != ConnectionState.Open)
                    SqlConnection.conn.Open();

                SqlCommand = new SqlCommand("SPA_InsertUpdateUserBranchMaster", SqlConnection.conn);
                SqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter = new SqlParameter("@User_Key", SqlDbType.Int);
                SqlParameter.Value = intUserKey;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@BranchId", SqlDbType.VarChar);
                SqlParameter.Value = intBranchId;
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
        public DataTable getUserBranchDetails(int intUserKey, int intBranchId, string strOperation)
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

                SqlCommand = new SqlCommand("SPA_InsertUpdateUserBranchMaster", SqlConnection.conn);
                SqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter = new SqlParameter("@User_Key", SqlDbType.Int);
                SqlParameter.Value = intUserKey;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@BranchId", SqlDbType.VarChar);
                SqlParameter.Value = intBranchId;
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
    }
}
