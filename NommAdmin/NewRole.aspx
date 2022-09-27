<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NewRole.aspx.cs" Inherits="NommAdmin.NewRole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">  
        function validate() {
            if (document.getElementById("<%=txtRoleName.ClientID %>").value == "") {
                swal("Please Enter Role");
                document.getElementById("<%=txtRoleName.ClientID %>").focus();
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="col-12 grid-margin stretch-card">
            <div class="col-md-12" id="divFields" runat="server">
                <div class="card">
                    <div class="card-body">
                        <div class="">
                            <h5 class="card-title">Add/Modify Role Details</h5>
                        </div>
                        <div class="form-group">
                            <label>Role Name</label>
                            <asp:TextBox ID="txtRoleName" autocomplete="Off" runat="server" CssClass="form-control" placeholder="Role"></asp:TextBox>

                        </div>
                        <div class="form-group">
                            <label>Status</label>
                            <asp:RadioButtonList ID="rdbStatus" runat="server" Width="30%" RepeatDirection="Horizontal">
                                <asp:ListItem Value="A" Text="Active" Selected="True"> </asp:ListItem>
                                <asp:ListItem Value="D" Text="De-Active"></asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RFV4" ErrorMessage="Please Select Status." Display="None"
                                ControlToValidate="rdbStatus" runat="server" ValidationGroup="btn" InitialValue="0"> </asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group text-right">
                            <asp:Button ID="btnSave" OnClientClick=" return validate()" runat="server" Text="Save" CssClass="btn btn-success btn-rounded mr-2" ValidationGroup="btn"
                                OnClick="btnSave_Click" />
                            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-light btn-rounded" OnClick="btnBack_Click" />
                            <asp:ValidationSummary ForeColor="Red" runat="server" ID="validationSummary" DisplayMode="BulletList"
                                ShowMessageBox="true" ShowSummary="false" EnableClientScript="true" ValidationGroup="btn"></asp:ValidationSummary>

                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-12" id="divsearch" runat="server">
                <div class="card">
                    <div class="card-body">
                        <div class="">
                            <h5 class="card-title">Role Details</h5>
                        </div>
                        <div class="row">
                            <div class="col-lg-9">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtSrchRole" autocomplete="Off" runat="server" CssClass="form-control" placeholder="Search Role"></asp:TextBox>
                                        <div class="input-group-append">
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-sm btn-primary" OnClick="btnSearch_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:Button ID="btnAddRole" runat="server" Text="Add New" CssClass="btn btn-primary btn-rounded btn-fw" OnClick="btnAddRole_Click"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="table-responsive">
                                <asp:GridView ID="gvRoleDetails" runat="server" AutoGenerateColumns="false" Width="100%"
                                    EmptyDataText="No Records Found" CssClass="table table-striped" AllowPaging="true"
                                    PageSize="10" OnRowCommand="gvRoleDetails_RowCommand" OnRowEditing="gvRoleDetails_RowEditing"
                                    OnPageIndexChanging="gvRoleDetails_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="30px">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnEdit" CommandName="Edit" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                    ImageUrl="../assets/images/Edit.svg" runat="server" Height="25px" />

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="RoleId" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRoleId" runat="server" Text='<%# Eval("RoleId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Role Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRoleName" runat="server" Text='<%# Eval("RoleDescription") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRoleStatus" runat="server" Text='<%# Eval("Status") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("StatusShow") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>

                    <asp:HiddenField ID="hdnRoleId" runat="server" Value="0" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
