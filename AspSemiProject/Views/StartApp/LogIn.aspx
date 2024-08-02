<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="AspSemiProject.Views.StartApp.LogIn" %>

<!DOCTYPE html>

<html dir="rtl" lang="en">
<head runat="server">
 <meta charset="utf-8">
 <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
 <meta name="description" content="">
 <meta name="author" content="">
 <link rel="icon" href="favicon.ico">
 <title>LogIn LMS</title>
 <!-- Simple bar CSS -->
 <link rel="stylesheet" href="../AdminMaster/css/simplebar.css">
 <!-- Fonts CSS -->
 <link href="https://fonts.googleapis.com/css2?family=Overpass:ital,wght@0,100;0,200;0,300;0,400;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,600;1,700;1,800;1,900&display=swap" rel="stylesheet">
 <!-- Icons CSS -->
 <link rel="stylesheet" href="../AdminMaster/css/feather.css">
 <!-- Date Range Picker CSS -->
 <link rel="stylesheet" href="../AdminMaster/css/daterangepicker.css">
 <!-- App CSS -->
 <link rel="stylesheet" href="../AdminMaster/css/app-light.css" id="lightTheme" disabled>
 <link rel="stylesheet" href="../AdminMaster/css/app-dark.css" id="darkTheme">
</head>
<body class="dark rtl">
        <div class="wrapper vh-100">
  <div class="row align-items-center h-100">
    <form class="col-lg-3 col-md-4 col-10 mx-auto text-center" runat="server">
      <a class="navbar-brand mx-auto mt-2 flex-fill text-center" href="./index.html">
        <svg version="1.1" id="logo" class="navbar-brand-img brand-md" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" viewBox="0 0 240 240" xml:space="preserve">
          <image href="https://fusionauth.io/img/blogs/core-identity-considered-harmful/asp.net-core-considered-harmful.svg" x="0" y="0" height="240" width="240" />
        </svg>
      </a>
      <h1 class="h6 mb-3">התחברות</h1>
      <div class="form-group">
        <label for="TxtEmail" class="sr-only">דואר אלקטרוני</label>
          <asp:TextBox ID="TxtEmail" runat="server" class="form-control form-control-lg" placeholder="נא הזן דואר אלקטרוני" />
      </div>
      <div class="form-group">
        <label for="TxtPassword" class="sr-only">סיסמה</label>        
      <asp:TextBox ID="TxtPassword" runat="server" class="form-control form-control-lg" TextMode="Password" placeholder="נא הזן סיסמה" />
      </div>
         <asp:Button ID="BtnLogIn" runat="server" class="btn btn-lg btn-primary btn-block" OnClick="BtnLogIn_Click" Text="התחבר" />
        <asp:Literal ID="LtlMsg" runat="server" />    
    </form>
  </div>
</div>
<script src="../AdminMaster/js/jquery.min.js"></script>
<script src="../AdminMaster/js/popper.min.js"></script>
<script src="../AdminMaster/js/moment.min.js"></script>
<script src="../AdminMaster/js/bootstrap.min.js"></script>
<script src="../AdminMaster/js/simplebar.min.js"></script>
<script src='../AdminMaster/js/daterangepicker.js'></script>
<script src='../AdminMaster/js/jquery.stickOnScroll.js'></script>
<script src="../AdminMaster/js/tinycolor-min.js"></script>
<script src="../AdminMaster/js/config.js"></script>
<script src="../AdminMaster/js/apps.js"></script>
</body>
</html>
