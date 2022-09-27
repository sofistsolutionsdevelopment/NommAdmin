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
    public partial class CategoryMaster : System.Web.UI.Page
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
                    getCategory();
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


        private void getCategory()
        {
            try
            {

                DataTable dtCategory = objMasterData.getMasterData("CAT");
                if (dtCategory.Rows.Count > 0)
                {
                    gvCatDetail.DataSource = dtCategory;
                    gvCatDetail.DataBind();
                }
            }
            catch (Exception ex)
            {
                MsgBox(ex.Message);
            }
        }

        protected void btnSaveNewCategory_Click(object sender, EventArgs e)
        {
            try
            {
                int IntCat = 0;

                if (hdnCat.Value == "" || hdnCat.Value == "0")
                {
                    IntCat = objMasterData.InsertCategoryData(0, txtCat.Text, Convert.ToInt32(rdbStatus.SelectedValue), "I");

                    if (IntCat > 0)
                    {
                      //  MsgBox("Category Data Saved Successfully.");
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "swal('Category Data Saved Successfully.','','success');", true);

                        divFields.Visible = false;
                        divsearch.Visible = true;
                    }
                }
                else
                {
                    int inthdnvalue = Convert.ToInt32(hdnCat.Value);

                    IntCat = objMasterData.InsertCategoryData(inthdnvalue, txtCat.Text, Convert.ToInt32(rdbStatus.SelectedValue), "U");

                    if (IntCat > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "swal('Category Data Modified Successfully.','','success');", true);
                       // MsgBox("Category Data Modified Successfully.");
                        divFields.Visible = false;
                        divsearch.Visible = true;
                    }
                }

                getCategory();
                resetpage();
            }
            catch (Exception ex)
            {
                MsgBox(ex.Message);
            }

        }

        protected void gvCatDetail_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edit")
                {
                    divFields.Visible = true;
                    divsearch.Visible = false;

                    int index = Convert.ToInt32(e.CommandArgument);
                    hdnCat.Value = ((Label)gvCatDetail.Rows[index].FindControl("lblID")).Text;
                    txtCat.Text = ((Label)gvCatDetail.Rows[index].FindControl("lblcatname")).Text;
                    rdbStatus.SelectedValue = ((Label)gvCatDetail.Rows[index].FindControl("lblstID")).Text;
                }

                if (e.CommandName == "Del")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    hdnCat.Value = ((Label)gvCatDetail.Rows[index].FindControl("lblID")).Text;
                    txtCat.Text = ((Label)gvCatDetail.Rows[index].FindControl("lblcatname")).Text;

                    bool CarDel = false;

                    CarDel = objMasterData.DeleteMasterDataByID(Convert.ToInt32(hdnCat.Value), "CAT");

                    if (CarDel)
                    {
                        MsgBox(txtCat.Text + " Deleted");

                        getCategory();
                    }


          
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
                if (txtSrchCat.Text != "")
                {
                    DataTable dtCategory = objMasterData.getMasterDataByID(0, txtSrchCat.Text, "CAT");
                    if (dtCategory.Rows.Count > 0)
                    {
                        gvCatDetail.DataSource = dtCategory;
                        gvCatDetail.DataBind();
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

        protected void gvCatDetail_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void btnclose_Click(object sender, EventArgs e)
        {
            divFields.Visible = false;
            divsearch.Visible = true;
        }

        private void resetpage()
        {
            txtCat.Text = "";
        }
        }
}