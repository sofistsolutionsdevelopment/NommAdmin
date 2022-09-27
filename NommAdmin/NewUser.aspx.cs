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
    public partial class NewUser : System.Web.UI.Page
    {
        string strUserId;
        int intUserKey;
        DataTable dtUserDetails = new DataTable();
        UserMaster objUserMaster = new UserMaster();

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
                    getUserDetails();
                    //getBranch(); 
                   // getBranch1();
                    getRole();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "swal('" + ex.Message + "','Oh no!!','error');", true);
            }
        }

        private void resetPage()
        {
            try
            {
                hdnUserId.Value = "";
                txtUserName.Text = "";
                txtUserId.Enabled = true;
                txtUserId.Text = "";
                txtEmailId.Text = "";
                ddlRole.SelectedValue = "-1";
                txtSrchUser.Text = "";
                rdbStatus.SelectedValue = "A";
                txtContactNo.Text = "";
                txtAddress.Text = "";
                //ddlBranchName.SelectedValue = "-1";
                //ddlReportingTo.SelectedValue = "-1";
                //chkLocations.Items.Clear();
                //chkBranch.Items.Clear();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "swal('" + ex.Message + "','Oh no!!','error');", true);
            }
        }

        private void getRole()
        {
            try
            {
                MasterData getMasterData = new MasterData();
                DataTable dtRole = getMasterData.getMasterData("R");
                if (dtRole.Rows.Count > 0)
                {
                    ddlRole.DataTextField = "RoleDescription";
                    ddlRole.DataValueField = "RoleId";
                    ddlRole.DataSource = dtRole;
                    ddlRole.DataBind();
                }
                else
                {
                    ddlRole.DataSource = null;
                    ddlRole.DataBind();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "swal('" + ex.Message + "','Oh no!!','error');", true);
            }
        }
        private void getUserDetails()
        {
            try
            {
                UserMaster objUserMaster = new UserMaster();
                DataTable dtGetUserDetails = objUserMaster.getUserDetails(0, "", "", 0, "", "", "", 1, 0, 0, "V");

                if (dtGetUserDetails.Rows.Count > 0)
                {
                    gvUserDetails.DataSource = dtGetUserDetails;
                    gvUserDetails.DataBind();
                }
                else
                {
                    gvUserDetails.DataSource = null; ;
                    gvUserDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "swal('" + ex.Message + "','Oh no!!','error');", true);
            }
        }

        protected void gvUserDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edit")
                {
                    divFields.Visible = true;
                    divsearch.Visible = false;
                    txtUserId.Enabled = false;
                    int index = Convert.ToInt32(e.CommandArgument);
                    hdnUserId.Value = ((Label)gvUserDetails.Rows[index].FindControl("lblUserKey")).Text;
                    txtUserName.Text = ((Label)gvUserDetails.Rows[index].FindControl("lblFullname")).Text;
                    txtUserId.Text = ((Label)gvUserDetails.Rows[index].FindControl("lblUserId")).Text;
                    txtEmailId.Text = ((Label)gvUserDetails.Rows[index].FindControl("lblUserEMail")).Text;
                    txtContactNo.Text = ((Label)gvUserDetails.Rows[index].FindControl("lblUserContactNo")).Text;
                    txtAddress.Text = ((Label)gvUserDetails.Rows[index].FindControl("lblAddress")).Text;
                    getRole();
                    ddlRole.SelectedValue = ((Label)gvUserDetails.Rows[index].FindControl("lblRoleId")).Text;
                    //getBranch();
                    //ddlBranchName.SelectedValue = ((Label)gvUserDetails.Rows[index].FindControl("lblBranchId")).Text;
                    //getBranchwiseLocations();

                   
                    DataTable dtRole = objUserMaster.getUserBranchDetails(Convert.ToInt32(hdnUserId.Value), 0, "G");

                    //if (dtRole.Rows.Count > 0)
                    //{
                    //    for (int i = 0; i < dtRole.Rows.Count; i++)
                    //    {
                    //        ListItem currentCheckBox = chkBranch.Items.FindByValue(dtRole.Rows[i]["BranchId"].ToString());
                    //        if (currentCheckBox != null)
                    //        {
                    //            currentCheckBox.Selected = true;
                    //        }
                    //        else
                    //        {
                    //            currentCheckBox.Selected = false;
                    //        }
                    //    }
                    //}
                    //ddlRole_SelectedIndexChanged(ddlRole, null);
                    //ddlReportingTo.SelectedValue = ((Label)gvUserDetails.Rows[index].FindControl("lblReportingToId")).Text;
                    //rdbStatus.SelectedValue = ((Label)gvUserDetails.Rows[index].FindControl("lblUserStatus")).Text;
                    //btnSave.Text = "Modify";

                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "swal('" + ex.Message + "','Oh no!!','error');", true);
            }
        }

        protected void gvUserDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvUserDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvUserDetails.PageIndex = e.NewPageIndex;
                getUserDetails();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "swal('" + ex.Message + "','Oh no!!','error');", true);
            }
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            divFields.Visible = true;
            divsearch.Visible = false;
            btnSave.Text = "Save";
            resetPage();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                UserMaster objUserMaster = new UserMaster();
                DataTable dtGetUserSearch = objUserMaster.getUserDetails(0, txtSrchUser.Text, "", 0, "", "", "", 1, 0, 0,"S");
                if (dtGetUserSearch.Rows.Count > 0)
                {
                    gvUserDetails.DataSource = dtGetUserSearch;
                    gvUserDetails.DataBind();
                }
                else
                {
                    getUserDetails();
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
            txtSrchUser.Text = "";
            resetPage();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtGetUserDetails = objUserMaster.getUserDetails(0, "", txtUserId.Text, 0, "", "", "", 1, 0, 0, "C");
                if (hdnUserId.Value == "" || hdnUserId.Value == "0")
                {
                    if (dtGetUserDetails.Rows[0][0].ToString() == "0")
                    {
                        string strOperation;
                        int intUserIKey;
                        strOperation = "I";
                        intUserIKey = 0;

                        intUserIKey = objUserMaster.InsertUpdateUserMasterDetails(intUserIKey, txtUserName.Text, txtUserId.Text, Convert.ToInt32(ddlRole.SelectedValue.ToString()), txtEmailId.Text, txtContactNo.Text, txtAddress.Text, Convert.ToInt32(rdbStatus.SelectedValue), intUserKey, 0, strOperation);
                        //if (intUserIKey > 0)
                        //{
                        //    for (int i = 0; i < chkBranch.Items.Count; i++)
                        //    {
                        //        if (chkBranch.Items[i].Selected)
                        //        {
                        //            var branch = chkBranch.Items[i].Value;
                        //            objUserMaster.insertUpdateUserBranch(intUserIKey, Convert.ToInt32(branch), "I");
                        //        }
                        //    }

                            //for (int i = 0; i < chkLocations.Items.Count; i++)
                            //{
                            //    if (chkLocations.Items[i].Selected)
                            //    {
                            //        objUserMaster.insertUpdateUserLocation(intUserIKey, Convert.ToInt32(chkLocations.Items[i].Value), "I");
                            //    }
                            //}
                        //}
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "swal('User Details Saved Successfully.','','success');", true);
                        getUserDetails();
                        resetPage();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "swal('User Already Exists in the System.','','warning');", true);
                        getUserDetails();
                        resetPage();
                    }
                }

                else if (hdnUserId.Value != "" && hdnUserId.Value != "0")
                {
                    string strOperation;
                    int intNUserKey;
                    //int intUserKey;
                    intNUserKey = Convert.ToInt32(hdnUserId.Value);
                    strOperation = "U";
                    char charStatus;

                    intNUserKey = objUserMaster.InsertUpdateUserMasterDetails(intNUserKey, txtUserName.Text, txtUserId.Text, Convert.ToInt32(ddlRole.SelectedValue.ToString()), txtEmailId.Text, txtContactNo.Text, txtAddress.Text, Convert.ToInt32(rdbStatus.SelectedValue), 0, intUserKey, strOperation);
                    //if (intNUserKey > 0)
                    //{
                    //    objUserMaster.insertUpdateUserBranch(intNUserKey, 0, "D");
                    //    for (int i = 0; i < chkBranch.Items.Count; i++)
                    //    {
                    //        if (chkBranch.Items[i].Selected)
                    //        {
                    //            objUserMaster.insertUpdateUserBranch(intNUserKey, Convert.ToInt32(chkBranch.Items[i].Value), "I");
                    //        }
                    }
                        //objUserMaster.insertUpdateUserLocation(intNUserKey, 0, "D");
                        //for (int i = 0; i < chkLocations.Items.Count; i++)
                        //{
                        //    if (chkLocations.Items[i].Selected)
                        //    {
                        //        objUserMaster.insertUpdateUserLocation(intNUserKey, Convert.ToInt32(chkLocations.Items[i].Value), "I");
                        //    }
                        //}
                   // }
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "swal('User Details Modified Successfully.','','success');", true);
                    getUserDetails();
                    resetPage();
               // }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "swal('" + ex.Message + "','Oh no!!','error');", true);
            }
        }

      

        //private void getBranchwiseLocations1()
        //{
        //    try
        //    {
        //        DataTable dtRole = objUserMaster.getBranchwiseLocations(Convert.ToInt32(ddlBranchName.SelectedValue.ToString()));
        //        if (dtRole.Rows.Count > 0)
        //        {
        //            lstBranch.DataTextField = "LocationName";
        //            lstBranch.DataValueField = "BranchLocationId";
        //            lstBranch.DataSource = dtRole;
        //            lstBranch.DataBind();
        //        }
        //        else
        //        {
        //            lstBranch.Items.Clear();
        //            lstBranch.DataSource = null;
        //            lstBranch.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "swal('" + ex.Message + "','Oh no!!','error');", true);
        //    }
        //}
    }
}