using BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Net.Mail;

namespace NommAdmin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        string strUserId;
        int intUserKey;
        DataTable dtUserDetails = new DataTable();
        MasterData objMasterData = new MasterData();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["UserKey"] == null)
                {
                    Session.Abandon();
                    Response.Redirect("~/Login.aspx", true);
                }
                else
                {
                    strUserId = Session["UserId"].ToString();
                    dtUserDetails = (DataTable)Session["UserDetails"];
                    intUserKey = Convert.ToInt32(dtUserDetails.Rows[0]["User_Key"]);
                }

                if (!IsPostBack)
                {
                    getDashCount();
                }
            }
            catch (Exception ex)
            {
                MsgBox(ex.Message);
            }
        }

        private void MsgBox(string strMessage)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('" + strMessage + "');", true);
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "swal('" + strMessage + "','Oh no!!','error');", true);
        }


        private void getDashCount()
        {
            try
            {

                DataTable dtGetDashDetails = objMasterData.getMasterData("DashCnt");

                if (dtGetDashDetails.Rows.Count > 0)
                {
                    lbltotcat.Text = dtGetDashDetails.Rows[0]["CatCount"].ToString();
                    lbltotChf.Text = dtGetDashDetails.Rows[0]["ChefCount"].ToString();
                    lbltotFaq.Text = dtGetDashDetails.Rows[0]["faqCount"].ToString();
                    lbltotSer.Text = dtGetDashDetails.Rows[0]["SerCount"].ToString();
                }
            }
            catch (Exception ex)
            {
                MsgBox(ex.Message);
            }
        }
    }
}