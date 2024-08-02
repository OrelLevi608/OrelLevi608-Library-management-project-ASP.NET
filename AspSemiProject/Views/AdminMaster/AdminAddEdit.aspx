<%@ Page Title="" Language="C#" MasterPageFile="~/Views/AdminMaster/BackAdmin.Master" AutoEventWireup="true" CodeBehind="AdminAddEdit.aspx.cs" Inherits="AspSemiProject.Views.AdminMaster.AdminAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
    <div class="col-md-12">
        <div class="card shadow mb-4">
            <div class="card-header">
                <strong class="card-title">הוספה/מחיקה של מנהל</strong>
            </div>
            <div class="card-body">
                <div class="form-row">
                    <div class="col-md-6 mb-3">
                        <asp:HiddenField ID="HidAId" runat="server" Value="-1" />
                        <label for="TxtAName">שם מנהל</label>
                        <asp:TextBox ID="TxtAName" runat="server" class="form-control" placeholder="נא הזן שם מנהל" />
                    </div>
                    <div class="col-md-6 mb-3">
                        <label for="TxtALastName">שם משפחה</label>
                        <asp:TextBox ID="TxtALastName" runat="server" class="form-control" placeholder="נא הזן שם משפחה" />
                    </div>
                    <div class="col-md-6 mb-3">
                        <label for="TxtEmail">דואר אלקטרוני</label>
                        <asp:TextBox ID="TxtEmail" runat="server" class="form-control" placeholder="נא הזן דואר אלקטרוני" />
                    </div>
                    <asp:Panel ID="PasswordPanel" runat="server">
                    <div class="col-md-12 mb-3">
                        <label for="TxtPassword">סיסמה</label>
                        <asp:TextBox ID="TxtPassword" runat="server" class="form-control" TextMode="Password" placeholder="נא הזן סיסמה" />
                    </div>
                    </asp:Panel>
                    <asp:Panel ID="PicPanel" runat="server">
                        <div class="col-md-12 mb-3">
                            <asp:Image ID="ImgProfile" Class="form-control" runat="server" Width="200" Height="175" />
                        </div>
                    </asp:Panel>
                    <div class="col-md-12 mb-3">
                        <label>תמונת פרופיל</label>
                        <asp:FileUpload ID="UploadPic" runat="server" />
                    </div>
                    <div class="col-md-12 mb-3">
                        <asp:Button ID="BtnSave" runat="server" class="btn btn-success" OnClick="BtnSave_Click" Text="שמירה" />
                        <asp:Button ID="BtnDelete" runat="server" class="btn btn-danger" OnClick="BtnDelete_Click" Text="מחיקה" />
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="UnderFooter" runat="server">
</asp:Content>
