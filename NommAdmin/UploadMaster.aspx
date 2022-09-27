<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UploadMaster.aspx.cs" Inherits="NommAdmin.UploadMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="col-md-12" runat="server" id="divFields">
            <div class="card">
                <div class="card-body">
                    <div class="">
                        <h5 class="card-title">Carousel Image Upload</h5>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>Select Carousel</label>
                                <asp:DropDownList ID="ddlCar" runat="server" CssClass="form-control" Width="100%">
                                    <asp:ListItem Text="--Select--" Value="-1"></asp:ListItem>
                                    <asp:ListItem Text="Registration Info" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Store Info" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="FSSAI Info" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-6" style="margin-top: 38px;">
                            <div class="form-group">

                                <asp:FileUpload ID="FileUpload1" AllowMultiple="true" runat="server" />
                                <asp:Button ID="btnuplod" runat="server" Text="Upload" CssClass="btn btn-primary" OnClick="btnuplod_Click" />
                            </div>
                        </div>



                    </div>

                    <label style="float: right; font-style: italic; font-weight: bolder; color: red; font-size: 13px;">Select Files in PNG,JPEG,JPG format</label>

                </div>

            </div>
        </div>
        <br />
        <br />
        <div class="col-md-12" runat="server" id="div1">
            <div class="card">
                <div class="card-body">
                    <div class="form-group">
                        <div class="table-responsive">
                            <asp:GridView ID="gvCarImages" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="Gainsboro"
                                EmptyDataText="No Records Found" CssClass="table table-hover table-responsive-sm" AllowPaging="true"
                                PageSize="10" PagerStyle-CssClass="pagination-ys" Width="100%" OnRowCommand="gvCarImages_RowCommand" OnRowEditing="gvCarImages_RowEditing" OnRowDeleting="gvCarImages_RowDeleting">
                                <Columns>
                                    <%--   <asp:TemplateField HeaderText="Action" HeaderStyle-Width="15px">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnEdit" CommandName="Edit" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                            ImageUrl="../assets/images/Edit.svg" runat="server" Height="20px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Action" HeaderStyle-Width="25px">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btndelt" CommandName="Delete" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                ImageUrl="../assets/images/trash-solid.svg" OnClientClick="return confirm('Are you sure you want to delete this event?');" runat="server" Height="20px" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:ImageButton ID="btnDown" CommandName="Down" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                            ImageUrl="../assets/images/download-solid.svg" runat="server" Height="20px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Carousel">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCarouselID" runat="server" Visible="false" Text='<%# Eval("CarouselID") %>'></asp:Label>
                                            <asp:Label ID="lblCarousel" runat="server" Text='<%# Eval("Carousel") %>'></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>

                                            <asp:Label ID="lblCarImgID" runat="server" Text='<%# Eval("CarImgID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Image">
                                        <ItemTemplate>

                                            <asp:Label ID="lblImage" runat="server" Text='<%# Eval("Image") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Status" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstID" runat="server" Visible="false" Text='<%# Eval("StID") %>'></asp:Label>
                                            <asp:Label ID="lblstatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                </Columns>
                            </asp:GridView>
                        </div>

                    </div>
                </div>
                <asp:HiddenField ID="hdnimg" runat="server" />
            </div>
        </div>
    </div>


</asp:Content>
