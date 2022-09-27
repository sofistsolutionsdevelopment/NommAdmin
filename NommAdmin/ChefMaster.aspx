<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ChefMaster.aspx.cs" Inherits="NommAdmin.ChefMaster" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager runat="server" />
    <div class="content-wrapper">
        <div class="col-md-12" id="divsearch" runat="server">
            <div class="card">
                <div class="card-body">
                    <div class="">
                        <h5 class="card-title">Chef Details</h5>
                    </div>
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>From Date</label>
                                <asp:TextBox ID="txtFromDate" runat="server"  AutoComplete="true" CssClass="form-control"></asp:TextBox>
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                    Enabled="True" TargetControlID="txtFromDate"></ajax:CalendarExtender>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>To Date</label>
                                <asp:TextBox ID="txtToDate" AutoComplete="true" runat="server" CssClass="form-control"></asp:TextBox>
                                <ajax:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd/MM/yyyy"
                                    Enabled="True" TargetControlID="txtToDate"></ajax:CalendarExtender>
                            </div>
                        </div>
                        <asp:CompareValidator ID="CompareValidator1" ValidationGroup="Date" ForeColor="Red"
                            runat="server" ControlToValidate="txtFromDate" ControlToCompare="txtToDate"
                            Operator="LessThan" Type="Date" ErrorMessage="From date must be less than To date."></asp:CompareValidator>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <asp:Button ID="btnSearch" Style="height: 40px; margin-top: 30px" OnClick="btnSearch_Click" runat="server" Text="Search" CssClass="btn btn-sm btn-primary" />
                            </div>
                        </div>
                    </div>
                    <%--<div class="col-lg-9">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtSrchServ" runat="server" CssClass="form-control" placeholder="Search Services"></asp:TextBox>
                                        <div class="input-group-append">
                                            <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" Text="Search"  CssClass="btn btn-sm btn-primary" />
                                           
                                        </div>
                                    </div>

                                </div>

                            </div>--%>
                    <%--  <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Button ID="btnAddNew" runat="server" Height="45px" Text="Add New" OnClick="btnAddNew_Click" CssClass="btn btn-sm btn-primary" />
                                </div>
                            </div>--%>
                </div>
                <div class="col-lg-12">
                    <div class="form-group">
                        <div class="table-responsive">
                            <asp:GridView ID="gvChefDetail" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="Gainsboro"
                                EmptyDataText="No Records Found" CssClass="table table-hover table-responsive-sm" AllowPaging="true"
                                PageSize="10" PagerStyle-CssClass="pagination-ys" Width="100%" OnRowCommand="gvChefDetail_RowCommand" OnRowEditing="gvChefDetail_RowEditing">
                                <Columns>
                                    <%--<asp:TemplateField HeaderText="Action" HeaderStyle-Width="15px">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnEdit" CommandName="Edit" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                            ImageUrl="../assets/images/Edit.svg" runat="server" Height="20px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Chef Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblChefID" runat="server" Visible="false" Text='<%# Eval("ChefID") %>'></asp:Label>
                                            <asp:Label ID="lblCheffname" runat="server" Text='<%# Eval("fname") %>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblCheflname" runat="server" Text='<%# Eval("lname") %>' Visible="false"></asp:Label>
                                            <asp:LinkButton Text='<%# Eval("ChefName") %>' ID="lnkbtnChefname" runat="server" CommandName="View" CommandArgument="<%# Container.DataItemIndex %>" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblChefPhno" runat="server" Visible="false" Text='<%# Eval("Phno") %>'></asp:Label>
                                            <asp:Label ID="lblChefEmail" runat="server" Text='<%# Eval("Email") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Store Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStoreName" runat="server" Text='<%# Eval("Store_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Category" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcatID" runat="server" Text='<%# Eval("CategoryID") %>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblServSts" runat="server" Text='<%# Eval("ServicingStatus") %>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblServCatID" runat="server" Text='<%# Eval("ServicingCatID") %>' Visible="false"></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Address" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcityID" runat="server" Text='<%# Eval("CityID") %>' Visible="false"></asp:Label>
                                            <asp:Label ID="lbladdr" runat="server" Text='<%# Eval("Address") %>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblpincode" runat="server" Text='<%# Eval("Pincode") %>' Visible="false"></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="FSSAI Certificate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFSSIsts" runat="server" Text='<%# Eval("FSSAIStatus") %>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblFSSINo" runat="server" Text='<%# Eval("FSSAICertNo") %>'></asp:Label>
                                            <asp:Label ID="lblAdhrNo" runat="server" Text='<%# Eval("AadharNo") %>' Visible="false"></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Status">
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
                <asp:HiddenField ID="hdnchf" runat="server" />
            </div>
        </div>

        <div class="col-md-12" runat="server" id="divFields" visible="false">
            <div class="card">
                <div class="card-body">
                    <div class="">
                        <h5 class="card-title">Registration Info Detail</h5>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>First Name</label>
                                <asp:TextBox ID="txtID" Enabled="false" Visible="false" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:TextBox ID="txtFname" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>Last Name</label>
                                <asp:TextBox ID="txtLname" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>Email</label>
                                <asp:TextBox ID="txtEmail" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>Phone No.</label>
                                <asp:TextBox ID="txtPhn" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="card">
                <div class="card-body">
                    <div class="">
                        <h5 class="card-title">Store Info Detail</h5>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>Store Name</label>
                                <asp:TextBox ID="txtStorename" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>Cusione/Food Catgory</label>
                                <asp:TextBox ID="txtcat" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                                <asp:DropDownList ID="ddlCat" Enabled="false" runat="server" CssClass="form-control" Width="100%">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>Currently Servicing</label>
                                <asp:RadioButtonList ID="rdbCurrentService" runat="server" Width="30%" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1" Text="Yes" Selected="True"> </asp:ListItem>
                                    <asp:ListItem Value="0" Text="No"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>Servicing Via</label>
                                <asp:TextBox ID="txtServcat" runat="server" Enabled="false" CssClass="form-control" Visible="false"></asp:TextBox>
                                <asp:DropDownList ID="ddlservCat" runat="server" CssClass="form-control" Width="100%">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>Address</label>
                                <asp:TextBox ID="txtaddr" runat="server" Enabled="false" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>City</label>
                                <asp:TextBox ID="txtcity" runat="server" Enabled="false" CssClass="form-control" Visible="false"></asp:TextBox>
                                <asp:DropDownList ID="ddlcity" Enabled="false" runat="server" CssClass="form-control" Width="100%">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group" runat="server" visible="false">
                                <label>State</label>
                                <asp:TextBox ID="txtState" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>Pincode</label>
                                <asp:TextBox ID="txtPincode" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="card">
                <div class="card-body">
                    <div class="">
                        <h5 class="card-title">FSSAI Info Detail</h5>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>Do you have FSSAI Certificate</label>
                                <asp:RadioButtonList ID="rdbFssiCert" runat="server" Enabled="false" Width="30%" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1" Text="Yes" Selected="True"> </asp:ListItem>
                                    <asp:ListItem Value="0" Text="No"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>FSSAI Certificate No.</label>
                                <asp:TextBox ID="txtFSSAINo" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>Aadhar No.</label>
                                <asp:TextBox ID="txtAadharNo" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>Status</label>
                                <asp:RadioButtonList ID="rdbStatus" runat="server" Width="30%" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1" Text="Active"> </asp:ListItem>
                                    <asp:ListItem Value="0" Text="De-Active" Selected="True"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                    </div>


                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group">
                                <asp:Button ID="btnModify" runat="server" Text="Modify" CssClass="btn btn-success" OnClick="btnModify_Click" />
                                <asp:Button ID="btnclose" runat="server" Text="Close" CssClass="btn btn-info" OnClick="btnclose_Click" />
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
