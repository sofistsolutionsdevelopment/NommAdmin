<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AccessRights.aspx.cs" Inherits="NommAdmin.AccessRights" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="col-12 grid-margin stretch-card">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-body">
                        <div class="">
                            <h5 class="card-title">Access Rights</h5>
                        </div>
                        <div class="col-lg-12 form-group">
                            <label>Role Name</label>
                            <%-- <div class="form-check">
                            <label class="form-check-label">
                              <input type="checkbox" class="form-check-input">
                              Default
                            </label>
                          </div>--%>
                            <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlRole_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RFV3" ErrorMessage="Please Select Role." Display="None"
                                ControlToValidate="ddlRole" runat="server" ValidationGroup="btn" InitialValue="-1">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-12 table-responsive">
                            <asp:GridView ID="gvMenu" runat="server" AutoGenerateColumns="false"
                                EmptyDataText="No Records Found" OnRowDataBound="gvMenu_RowDataBound" CssClass="table table-striped">

                                <Columns>
                                    <asp:TemplateField HeaderText="MenuID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMenuID" runat="server" Text='<%# Eval("MenuRecKey") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="RefID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRefID" runat="server" Text='<%# Eval("RefID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="MAINMENU" HeaderText="Main Menu"></asp:BoundField>
                                    <asp:TemplateField HeaderText="Select" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>

                                            <asp:CheckBox ID="chkboxSelectAll" Height="20px" CssClass="checkbox" runat="server" OnCheckedChanged="chkboxSelectAll_CheckedChanged"
                                                AutoPostBack="true" />

                                            <%-- <div class="form-check">
                                        </div>--%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkAttend" OnCheckedChanged="chkAttend_CheckedChanged" AutoPostBack="true" Height="20px" CssClass="checkbox" runat="server" />
                                            <%--Checked='<%# bool.Parse(Eval("ATT_ATTENDANCE").ToString()== "Y" ? "True":"False") %>'--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="SUBMENU" Visible="false"></asp:BoundField>
                                    <asp:BoundField DataField="PAGENAME" Visible="false"></asp:BoundField>
                                    <asp:BoundField DataField="SUBSUBMENU" Visible="false"></asp:BoundField>
                                    <asp:TemplateField HeaderText="Select" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFlag" runat="server" Text='<%# Eval("AddFlag") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:HiddenField ID="hdnCatId" runat="server" Value="0" />
                        </div>
                        <div class="col-lg-12 text-right" style="margin-top: 20px;">
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-round btn-fw btn-primary" ValidationGroup="btn"
                                OnClick="btnSave_Click" OnClientClick="return Validate_Checkbox()" />
                            <asp:ValidationSummary ForeColor="Red" runat="server" ID="validationSummary1" DisplayMode="BulletList"
                                ShowMessageBox="true" ShowSummary="false" EnableClientScript="true" ValidationGroup="btn"></asp:ValidationSummary>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
