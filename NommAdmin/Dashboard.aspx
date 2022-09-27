<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="NommAdmin.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="row">
            <div class="col-md-12 grid-margin transparent">
                <div class="row">
                    <div class="col-md-3 mb-4 stretch-card transparent">
                        <div class="card card-dark-blue">
                            <div class="card-body">
                                <p class="mb-4">Total Category</p>
                                <p class="fs-30 mb-2">
                                    <asp:Label ID="lbltotcat" runat="server" Text=""></asp:Label>
                       <%--<img src="assets/chef.png" />--%>
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3 mb-4 stretch-card transparent">
                        <div class="card card-dark-blue">
                            <div class="card-body">
                                <p class="mb-4">Total Service</p>
                                <p class="fs-30 mb-2">
                                    <asp:Label ID="lbltotSer" runat="server" Text=""></asp:Label>
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3 mb-4 stretch-card transparent">
                        <div class="card card-dark-blue">
                            <div class="card-body">
                                <p class="mb-4">Total Chef</p>
                                <p class="fs-30 mb-2">
                                    <asp:Label ID="lbltotChf" runat="server" Text=""></asp:Label>
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3 mb-4 stretch-card transparent">
                        <div class="card card-dark-blue">
                            <div class="card-body">
                                <p class="mb-4">Total FAQ</p>
                                <p class="fs-30 mb-2">
                                    <asp:Label ID="lbltotFaq" runat="server" Text=""></asp:Label>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
