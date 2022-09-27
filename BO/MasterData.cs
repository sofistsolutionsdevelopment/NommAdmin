using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BO
{
    public class MasterData
    {
        public DataTable getMasterData(string strOperation)
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
                //SqlConnection conn = new SqlConnection(@"Server=ADMIN\SQLEXPRESS;Database=PANKAJ_FEES;Trusted_Connection=Yes;");

                SqlCommand = new SqlCommand("SPA_GetMasterData", SqlConnection.conn);
                SqlCommand.CommandType = CommandType.StoredProcedure;


                SqlParameter = new SqlParameter("@Operation", SqlDbType.VarChar);
                SqlParameter.Value = strOperation;
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

        public DataTable getMasterDataByID(int intID, string strName, string strOperation)
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
                //SqlConnection conn = new SqlConnection(@"Server=ADMIN\SQLEXPRESS;Database=PANKAJ_FEES;Trusted_Connection=Yes;");

                SqlCommand = new SqlCommand("SPA_GetMasterDataByID", SqlConnection.conn);
                SqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter = new SqlParameter("@ID", SqlDbType.Int);
                SqlParameter.Value = intID;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@Name", SqlDbType.VarChar);
                SqlParameter.Value = strName;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@Operation", SqlDbType.VarChar);
                SqlParameter.Value = strOperation;
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

        public DataTable getSearchDataByDate(string strFDate, string strTDate, string strOperation)
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
                //SqlConnection conn = new SqlConnection(@"Server=ADMIN\SQLEXPRESS;Database=PANKAJ_FEES;Trusted_Connection=Yes;");

                SqlCommand = new SqlCommand("SPA_GetSearchDataByDate", SqlConnection.conn);
                SqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter = new SqlParameter("@FromDate", SqlDbType.VarChar);
                SqlParameter.Value = strFDate;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@ToDate", SqlDbType.VarChar);
                SqlParameter.Value = strTDate;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@Operation", SqlDbType.VarChar);
                SqlParameter.Value = strOperation;
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

        public int InsertCategoryData(int intcatid,string strCatname,int status, string strOperation)
        {
            SqlCon SqlConnection = null;
            SqlCommand SqlCommand = null;
            SqlParameter SqlParameter = null;
            try
            {
                SqlConnection = new SqlCon();

                if (SqlConnection.conn.State != ConnectionState.Open)
                    SqlConnection.conn.Open();


                SqlCommand = new SqlCommand("SPA_CategoryData_IUV", SqlConnection.conn);
                SqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter = new SqlParameter("@CatId", SqlDbType.Int);
                SqlParameter.Value = intcatid;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@Category", SqlDbType.VarChar);
                SqlParameter.Value = strCatname;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@Status", SqlDbType.Int);
                SqlParameter.Value = status;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@Operation", SqlDbType.VarChar);
                SqlParameter.Value = strOperation;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@Result", SqlDbType.Int) { Direction = ParameterDirection.Output };
                SqlParameter.Value = 0;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlCommand.ExecuteNonQuery();

                int ret = int.Parse(SqlCommand.Parameters["@Result"].Value.ToString());
                //if (SqlCommand.ExecuteNonQuery() != -1)
                //    return true;


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

        public int InsertServiecData(int intsrvid, string strsrvname, int status, string strOperation)
        {
            SqlCon SqlConnection = null;
            SqlCommand SqlCommand = null;
            SqlParameter SqlParameter = null;
            try
            {
                SqlConnection = new SqlCon();

                if (SqlConnection.conn.State != ConnectionState.Open)
                    SqlConnection.conn.Open();


                SqlCommand = new SqlCommand("SPA_ServiceData_IU", SqlConnection.conn);
                SqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter = new SqlParameter("@SId", SqlDbType.Int);
                SqlParameter.Value = intsrvid;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@Service", SqlDbType.VarChar);
                SqlParameter.Value = strsrvname;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@Status", SqlDbType.Int);
                SqlParameter.Value = status;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@Operation", SqlDbType.VarChar);
                SqlParameter.Value = strOperation;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@Result", SqlDbType.Int) { Direction = ParameterDirection.Output };
                SqlParameter.Value = 0;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlCommand.ExecuteNonQuery();

                int ret = int.Parse(SqlCommand.Parameters["@Result"].Value.ToString());
                //if (SqlCommand.ExecuteNonQuery() != -1)
                //    return true;


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

        public int InsertFAQData(int intid, string strQues, string strANS, int status, string strOperation)
        {
            SqlCon SqlConnection = null;
            SqlCommand SqlCommand = null;
            SqlParameter SqlParameter = null;
            try
            {
                SqlConnection = new SqlCon();

                if (SqlConnection.conn.State != ConnectionState.Open)
                    SqlConnection.conn.Open();


                SqlCommand = new SqlCommand("SPA_FAQData_IU", SqlConnection.conn);
                SqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter = new SqlParameter("@FaqID", SqlDbType.Int);
                SqlParameter.Value = intid;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@Que", SqlDbType.VarChar);
                SqlParameter.Value = strQues;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@Ans", SqlDbType.VarChar);
                SqlParameter.Value = strANS;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@Status", SqlDbType.Int);
                SqlParameter.Value = status;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@Operation", SqlDbType.VarChar);
                SqlParameter.Value = strOperation;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@Result", SqlDbType.Int) { Direction = ParameterDirection.Output };
                SqlParameter.Value = 0;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlCommand.ExecuteNonQuery();

                int ret = int.Parse(SqlCommand.Parameters["@Result"].Value.ToString());
                //if (SqlCommand.ExecuteNonQuery() != -1)
                //    return true;


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

        public bool UploadCarosalImg(int CrId,string strImage,int intstatus)
        {
            SqlCon SqlConnection = null;
            SqlCommand SqlCommand = null;
            SqlParameter SqlParameter = null;
            try
            {
                SqlConnection = new SqlCon();

                if (SqlConnection.conn.State != ConnectionState.Open)
                    SqlConnection.conn.Open();

                SqlCommand = new SqlCommand("SPA_CarouselUpload", SqlConnection.conn);
                SqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter = new SqlParameter("@CarouselID", SqlDbType.Int);
                SqlParameter.Value = CrId;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@Image", SqlDbType.VarChar);
                SqlParameter.Value = strImage;
                SqlCommand.Parameters.Add(SqlParameter);

                SqlParameter = new SqlParameter("@Status", SqlDbType.Int);
                SqlParameter.Value = intstatus;
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

        public bool DeleteMasterDataByID(int Id, string strOperation)
        {
            SqlCon SqlConnection = null;
            SqlCommand SqlCommand = null;
            SqlParameter SqlParameter = null;
            try
            {
                SqlConnection = new SqlCon();

                if (SqlConnection.conn.State != ConnectionState.Open)
                    SqlConnection.conn.Open();

                SqlCommand = new SqlCommand("SPA_DeleteMasterDataByID", SqlConnection.conn);
                SqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter = new SqlParameter("@ID", SqlDbType.Int);
                SqlParameter.Value = Id;
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
