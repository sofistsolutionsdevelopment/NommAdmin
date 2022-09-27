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
    public partial class AccessRights : System.Web.UI.Page
    {
        int intRoleId;
        string strUserId;
        int intUserKey;
        DataTable dtUserDetails = new DataTable();
        MenuRights objMenuRights = new MenuRights();
        MasterData getMasterData = new MasterData();

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
                    string strURL = Request.RawUrl;
                    try
                    {
                        strURL = strURL.Substring(strURL.LastIndexOf("/") + 1);
                    }
                    catch { }
                    getRole();
                }
            }
            catch (Exception ex)
            {
                MsgBox(ex.Message);
            }
        }

        protected void chkboxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ChkBoxHeader = (CheckBox)gvMenu.HeaderRow.FindControl("chkboxSelectAll");
            foreach (GridViewRow row in gvMenu.Rows)
            {
                CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkAttend");
                if (ChkBoxHeader.Checked == true)
                {
                    ChkBoxRows.Checked = true;
                }
                else
                {
                    ChkBoxRows.Checked = false;
                }
            }
        }

        protected void gvMenu_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                bool chChecked;
                int str = e.Row.RowIndex;
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Cells[5].Visible = true;
                    CheckBox chInsert = (CheckBox)e.Row.Cells[2].FindControl("chkAttend");
                    Label lblFlag = (Label)e.Row.FindControl("lblFlag");
                    Label lblRefID = (Label)e.Row.FindControl("lblRefID");
                    if (lblRefID.Text == "0")
                    {

                        e.Row.ForeColor = System.Drawing.Color.Black;
                        e.Row.Font.Bold = true;
                    }

                    //e.Row.Cells[5].Visible = false;

                    if (lblRefID.Text != "0")
                    {
                        e.Row.Cells[2].Style.Add("padding-left", "50px");
                    }
                    else
                    {
                        e.Row.Cells[2].Font.Bold = true;
                    }
                    if (Convert.ToChar(lblFlag.Text) == 'N')
                    {
                        chChecked = false;
                    }
                    else
                    {
                        chChecked = true;
                    }
                    chInsert.Checked = chChecked;

                }
            }
            catch (Exception ex)
            {
                MsgBox(ex.Message);
            }

        }

        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                getRoleMenu();
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
                MenuRights objMenuRights = new MenuRights();
                bool save = false;
                bool delete = false;
                intRoleId = Convert.ToInt32(ddlRole.SelectedItem.Value);
                //int CheckAtLeastOneCheck = 0;
                delete = objMenuRights.insertRoleMenu(intRoleId, 0, 'A', 1, "D");
                for (int i = 0; i <= gvMenu.Rows.Count; i++)
                {
                    GridViewRow row = gvMenu.Rows[i];
                    char chrInsert;
                    Label lblMenuID = (Label)row.FindControl("lblMenuID");
                    int intMenuId = Convert.ToInt32(lblMenuID.Text);
                    CheckBox chInsert = (CheckBox)row.FindControl("chkAttend");
                    if (chInsert.Checked == true)
                    {
                        chrInsert = 'Y';
                    }
                    else
                    {
                        chrInsert = 'N';
                    }
                    save = objMenuRights.insertRoleMenu(intRoleId, intMenuId, chrInsert, 1, "I");
                    if (save)
                    {
                        MsgBox("Access Rights Acoording to Role Saved Successfully.");
                      
                    }
                }
                getRoleMenu();

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

        private void getRole()
        {
            try
            {

                DataTable dtRole = getMasterData.getMasterData("R");
                if (dtRole.Rows.Count > 0)
                {
                    ddlRole.DataTextField = "RoleDescription";
                    ddlRole.DataValueField = "RoleId";
                    ddlRole.DataSource = dtRole;
                    ddlRole.DataBind();
                }

            }
            catch (Exception ex)
            {
                MsgBox(ex.Message);
            }
        }

        private void getRoleMenu()
        {
            try
            {

                int intRole = Convert.ToInt32(ddlRole.SelectedValue.ToString());
                DataTable dtRoleMenu = objMenuRights.getAccessRights(intRole);
                if (dtRoleMenu.Rows.Count > 0)
                {
                    gvMenu.DataSource = dtRoleMenu;
                    gvMenu.DataBind();
                }
            }
            catch (Exception ex)
            {
                MsgBox(ex.Message);
            }
        }

        protected void chkAttend_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox cb = (CheckBox)sender;

                GridViewRow parentRow = cb.NamingContainer as GridViewRow;

                Label lblMenuID = parentRow.FindControl("lblMenuID") as Label;
                Label lblRefID = parentRow.FindControl("lblRefID") as Label;

                int chkcount = 0;

                if (cb.Checked)
                {
                    if (lblMenuID != null && lblRefID.Text == "0")
                    {
                        foreach (GridViewRow row in gvMenu.Rows)
                        {
                            Label lblMenuIDN = (Label)row.FindControl("lblMenuID");
                            Label lblRefIDN = (Label)row.FindControl("lblRefID");

                            CheckBox chk = (CheckBox)row.FindControl("chkAttend");

                            if (lblMenuID.Text == lblRefIDN.Text)
                            {
                                chk.Checked = true;
                            }
                        }
                    }

                    if (lblMenuID != null && lblRefID.Text != "0")
                    {
                        foreach (GridViewRow row in gvMenu.Rows)
                        {
                            Label lblMenuIDN = (Label)row.FindControl("lblMenuID");
                            Label lblRefIDN = (Label)row.FindControl("lblRefID");

                            CheckBox chk = (CheckBox)row.FindControl("chkAttend");

                            if (lblRefID.Text == lblMenuIDN.Text)
                            {
                                chk.Checked = true;
                            }
                        }
                    }
                }
                else
                {
                    if (lblMenuID != null && lblRefID.Text == "0")
                    {
                        foreach (GridViewRow row in gvMenu.Rows)
                        {
                            Label lblMenuIDN = (Label)row.FindControl("lblMenuID");
                            Label lblRefIDN = (Label)row.FindControl("lblRefID");

                            CheckBox chk = (CheckBox)row.FindControl("chkAttend");

                            if (lblMenuID.Text == lblRefIDN.Text)
                            {
                                chk.Checked = false;
                            }
                        }
                    }

                    if (lblMenuID != null && lblRefID.Text != "0")
                    {
                        foreach (GridViewRow row in gvMenu.Rows)
                        {
                            Label lblMenuIDN = (Label)row.FindControl("lblMenuID");
                            Label lblRefIDN = (Label)row.FindControl("lblRefID");


                            if (lblRefID.Text == lblRefIDN.Text)
                            {
                                CheckBox chk = (CheckBox)row.FindControl("chkAttend");
                                if (chk.Checked)
                                {
                                    chkcount = chkcount + 1;
                                }

                            }
                        }
                        foreach (GridViewRow row in gvMenu.Rows)
                        {
                            Label lblMenuIDN = (Label)row.FindControl("lblMenuID");
                            Label lblRefIDN = (Label)row.FindControl("lblRefID");
                            CheckBox chk = (CheckBox)row.FindControl("chkAttend");

                            if (chkcount == 0)
                            {
                                if (lblRefID.Text == lblMenuIDN.Text)
                                {
                                    chk.Checked = false;
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox(ex.Message);
            }
        }
    }
}