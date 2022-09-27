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
    public partial class UploadMaster : System.Web.UI.Page
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
                    getCarImages();
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

        protected void btnuplod_Click(object sender, EventArgs e)
        {
            if (ddlCar.SelectedValue != "-1")
            {
                foreach (HttpPostedFile htfiles in FileUpload1.PostedFiles)
                {
                    if (FileUpload1.HasFile)
                    {
                        bool save = false;
                        string str = Path.GetFileName(htfiles.FileName);
                        string filepath = Server.MapPath("~/Upload/");

                        string FileExtension = str.Substring(str.LastIndexOf('.') + 1).ToLower();
                        if (FileExtension == "jpeg" || FileExtension == "png" || FileExtension == "jpg")
                        {
                            if (!Directory.Exists(filepath))
                            {
                                Directory.CreateDirectory(filepath);
                            }
                            htfiles.SaveAs(Server.MapPath("~/Upload/" + str));
                            save = objMasterData.UploadCarosalImg(Convert.ToInt32(ddlCar.SelectedValue), str.ToString(), 1);

                            if (save)
                            {
                               // MsgBox("File Uploded Successfully.");
                                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "swal('File Uploded Successfully.','','success');", true);

                                getCarImages();
                            }

           

                        }
                        else
                        {
                            MsgBox("Please Upload File in JPEG or PNG Format");
                        }
                    }
                }
            }
            else
            {
                MsgBox("Please select Carosal Category...");
            }
        }



        protected void gvCarImages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    bool CarDel = false;
                    int index = Convert.ToInt32(e.CommandArgument);
                    hdnimg.Value = ((Label)gvCarImages.Rows[index].FindControl("lblCarImgID")).Text;
                    string id = ((Label)gvCarImages.Rows[index].FindControl("lblCarImgID")).Text;
                    string strimg = ((Label)gvCarImages.Rows[index].FindControl("lblImage")).Text;

                    //MsgBox(id.ToString());
                    CarDel = objMasterData.DeleteMasterDataByID(Convert.ToInt32(hdnimg.Value),"CAR");

                    if (CarDel)
                    {
                        MsgBox(strimg.ToString() + " Deleted");

                        getCarImages();
                    }

                }

                if (e.CommandName == "Down")
                {
                    
                    int index = Convert.ToInt32(e.CommandArgument);
                    hdnimg.Value = ((Label)gvCarImages.Rows[index].FindControl("lblCarImgID")).Text;
                    string id = ((Label)gvCarImages.Rows[index].FindControl("lblCarImgID")).Text;
                    string strimg = ((Label)gvCarImages.Rows[index].FindControl("lblImage")).Text;

                    //MsgBox(id.ToString());
                    if (strimg.ToString()!="")
                    {
                        Response.Clear();
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "filename=" + strimg.ToString());
                        Response.TransmitFile(Server.MapPath("~/Upload/") + strimg.ToString());
                        Response.End();
                    }

                }
            }
            catch (Exception ex)
            {
                MsgBox(ex.Message);
            }
        }

        protected void gvCarImages_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        private void getCarImages()
        {
            try
            {
                DataTable dtGetImage = objMasterData.getMasterData("img");

                if (dtGetImage.Rows.Count > 0)
                {
                    gvCarImages.DataSource = dtGetImage;
                    gvCarImages.DataBind();


                    string initialnamevalue2 = ((Label)gvCarImages.Rows[1].FindControl("lblCarousel")).Text;
                    for (int i = 1; i < gvCarImages.Rows.Count; i++)
                    {

                        if (((Label)gvCarImages.Rows[i].FindControl("lblCarousel")).Text == initialnamevalue2)
                        {
                            gvCarImages.Rows[i].Cells[1].Text = string.Empty;
                        }
                        else
                            initialnamevalue2 = ((Label)gvCarImages.Rows[i].FindControl("lblCarousel")).Text;
                    }

                }
                else
                {
                    gvCarImages.DataSource = null; ;
                    gvCarImages.DataBind();
                }
            }
            catch (Exception ex)
            {
                MsgBox(ex.Message);
            }
        }



        protected void gvCarImages_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}