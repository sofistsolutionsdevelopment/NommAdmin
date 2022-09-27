<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OMS.Login" %>

<!DOCTYPE html>

<html lang="en">

<head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <title>The Nommers</title>
    <!-- plugins:css -->
    <link rel="stylesheet" href="assets/vendors/feather/feather.css">
    <link rel="stylesheet" href="assets/vendors/ti-icons/css/themify-icons.css">
    <link rel="stylesheet" href="assets/vendors/css/vendor.bundle.base.css">
    <!-- endinject -->
    <!-- Plugin css for this page -->
    <!-- End plugin css for this page -->
    <!-- inject:css -->
    <link rel="stylesheet" href="assets/css/vertical-layout-light/style.css">
    <!-- endinject -->
    <link rel="shortcut icon" href="assets/images/MAFFF.png" />
    <link href="assets/SwalScripts/sweetalert.css" rel="stylesheet" />
    <script src="assets/SwalScripts/jquery-1.10.2.js"></script>
    <script src="assets/SwalScripts/sweetalert.js"></script>
</head>

<body>
    <div class="container-scroller">
        <div class="container-fluid page-body-wrapper full-page-wrapper">
            <div class="content-wrapper d-flex align-items-center auth px-0">
                <div class="row w-100 mx-0">
                    <div class="col-lg-4 mx-auto">
                        <div class="auth-form-light text-center py-5 px-4 px-sm-5">
                            <div class="brand-logo">
                                <img runat="server" src="~/assets/images/FInal Logo.png" alt="logo">
                            </div>

                            <form id="form1" runat="server" class="pt-3">
                                <div class="form-group">
                                    <asp:TextBox runat="server" autocomplete="Off" ID="txtLogin" placeholder="User Id" CssClass="form-control form-control-lg" required />
                                    <%-- <asp:RequiredFieldValidator ID="RFV1" ErrorMessage="Please Enter Login Id." Display="None"
                                        ControlToValidate="txtLogin" runat="server" ValidationGroup="btn">
                                    </asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox TextMode="password" autocomplete="Off" runat="server" ID="txtPassword" MaxLength="20" placeholder="Password" CssClass="form-control form-control-lg" required />
                                    <%-- <asp:RequiredFieldValidator ID="RFV2" ErrorMessage="Please Enter Password." Display="None"
                                        ControlToValidate="txtPassword" runat="server" ValidationGroup="btn">
                                    </asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="mt-3">
                                    <asp:Button runat="server" ID="btnLogin" Text="SIGN IN" ValidationGroup="btn"
                                        CssClass="btn btn-block btn-primary btn-lg font-weight-medium auth-form-btn" OnClick="btnLogin_Click" />
                                    <asp:ValidationSummary ForeColor="Red" runat="server" ID="validationSummary" DisplayMode="BulletList"
                                        ShowMessageBox="true" ShowSummary="false" EnableClientScript="true" ValidationGroup="btn"></asp:ValidationSummary>
                                </div>

                            </form>
                            <div class="my-2 justify-content-between text-right">
                                <a runat="server" href="~/ForgotPassword.aspx" class="auth-link text-black">Forgot password?</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- content-wrapper ends -->
        </div>
        <!-- page-body-wrapper ends -->
    </div>
    <!-- container-scroller -->
    <!-- plugins:js -->
    <script src="../../vendors/js/vendor.bundle.base.js"></script>
    <!-- endinject -->
    <!-- Plugin js for this page -->
    <!-- End plugin js for this page -->
    <!-- inject:js -->
    <script src="assets/js/off-canvas.js"></script>
    <script src="assets/js/hoverable-collapse.js"></script>
    <script src="assets/js/template.js"></script>
    <script src="assets/js/settings.js"></script>
    <script src="assets/js/todolist.js"></script>

    <%-- <script type="text/javascript">
        function erroralert() {
            swal({
                title: 'Error!',
                text: 'Invalid User Id Or Password',
                type: 'error'
            });
        }
    </script>--%>
    <!-- endinject -->
</body>

</html>


