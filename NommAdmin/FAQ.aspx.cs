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
    public partial class FAQ : System.Web.UI.Page
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
                    getFAQ();
                }
            }
            catch (Exception ex)
            {
                MsgBox(ex.Message);
            }
        }

        private void MsgBox(string strMessage)
        {
           // ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('" + strMessage + "');", true);
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "swal('" + strMessage + "','Oh no!!','error');", true);
        }

        private void getFAQ()
        {
            try
            {

                DataTable dtFaq = objMasterData.getMasterData("FAQ");
                if (dtFaq.Rows.Count > 0)
                {
                    gvFAQDetail.DataSource = dtFaq;
                    gvFAQDetail.DataBind();
                }
            }
            catch (Exception ex)
            {
                MsgBox(ex.Message);
            }
        }


        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            txtQue.Text = "";
            txtAns.Text = "";
            divFields.Visible = true;
            divsearch.Visible = false;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFaqServ.Text != "")
                {
                    DataTable dtFAQ = objMasterData.getMasterDataByID(0, txtFaqServ.Text, "FAQ");
                    if (dtFAQ.Rows.Count > 0)
                    {
                        gvFAQDetail.DataSource = dtFAQ;
                        gvFAQDetail.DataBind();
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

        protected void gvFAQDetail_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edit")
                {
                    divFields.Visible = true;
                    divsearch.Visible = false;

                    int index = Convert.ToInt32(e.CommandArgument);
                    hdnFQ.Value = ((Label)gvFAQDetail.Rows[index].FindControl("lblID")).Text;
                    txtQue.Text = ((Label)gvFAQDetail.Rows[index].FindControl("lblFAQname")).Text;
                    txtAns.Text = ((Label)gvFAQDetail.Rows[index].FindControl("lblFAQans")).Text;
                    rdbStatus.SelectedValue = ((Label)gvFAQDetail.Rows[index].FindControl("lblstID")).Text;
                }

                if (e.CommandName == "Del")
                {
                    bool FDel = false;
                    int index = Convert.ToInt32(e.CommandArgument);
                    hdnFQ.Value = ((Label)gvFAQDetail.Rows[index].FindControl("lblID")).Text;
                    txtQue.Text = ((Label)gvFAQDetail.Rows[index].FindControl("lblFAQname")).Text;


                    //MsgBox(id.ToString());
                    FDel = objMasterData.DeleteMasterDataByID(Convert.ToInt32(hdnFQ.Value), "FAQ");

                    if (FDel)
                    {
                        MsgBox("Question No. "+ hdnFQ.Value + " Deleted");

                        getFAQ();
                    }

                }
            }
            catch (Exception ex)
            {
                MsgBox(ex.Message);
            }
        }

        protected void gvFAQDetail_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void btnSaveFAQ_Click(object sender, EventArgs e)
        {

            try
            {
                int IntCat = 0;

                if (hdnFQ.Value == "" || hdnFQ.Value == "0")
                {
                    IntCat = objMasterData.InsertFAQData(0, txtQue.Text,txtAns.Text, Convert.ToInt32(rdbStatus.SelectedValue), "I");

                    if (IntCat > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "swal('FAQ Data Saved Successfully.','','success');", true);
                        //MsgBox("FAQ Data Saved Successfully.");
                        divFields.Visible = false;
                        divsearch.Visible = true;
                    }
                }
                else
                {
                    int inthdnvalue = Convert.ToInt32(hdnFQ.Value);

                    IntCat = objMasterData.InsertFAQData(inthdnvalue, txtQue.Text, txtAns.Text, Convert.ToInt32(rdbStatus.SelectedValue), "U");

                    if (IntCat > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "swal('FAQ Data Modified Successfully.','','success');", true);
                        MsgBox("FAQ Data Modified Successfully.");
                        divFields.Visible = false;
                        divsearch.Visible = true;
                    }
                }

                getFAQ();
                resetpage();
            }
            catch (Exception ex)
            {
                MsgBox(ex.Message);
            }

        }

        private void resetpage()
        {
            txtQue.Text = "";
            txtAns.Text = "";
            hdnFQ.Value = "0";
        }


        protected void btnclose_Click(object sender, EventArgs e)
        {
            divFields.Visible = false;
            divsearch.Visible = true;
        }
    }
}