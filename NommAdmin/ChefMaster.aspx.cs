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
    public partial class ChefMaster : System.Web.UI.Page
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
                    getChefDetails();
                    getCityList();
                    getCategoryList();
                }
            }
            catch (Exception ex)
            {
                MsgBox(ex.Message);
            }
        }

        private void MsgBox(string strMessage)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "swal('" + strMessage + "','Oh no!!','error');", true);
        }

        private void getCategoryList()
        {
            try
            {
                DataTable dtCategory = objMasterData.getMasterData("CAT");
                if (dtCategory.Rows.Count > 0)
                {
                    ddlCat.DataTextField = "Category";
                    ddlCat.DataValueField = "Cat_Id";
                    ddlCat.DataSource = dtCategory;
                    ddlCat.DataBind();

                    ddlservCat.DataTextField = "Category";
                    ddlservCat.DataValueField = "Cat_Id";
                    ddlservCat.DataSource = dtCategory;
                    ddlservCat.DataBind();

                }
            }
            catch (Exception ex)
            {
                MsgBox(ex.Message);
            }
        }

        private void getCityList()
        {
            try
            {
                DataTable dtCity = objMasterData.getMasterData("cty");
                if (dtCity.Rows.Count > 0)
                {
                    ddlcity.DataTextField = "City_Name";
                    ddlcity.DataValueField = "City_Id";
                    ddlcity.DataSource = dtCity;
                    ddlcity.DataBind();
                }
            }
            catch (Exception ex)
            {
                MsgBox(ex.Message);
            }
        }

        private void getChefDetails()
        {
            try
            {

                DataTable dtChef = objMasterData.getMasterData("CHF");
                if (dtChef.Rows.Count > 0)
                {
                    gvChefDetail.DataSource = dtChef;
                    gvChefDetail.DataBind();
                }
            }
            catch (Exception ex)
            {
                MsgBox(ex.Message);
            }
        }

        protected void btnclose_Click(object sender, EventArgs e)
        {
            divFields.Visible = false;
            divsearch.Visible = true;
        }

        protected void gvChefDetail_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "View")
                {
                    divFields.Visible = true;
                    divsearch.Visible = false;

                    int index = Convert.ToInt32(e.CommandArgument);
                    hdnchf.Value = ((Label)gvChefDetail.Rows[index].FindControl("lblChefID")).Text;
                    txtFname.Text = ((Label)gvChefDetail.Rows[index].FindControl("lblCheffname")).Text;
                    txtLname.Text = ((Label)gvChefDetail.Rows[index].FindControl("lblCheflname")).Text;
                    txtPhn.Text = ((Label)gvChefDetail.Rows[index].FindControl("lblChefPhno")).Text;
                    txtEmail.Text = ((Label)gvChefDetail.Rows[index].FindControl("lblChefEmail")).Text;
                    txtStorename.Text = ((Label)gvChefDetail.Rows[index].FindControl("lblStoreName")).Text;
                    txtcat.Text = ((Label)gvChefDetail.Rows[index].FindControl("lblcatID")).Text;
                    ddlCat.SelectedValue = ((Label)gvChefDetail.Rows[index].FindControl("lblcatID")).Text;
                    txtServcat.Text = ((Label)gvChefDetail.Rows[index].FindControl("lblServCatID")).Text;
                    ddlservCat.SelectedValue = ((Label)gvChefDetail.Rows[index].FindControl("lblServCatID")).Text;
                    txtaddr.Text = ((Label)gvChefDetail.Rows[index].FindControl("lbladdr")).Text;
                    txtcity.Text = ((Label)gvChefDetail.Rows[index].FindControl("lblcityID")).Text;
                    ddlcity.SelectedValue = ((Label)gvChefDetail.Rows[index].FindControl("lblcityID")).Text;
                    // txtState.Text = ((Label)gvChefDetail.Rows[index].FindControl("lblFAQname")).Text;
                    txtPincode.Text = ((Label)gvChefDetail.Rows[index].FindControl("lblpincode")).Text;
                    txtFSSAINo.Text = ((Label)gvChefDetail.Rows[index].FindControl("lblFSSINo")).Text;
                    txtAadharNo.Text = ((Label)gvChefDetail.Rows[index].FindControl("lblAdhrNo")).Text;
                   rdbStatus.SelectedValue = ((Label)gvChefDetail.Rows[index].FindControl("lblstID")).Text;
                }
            }
            catch (Exception ex)
            {
                MsgBox(ex.Message);
            }
        }

        protected void gvChefDetail_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFromDate.Text != "" || txtToDate.Text != "")
                {
                    DataTable dtChef = objMasterData.getSearchDataByDate(txtFromDate.Text, txtToDate.Text, "CHF");

                    if (dtChef.Rows.Count > 0)
                    {
                        gvChefDetail.DataSource = dtChef;
                        gvChefDetail.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox(ex.Message);
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            int IntCat = 0;

            int inthdnvalue = Convert.ToInt32(hdnchf.Value);

            IntCat = objMasterData.InsertCategoryData(inthdnvalue, "", Convert.ToInt32(rdbStatus.SelectedValue), "ChSt");

            if (IntCat > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "swal('Chef Data Modified Successfully.','','success');", true);
                // MsgBox("Category Data Modified Successfully.");
            }
        }
    }
}