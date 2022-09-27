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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        string strUserId;
        string strUserName;
        int intUserKey;
        int intUserRole;
        DataSet dsMenuData = new DataSet();
        public bool blnShowMenu = false;
        bool blnCounter = true;
        public string strData = "";
        DataTable dtUserDetails = new DataTable();
        MenuRights objMenuRights = new MenuRights();
        protected void Page_Load(object sender, EventArgs e)
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
                strUserName = dtUserDetails.Rows[0]["User_Name"].ToString();
                //intUserRole = Convert.ToInt32(dtUserDetails.Rows[0]["Role_Id"]);
                intUserRole = Convert.ToInt32(Session["RoleId"]);

                //  lblName.Text = strUserName;
            }

            if (Session["MenusData"] == null)
            {

                dsMenuData = GetData(intUserKey);
                Session["MenusData"] = dsMenuData;
                strUserName = dtUserDetails.Rows[0]["User_Name"].ToString();
            }
            else
            {
                if (Session["MenusData"] != null)
                {
                    dsMenuData = (DataSet)Session["MenusData"];
                }
                strUserName = dtUserDetails.Rows[0]["User_Name"].ToString();
            }
            if (dsMenuData != null && dsMenuData.Tables.Count > 0 && dsMenuData.Tables[0].Rows.Count > 0)
            {
                //GetMenuString(0);
                getGetMenusHTML(intUserKey);
                //PopulateMenu(dsMenuData, 0, null);
                blnShowMenu = true;
            }
        }



        #region "Menu Creation"
        private DataSet GetData(int UserKey)
        {
            DataSet dsData = new DataSet();
            try
            {
                dsData = objMenuRights.getMenus(UserKey);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dsData;
        }

        private void getGetMenusHTML(int UserKey)
        {
            try
            {
                DataTable dtHTML = new DataTable();
                dtHTML = objMenuRights.getGetMenusHTML(UserKey);
                strData = dtHTML.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetMenuString(int intRefID)
        {
            const string PRIMARY_KEY = "PRIVILEGEKEY";
            const string REFERENCE_KEY = "REFERENCEID";
            const string DISPLAY_NAME = "DESCRIPTION";
            const string FOLDER_PATH = "MAINMENUPATH";
            const string PAGE_NAME = "PAGENAME";

            DataRow[] drMenu = dsMenuData.Tables[0].Select(REFERENCE_KEY + " = " + intRefID.ToString());
            if (drMenu.Length > 0)
            {
                if (blnCounter)
                {

                    strData += "<ul class=\"nav\">";
                    //strData += "<li class=\"current\"><a href='" + Utilities.GetRootURL() + "/WebAppln/UI/Common/Home.aspx'>Home</a></li>";
                }
                else
                {
                    strData += "<ul class=\"nav flex-column sub-menu collapse\" id=\"ui-basic_" + intRefID + "\">";
                }


                MenuRights objMenuRights = new MenuRights();
                blnCounter = false;
                // strData += "<ul class=\"menu\">";
                foreach (DataRow dr in drMenu)
                {
                    strData += "<li runat=\"server\" ID=\"" + dr[PAGE_NAME] + "\" class=\"nav-item\">";
                    Session["PageName"] = dr[PAGE_NAME].ToString().Trim();
                    if (dr[PAGE_NAME].ToString().Trim() == "#")
                        strData += "<a class=\"nav-link\" data-toggle=\"collapse\" href=\"#ui-basic_" + intRefID + "\" aria-expanded=\"false\" aria-controls=\"ui-basic_" + intRefID + "\" href=\"javascript:void(0)\">" + dr[DISPLAY_NAME] + "</span></a>";
                    else
                    {
                        if (dr["SUBMENU"].ToString().Trim() != "0")
                        {
                            string strRoot = objMenuRights.GetRootURL();
                            string[] strRootPath = strRoot.Split('/');
                            strData += "<a  class=\"nav-link\"  href=\"" + objMenuRights.GetRootURL() + "/" + dr[FOLDER_PATH] + dr[PAGE_NAME] + "\"><span class=\"menu-title\">" + dr[DISPLAY_NAME] + "</span></a>";
                        }
                    }
                    GetMenuString(Convert.ToInt32(dr[PRIMARY_KEY]));
                    strData += "</li>\n";
                }
                //if (Session["PageName"].ToString().Trim() == "#")
                //{

                //    strData += "</ul>";
                //    //strData += "<li class=\"current\"><a href='" + Utilities.GetRootURL() + "/WebAppln/UI/Common/Home.aspx'>Home</a></li>";
                //}
                //else
                //{
                //    strData += "</ul>";
                //}

                strData += "</ul>";
            }
        }
        #endregion
    }
}