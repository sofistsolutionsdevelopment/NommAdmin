<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="FAQ.aspx.cs" Inherits="NommAdmin.FAQ" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="assets/ckeditor/ckeditor.js"></script>

       <script language="javascript" type="text/javascript">  
           function validate() {
               if (document.getElementById("<%=txtQue.ClientID %>").value == "") {
                swal("Please Enter Question");
                document.getElementById("<%=txtQue.ClientID %>").focus();
                   return false;
               }

               if (document.getElementById("<%=txtAns.ClientID %>").value == "") {
                swal("Please Enter Answer");
                    document.getElementById("<%=txtAns.ClientID %>").focus();
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
                            <h5 class="card-title">FAQ Details</h5>
                        </div>
                        <div class="row">
                            <div class="col-lg-9">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtFaqServ" runat="server" CssClass="form-control" placeholder="Search Questions.."></asp:TextBox>
                                        <div class="input-group-append">
                                            <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" Text="Search"  CssClass="btn btn-sm btn-primary" />
                                           
                                        </div>
                                    </div>

                                </div>

                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Button ID="btnAddNew" runat="server" Height="45px" Text="Add New" OnClick="btnAddNew_Click" CssClass="btn btn-sm btn-primary" />
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12">
                                <div class="form-group">
                                    <div class="table-responsive">
                                        <asp:GridView ID="gvFAQDetail" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="Gainsboro"
                                            EmptyDataText="No Records Found" CssClass="table table-hover table-responsive-sm" AllowPaging="true"
                                            PageSize="10" PagerStyle-CssClass="pagination-ys" Width="100%" OnRowCommand="gvFAQDetail_RowCommand" OnRowEditing="gvFAQDetail_RowEditing">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Action" HeaderStyle-Width="15px">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnEdit" AlternateText="Edit" CommandName="Edit" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                            ImageUrl="../assets/images/Edit.svg" runat="server" Height="20px" />
                                                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:ImageButton ID="btndel" AlternateText="Delete"  CommandName="Del" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                            ImageUrl="../assets/images/trash-solid.svg" OnClientClick="return confirm('Are you sure you want to delete this event?');" runat="server" Height="20px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Question">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID" runat="server" Visible="false" Text='<%# Eval("FAQID") %>'></asp:Label>
                                                        <asp:Label ID="lblFAQname" runat="server" Text='<%# Eval("FAQName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                 <asp:TemplateField HeaderText="Answer" Visible="false">
                                                    <ItemTemplate>
                                                      
                                                        <asp:Label ID="lblFAQans" runat="server" Text='<%# Eval("FAQAnswer") %>'></asp:Label>
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
                        <asp:HiddenField ID="hdnFQ" runat="server" />
                    </div>
                </div>
            </div>
        <div class="col-md-12" runat="server" id="divFields" visible="false">
            <div class="card">
                <div class="card-body">
                    <div class="">
                        <h5 class="card-title">Add FAQ Details</h5>
                    </div>
                    <div class="row">
                        <div class="col-lg-9">
                            <div class="form-group">
                                <label>Queston</label>

                                <asp:TextBox ID="txtQue" AutoComplete="false" runat="server" CssClass="form-control"></asp:TextBox>
                          <%--      <asp:RequiredFieldValidator ID="RFV56" ErrorMessage="Please Enter Question" Display="None"
                                    ControlToValidate="txtQue" runat="server" ValidationGroup="btnsrv"> </asp:RequiredFieldValidator>--%>
                            </div>

                              <div class="form-group">
                                <label>Answer</label>

                                <asp:TextBox ID="txtAns" AutoComplete="false" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                  <script type="text/javascript" lang="javascript">
                            CKEDITOR.replace('<%=txtAns.ClientID%>');
                                  </script>
                        <span id="ansSpan"></span>
                           <%--     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Please Enter Answer" Display="None"
                                    ControlToValidate="txtAns" runat="server" ValidationGroup="btnsrv"> </asp:RequiredFieldValidator>--%>
                            </div>

                            <div class="form-group">
                                <label>Status</label>
                                <asp:RadioButtonList ID="rdbStatus" runat="server" Width="30%" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1" Text="Active" Selected="True"> </asp:ListItem>
                                    <asp:ListItem Value="0" Text="De-Active"></asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ErrorMessage="Please Select Status." Display="None"
                                    ControlToValidate="rdbStatus" runat="server" ValidationGroup="btnsrv"> </asp:RequiredFieldValidator>
                            </div>
                            <div class="text-end" style="float: right">
                                <asp:Button ID="btnSaveFAQ" runat="server" Text="Save" CssClass="btn btn-primary me-2" OnClick="btnSaveFAQ_Click" OnClientClick=" return validate()"/>
                                   <asp:Button ID="btnclose" runat="server" Text="Close" CssClass="btn btn-default" OnClick="btnclose_Click" />
                              <%--  <asp:ValidationSummary ForeColor="Red" runat="server" ID="validationSummary4" DisplayMode="BulletList"
                                    ShowMessageBox="true" ShowSummary="false" EnableClientScript="true" ValidationGroup="btnsrv"></asp:ValidationSummary>--%>
                            </div>
                        </div>
                    </div>

                </div>
            </div>

        </div>
    </div>
</asp:Content>
