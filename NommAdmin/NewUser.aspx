<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NewUser.aspx.cs" Inherits="NommAdmin.NewUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">  
        function validate() {
            if (document.getElementById("<%=txtUserName.ClientID %>").value == "") {
                swal("Please Enter User Name");
                document.getElementById("<%=txtUserName.ClientID %>").focus();
                return false;
            }
            if (document.getElementById("<%=txtUserId.ClientID %>").value == "") {
                swal("Please Enter Login Id");
                document.getElementById("<%=txtUserId.ClientID %>").focus();
                return false;
            }

            if (document.getElementById("<%=txtContactNo.ClientID %>").value == "") {
                swal("Please Enter Contact No");
                document.getElementById("<%=txtContactNo.ClientID %>").focus();
                return false;
            }
            var conPat = /^\+?([0-9]{2})\)?[-. ]?([0-9]{4})[-. ]?([0-9]{4})$/;
            var contact = document.getElementById("<%=txtContactNo.ClientID %>").value;
            var matchArray = contact.match(conPat);
            if (matchArray == null) {
                swal("Not a valid Contact Number.");
                document.getElementById("<%=txtContactNo.ClientID %>").focus();
                return false;
            }

            if (document.getElementById("<%=txtEmailId.ClientID %>").value == "") {
                swal("Please Enter Email Id");
                document.getElementById("<%=txtEmailId.ClientID %>").focus();
                return false;
            }
            var emailPat = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
            var emailid = document.getElementById("<%=txtEmailId.ClientID %>").value;
            var matchArray = emailid.match(emailPat);
            if (matchArray == null) {
                swal("Your email address seems incorrect. Please try again.");
                document.getElementById("<%=txtEmailId.ClientID %>").focus();
                return false;
            }
            if (document.getElementById("<%=txtAddress.ClientID %>").value == "") {
                swal("Please Enter Address");
                document.getElementById("<%=txtAddress.ClientID %>").focus();
                return false;
            }
        }
    </script>
    <style type="text/css">
        .scrollingControlContainer {
            overflow-x: hidden;
            overflow-y: scroll;
        }

        .scrollingCheckBoxList {
            border: 1px solid lightgrey;
            margin: 10px 0px 10px 0px;
            height: 100px;
            width: 300px;
            padding: 6px 0px 5px 11px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="col-12 grid-margin stretch-card">
            <div class="col-md-12" id="divFields" runat="server">
                <div class="card">
                    <div class="card-body">
                        <div class="">
                            <h5 class="card-title">Add/Modify User Details</h5>
                        </div>
                        <div class="row">
                            <div class="form-group col-lg-6">
                                <label>User Name</label>
                                <asp:TextBox ID="txtUserName" autocomplete="off" placeholder="User Name" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group col-lg-6">
                                <label>Login Id</label>
                                <asp:TextBox ID="txtUserId" placeholder="User Id" autocomplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group col-lg-6">
                                <label>Contact No</label>
                                <asp:TextBox ID="txtContactNo" TextMode="Number" MaxLength="12" runat="server" CssClass="form-control" placeholder="Contact No"></asp:TextBox>
                            </div>
                            <div class="form-group col-lg-6">
                                <label>Email Id</label>
                                <asp:TextBox ID="txtEmailId" autocomplete="off" placeholder="EmailId" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group col-lg-12">
                                <label>Address</label>
                                <asp:TextBox ID="txtAddress" autocomplete="off" placeholder="Address" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group col-lg-6">
                                <label>Role</label>
                                <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control" >
                                </asp:DropDownList><%--js-example-basic-single w-100--%> <%--OnSelectedIndexChanged="ddlRole_SelectedIndexChanged" --%>
                            </div>
                            <div class="form-group col-lg-6">
                                <label>Status</label>
                                <asp:RadioButtonList ID="rdbStatus" runat="server" Width="60%" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1" Text="Active" Selected="True"> </asp:ListItem>
                                    <asp:ListItem Value="0" Text="De-Active"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="form-group text-right">
                            <asp:Button ID="btnSave" OnClientClick=" return validate()" OnClick="btnSave_Click" runat="server" Text="Save" CssClass="btn btn-success btn-rounded mr-2" ValidationGroup="btn" />
                            <asp:Button ID="btnBack" OnClick="btnBack_Click" runat="server" Text="Back" UseSubmitBehavior="false" CssClass="btn btn-light btn-rounded" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-12" id="divsearch" runat="server">
                <div class="card">
                    <div class="card-body">
                        <div class="">
                            <h5 class="card-title">System User Details</h5>
                        </div>
                        <div class="row">
                            <div class="col-lg-9">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtSrchUser" autocomplete="off" runat="server" CssClass="form-control" placeholder="Search User"></asp:TextBox>
                                        <div class="input-group-append">
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-sm btn-primary" OnClick="btnSearch_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:Button ID="btnAddUser" runat="server" Text="Add New" CssClass="btn btn-primary btn-rounded btn-fw" OnClick="btnAddUser_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="table-responsive">
                                <asp:GridView ID="gvUserDetails" runat="server" AutoGenerateColumns="false" Width="100%"
                                    EmptyDataText="No Records Found" CssClass="table table-striped" OnRowCommand="gvUserDetails_RowCommand"
                                    OnRowEditing="gvUserDetails_RowEditing" AllowPaging="true" PageSize="10" PagerStyle-CssClass="pagination-ys" OnPageIndexChanging="gvUserDetails_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="30px">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnEdit" CommandName="Edit" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                    ImageUrl="../assets/images/Edit.svg" Height="25px" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="UserKey" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUserKey" runat="server" Text='<%# Eval("User_Key") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderText="BranchId" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBranchId" runat="server" Text='<%# Eval("BranchId") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                        <%-- <asp:TemplateField HeaderText="Branch">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBranchName" runat="server" Text='<%# Eval("Branch") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="User Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFullname" runat="server" Text='<%# Eval("User_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="User Id">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUserId" runat="server" Text='<%# Eval("User_Id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Role">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRoleId" runat="server" Text='<%# Eval("Role_Id") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblRole" runat="server" Text='<%# Eval("RoleDescription") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="E-Mail">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUserEMail" runat="server" Text='<%# Eval("User_EMail") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Contact No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUserContactNo" runat="server" Text='<%# Eval("User_ContactNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Address">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUserStatus" runat="server" Text='<%# Eval("Status") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("StatusShow") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                    <asp:HiddenField ID="hdnUserId" runat="server" Value="0" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
