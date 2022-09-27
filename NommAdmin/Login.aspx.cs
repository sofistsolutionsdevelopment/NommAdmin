using BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMS
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Session.Abandon();
                    Session.Clear();
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

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateUser objValidateUser = new ValidateUser();
                DataTable dtValidateUser = new DataTable();
                int intUserCount;
                dtValidateUser = objValidateUser.getLoginDetails(txtLogin.Text, txtPassword.Text);

                if (dtValidateUser.Rows.Count > 0)
                {
                    intUserCount = Convert.ToInt32(dtValidateUser.Rows[0]["COUNT"]);

                    if (intUserCount == 1)
                    {
                        Session["UserDetails"] = dtValidateUser;
                        Session["UserKey"] = dtValidateUser.Rows[0]["User_Key"].ToString();
                        Session["UserName"] = dtValidateUser.Rows[0]["User_Name"].ToString();
                        Session["UserId"] = dtValidateUser.Rows[0]["User_Id"].ToString();
                        Session["RoleName"] = dtValidateUser.Rows[0]["RoleDescription"].ToString();
                        Session["RoleId"] = dtValidateUser.Rows[0]["Role_Id"].ToString();

                        Response.Redirect("Dashboard.aspx", false);
                        Context.ApplicationInstance.CompleteRequest();

                    }
                }
                else
                {
                    MsgBox("Invalid User Id Or Password.");
                    //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "swal('Invalid User Id Or Password','Oh no!!','error');", true);
                    
                }
            }
            catch (Exception ex)
            {
                MsgBox(ex.Message);
            }
        }
    }
}