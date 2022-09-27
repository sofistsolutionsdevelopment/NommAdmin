using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Web;


namespace BO
{
    public class MenuRights
    {
        public DataTable getAccessRights(int intRoleId)
        {
            SqlCon SqlConnection = null;
            SqlCommand SqlCommand = null;
            SqlParameter SqlParameter = null;
            SqlDataAdapter SqlDataAdapter = null;
            DataTable dtGetGraph = new DataTable();
            try
            {
                SqlConnection = new SqlCon();

                if (SqlConnection.conn.State != ConnectionState.Open)
                    SqlConnection.conn.Open();

                SqlCommand = new SqlCommand("SPA_GetRoleMenu", SqlConnection.conn);
                SqlCommand.CommandType = CommandType.StoredProcedure;


                SqlParameter = new SqlParameter("@RoleId", SqlDbType.Int);
                SqlParameter.Value = intRoleId;
                SqlCommand.Parameters.Add(SqlParameter);


                SqlDataAdapter = new SqlDataAdapter(SqlCommand);
                SqlDataAdapter.Fill(dtGetGraph);

                return dtGetGraph;

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

        public bool insertRoleMenu(int intRoleId, int intMenuId, char chrFlag, int intCreatedBy, string strOperation)
        {
            SqlCon SqlConnection = null;
            SqlCommand SqlCommand = null;
            SqlParameter SqlParameter = null;
            try
            {
                SqlConnection = new SqlCon();

                if (SqlConnection.conn.State != ConnectionState.Open)
                    SqlConnection.conn.Open();


                SqlCommand = new SqlCommand("SPA_RoleMenu_VIU", SqlConnection.conn);
                SqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter = new SqlParameter("@RoleId", SqlDbType.Int);
                SqlParameter.Value = intRoleId;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@MenuId", SqlDbType.Int);
                SqlParameter.Value = intMenuId;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@Flag", SqlDbType.Char);
                SqlParameter.Value = chrFlag;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@CREATEDBY", SqlDbType.Int);
                SqlParameter.Value = intCreatedBy;
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

        public DataSet getMenus(int intUserKey)
        {
            SqlCon SqlConnection = null;
            SqlCommand SqlCommand = null;
            SqlParameter SqlParameter = null;
            SqlDataAdapter SqlDataAdapter = null;
            DataSet dtGetMenus = new DataSet();
            try
            {
                SqlConnection = new SqlCon();

                if (SqlConnection.conn.State != ConnectionState.Open)
                    SqlConnection.conn.Open();
                //SqlConnection conn = new SqlConnection(@"Server=ADMIN\SQLEXPRESS;Database=PANKAJ_FEES;Trusted_Connection=Yes;");

                SqlCommand = new SqlCommand("SPA_GETMenus", SqlConnection.conn);
                SqlCommand.CommandType = CommandType.StoredProcedure;


                SqlParameter = new SqlParameter("@UserKey", SqlDbType.Int);
                SqlParameter.Value = intUserKey;
                SqlCommand.Parameters.Add(SqlParameter);


                SqlDataAdapter = new SqlDataAdapter(SqlCommand);
                SqlDataAdapter.Fill(dtGetMenus);

                return dtGetMenus;

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

        public DataTable getGetMenusHTML(int intUserKey)
        {
            SqlCon SqlConnection = null;
            SqlCommand SqlCommand = null;
            SqlParameter SqlParameter = null;
            SqlDataAdapter SqlDataAdapter = null;
            DataTable dtGetMenus = new DataTable();
            try
            {
                SqlConnection = new SqlCon();

                if (SqlConnection.conn.State != ConnectionState.Open)
                    SqlConnection.conn.Open();
                //SqlConnection conn = new SqlConnection(@"Server=ADMIN\SQLEXPRESS;Database=PANKAJ_FEES;Trusted_Connection=Yes;");

                SqlCommand = new SqlCommand("SPA_GETMenusHTML", SqlConnection.conn);
                SqlCommand.CommandType = CommandType.StoredProcedure;


                SqlParameter = new SqlParameter("@UserKey", SqlDbType.Int);
                SqlParameter.Value = intUserKey;
                SqlCommand.Parameters.Add(SqlParameter);


                SqlDataAdapter = new SqlDataAdapter(SqlCommand);
                SqlDataAdapter.Fill(dtGetMenus);

                return dtGetMenus;

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

        #region "Get Root URL"
        public string GetRootURL()
        {
            string strRootURL = "";
            if (HttpContext.Current.Request != null)
            {
                if (HttpContext.Current.Request.ServerVariables["HTTPS"] != "" && HttpContext.Current.Request.ServerVariables["HTTPS"].ToLower().IndexOf("on") >= 0)
                    strRootURL = "https://";
                else
                    strRootURL = "http://";

                string strServerPort = "";

                if (HttpContext.Current.Request.ServerVariables["SERVER_PORT"] != "")
                {
                    strServerPort = ":" + HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
                }
                //+"/FHHL/";
                strRootURL += HttpContext.Current.Request.ServerVariables["SERVER_NAME"] + strServerPort;
            }
            return strRootURL;
        }
        #endregion
    }
}
