<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CategoryMaster.aspx.cs" Inherits="NommAdmin.CategoryMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">  
        function validate() {
            if (document.getElementById("<%=txtCat.ClientID %>").value == "") {
                swal("Please Enter Category Name");
                document.getElementById("<%=txtCat.ClientID %>").focus();
                return false;
            }
          
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
            <div class="col-md-12" id="divsearch" runat="server">
                <div class="card">
                    <div class="card-body">
                        <div class="">
                            <h5 class="card-title">Category Details</h5>
                        </div>
                        <div class="row">
                            <div class="col-lg-9">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtSrchCat" runat="server" CssClass="form-control" placeholder="Search Category"></asp:TextBox>
                                        <div class="input-group-append">
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-sm btn-primary" />
                                        </div>
                                    </div>

                                </div>

                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Button ID="btnAddNew" runat="server" Text="Add New" Height="45px" OnClick="btnAddNew_Click" CssClass="btn btn-sm btn-primary" />
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12">
                                <div class="form-group">
                                    <div class="table-responsive">
                                        <asp:GridView ID="gvCatDetail" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="Gainsboro"
                                            EmptyDataText="No Records Found" CssClass="table table-hover table-responsive-sm" AllowPaging="true"
                                            PageSize="10" PagerStyle-CssClass="pagination-ys" Width="100%" OnRowCommand="gvCatDetail_RowCommand" OnRowEditing="gvCatDetail_RowEditing">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Action" HeaderStyle-Width="15px">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnEdit" CommandName="Edit" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                            ImageUrl="../assets/images/Edit.svg" runat="server" Height="20px" />
                                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:ImageButton ID="btndel" CommandName="Del" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                            ImageUrl="../assets/images/trash-solid.svg" OnClientClick="return confirm('Are you sure you want to delete this event?');" runat="server" Height="20px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Category">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID" runat="server" Visible="false" Text='<%# Eval("Cat_Id") %>'></asp:Label>
                                                        <asp:Label ID="lblcatname" runat="server" Text='<%# Eval("Category") %>'></asp:Label>
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
                        <asp:HiddenField ID="hdnCat" runat="server" />
                    </div>
                </div>
            </div>
        <div class="col-md-12" runat="server" id="divFields" visible="false">
            <div class="card">
                <div class="card-body">
                    <div class="">
                        <h5 class="card-title">Add Category Details</h5>
                    </div>
                    <div class="row">
                        <div class="col-lg-9">
                            <div class="form-group">
                                <label>Category Name</label>

                                <asp:TextBox ID="txtCat" runat="server" CssClass="form-control"></asp:TextBox>
                               <%-- <asp:RequiredFieldValidator ID="RFV56" ErrorMessage="Please Enter Category Name" Display="None"
                                    ControlToValidate="txtCat" runat="server" ValidationGroup="btncat"> </asp:RequiredFieldValidator>--%>
                            </div>

                            <div class="form-group">
                                <label>Status</label>
                                <asp:RadioButtonList ID="rdbStatus" runat="server" Width="30%" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1" Text="Active" Selected="True"> </asp:ListItem>
                                    <asp:ListItem Value="0" Text="De-Active"></asp:ListItem>
                                </asp:RadioButtonList>
                               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ErrorMessage="Please Select Status." Display="None"
                                    ControlToValidate="rdbStatus" runat="server" ValidationGroup="btncat"> </asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="text-end" style="float: right">
                                <asp:Button ID="btnSaveNewCategory" runat="server" Text="Save" CssClass="btn btn-primary me-2" ValidationGroup="btncat" OnClientClick=" return validate()" OnClick="btnSaveNewCategory_Click" />
                                   <asp:Button ID="btnclose" runat="server" Text="Close" CssClass="btn btn-default" OnClick="btnclose_Click"/>
                               <%-- <asp:ValidationSummary ForeColor="Red" runat="server" ID="validationSummary4" DisplayMode="BulletList"
                                    ShowMessageBox="true" ShowSummary="false" EnableClientScript="true" ValidationGroup="btncat"></asp:ValidationSummary>--%>
                            </div>
                        </div>
                    </div>

                </div>
            </div>

        </div>
    </div>
</asp:Content>
