using BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NommAdmin
{
    public partial class NewRole : System.Web.UI.Page
    {
        string strUserId;
        int intUserKey;
        DataTable dtUserDetails = new DataTable();
        RoleMaster objRoleMaster = new RoleMaster();

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
                    divFields.Visible = false;
                    divsearch.Visible = true;
                    getRoleDetails();
                }
            }
            catch (Exception ex)
            {
                //MsgBox(ex.Message);
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "swal('"+ ex.Message + "','Oh no!!','error');", true);
            }
        }

        private void getRoleDetails()
        {
            try
            {
                DataTable dtGetRoleDetails = objRoleMaster.getRoleDetails(0, "", 'A', 0, 0, "V");

                if (dtGetRoleDetails.Rows.Count > 0)
                {
                    gvRoleDetails.DataSource = dtGetRoleDetails;
                    gvRoleDetails.DataBind();
                }
                else
                {
                    gvRoleDetails.DataSource = null; ;
                    gvRoleDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                MsgBox(ex.Message);
            }
        }

        private void MsgBox(string strMessage)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('" + strMessage + "');", true);
        }

        private void resetPage()
        {
            try
            {
                hdnRoleId.Value = "";
                txtRoleName.Text = "";
                txtSrchRole.Text = "";
                txtRoleName.Enabled = true;
                rdbStatus.SelectedValue = "A";
            }
            catch (Exception ex)
            {
                MsgBox(ex.Message);
            }
        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtGetUserDetails = objRoleMaster.getRoleDetails(0, txtRoleName.Text, 'A', 0, 0, "C");
                if (hdnRoleId.Value == "" || hdnRoleId.Value == "0")
                {
                    if (dtGetUserDetails.Rows[0][0].ToString() == "0")
                    {

                        string strOperation;
                        int intRoleId;
                        strOperation = "I";
                        intRoleId = 0;

                        char charStatus;
                        if (rdbStatus.SelectedValue == "A")
                        {
                            charStatus = 'A';
                        }
                        else
                        {
                            charStatus = 'D';
                        }
                        bool save = false;
                        save = objRoleMaster.insertRoleMaster(intRoleId, txtRoleName.Text, charStatus, intUserKey, 0, strOperation);
                        if (save)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "swal('Role Details Saved Successfully.','','success');", true);
                            //divFields.Visible = false;
                            //divsearch.Visible = true;
                            getRoleDetails();
                            resetPage();
                        }
                        //divFields.Visible = false;
                        //divsearch.Visible = true;
                    }
                    else
                    {
                        //MsgBox("Role Already Exists in the System.");
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "swal('Role Already Exists in the System.','','warning');", true);
                        //divFields.Visible = false;
                        //divsearch.Visible = true;
                        getRoleDetails();
                        resetPage();
                    }
                }
                else if (hdnRoleId.Value != "" && hdnRoleId.Value != "0")
                {
                    string strOperation;
                    int intRoleId;
                    intRoleId = Convert.ToInt32(hdnRoleId.Value);
                    strOperation = "U";
                    char charStatus;
                    if (rdbStatus.SelectedValue == "A")
                    {
                        charStatus = 'A';
                    }
                    else
                    {
                        charStatus = 'D';
                    }
                    bool modify = false;
                    modify = objRoleMaster.insertRoleMaster(intRoleId, txtRoleName.Text, charStatus, 0, intUserKey, strOperation);
                    if (modify)
                    {
                        //MsgBox("Role Details Modified Successfully.");
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "swal('Role Details Modified Successfully.','','success');", true);
                        //divFields.Visible = false;
                        //divsearch.Visible = true;
                        getRoleDetails();
                        resetPage();

                    }
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "swal('" + ex.Message + "','Oh no!!','error');", true);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            divsearch.Visible = true;
            divFields.Visible = false;
            txtSrchRole.Text = "";
            resetPage();
        }

        protected void btnAddRole_Click(object sender, EventArgs e)
        {
            divFields.Visible = true;
            divsearch.Visible = false;
            btnSave.Text = "Save";
            resetPage();
        }

        protected void gvRoleDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edit")
                {
                    divFields.Visible = true;
                    divsearch.Visible = false;
                    int index = Convert.ToInt32(e.CommandArgument);
                    hdnRoleId.Value = ((Label)gvRoleDetails.Rows[index].FindControl("lblRoleId")).Text;
                    txtRoleName.Text = ((Label)gvRoleDetails.Rows[index].FindControl("lblRoleName")).Text;
                    //txtRoleName.Enabled = false;
                    rdbStatus.SelectedValue = ((Label)gvRoleDetails.Rows[index].FindControl("lblRoleStatus")).Text;
                    btnSave.Text = "Modify";

                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "swal('" + ex.Message + "','Oh no!!','error');", true);
            }
        }

        protected void gvRoleDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                RoleMaster objRoleMaster = new RoleMaster();
                DataTable dtGetRoleSearch = objRoleMaster.getRoleDetails(0, txtSrchRole.Text, 'A', 0, 0, "S");
                if (dtGetRoleSearch.Rows.Count > 0)
                {
                    gvRoleDetails.DataSource = dtGetRoleSearch;
                    gvRoleDetails.DataBind();
                }
                else
                {
                    getRoleDetails();
                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "swal('" + ex.Message + "','Oh no!!','error');", true);
            }
        }

        protected void gvRoleDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvRoleDetails.PageIndex = e.NewPageIndex;
                getRoleDetails();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "swal('" + ex.Message + "','Oh no!!','error');", true);
            }

        }

    }
}