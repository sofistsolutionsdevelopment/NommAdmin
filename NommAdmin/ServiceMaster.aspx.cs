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
    public partial class ServiceMaster : System.Web.UI.Page
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
                    getService();
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

        private void getService()
        {
            try
            {

                DataTable dtService = objMasterData.getMasterData("SRV");
                if (dtService.Rows.Count > 0)
                {
                    gvServDetail.DataSource = dtService;
                    gvServDetail.DataBind();
                }
            }
            catch (Exception ex)
            {
                MsgBox(ex.Message);
            }
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSrchServ.Text != "")
                {
                    DataTable dtService = objMasterData.getMasterDataByID(0, txtSrchServ.Text, "SRV");
                    if (dtService.Rows.Count > 0)
                    {
                        gvServDetail.DataSource = dtService;
                        gvServDetail.DataBind();
                    }
                }
                else
                {
                    MsgBox("Please Enter Search Parameter...");
                }
            }
            catch (Exception ex)
            {
                MsgBox(ex.Message);
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            divFields.Visible = true;
            divsearch.Visible = false;
        }

        protected void gvServDetail_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edit")
                {
                    divFields.Visible = true;
                    divsearch.Visible = false;

                    int index = Convert.ToInt32(e.CommandArgument);
                    hdnsrv.Value = ((Label)gvServDetail.Rows[index].FindControl("lblID")).Text;
                    txtsrv.Text = ((Label)gvServDetail.Rows[index].FindControl("lblsrvname")).Text;
                    rdbStatus.SelectedValue = ((Label)gvServDetail.Rows[index].FindControl("lblstID")).Text;
                }

                if (e.CommandName == "Del")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    hdnsrv.Value = ((Label)gvServDetail.Rows[index].FindControl("lblID")).Text;
                    txtsrv.Text = ((Label)gvServDetail.Rows[index].FindControl("lblsrvname")).Text;

                    bool SerDel = false;

                    SerDel = objMasterData.DeleteMasterDataByID(Convert.ToInt32(hdnsrv.Value), "SER");

                    if (SerDel)
                    {
                        MsgBox(txtsrv.Text + " Deleted");

                        getService();
                    }

                }
            }
            catch (Exception ex)
            {
                MsgBox(ex.Message);
            }
        }

        protected void gvServDetail_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void btnSaveService_Click(object sender, EventArgs e)
        {

            try
            {
                int IntCat = 0;

                if (hdnsrv.Value == "" || hdnsrv.Value == "0")
                {
                    IntCat = objMasterData.InsertServiecData(0, txtsrv.Text, Convert.ToInt32(rdbStatus.SelectedValue), "I");

                    if (IntCat > 0)
                    {
                        MsgBox("Service Data Saved Successfully.");
                        divFields.Visible = false;
                        divsearch.Visible = true;
                    }
                }
                else
                {
                    int inthdnvalue = Convert.ToInt32(hdnsrv.Value);

                    IntCat = objMasterData.InsertServiecData(inthdnvalue, txtsrv.Text, Convert.ToInt32(rdbStatus.SelectedValue), "U");

                    if (IntCat > 0)
                    {
                        MsgBox("Service Data Modified Successfully.");
                        divFields.Visible = false;
                        divsearch.Visible = true;
                    }
                }

                getService();
                resetpage();
            }
            catch (Exception ex)
            {
                MsgBox(ex.Message);
            }

        }

        private void resetpage()
        {
            txtsrv.Text = "";
        }

        protected void btnclose_Click(object sender, EventArgs e)
        {
            divFields.Visible = false;
            divsearch.Visible = true;
        }
    }
}