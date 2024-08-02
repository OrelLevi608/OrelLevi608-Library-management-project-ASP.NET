<%@ Page Title="" Language="C#" MasterPageFile="~/Views/AdminMaster/BackAdmin.Master" AutoEventWireup="true" CodeBehind="ClientAddEdit.aspx.cs" Inherits="AspSemiProject.Views.AdminMaster.ClientAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
    <div class="col-md-12">
        <div class="card shadow mb-4">
            <div class="card-header">
                <strong class="card-title">הוספה/מחיקה של לקוח</strong>
            </div>
            <div class="card-body">
                <div class="form-row">
                    <div class="col-md-6 mb-3">
                        <asp:HiddenField ID="HidClientId" runat="server" Value="-1" />
                        <label for="TxtFname">שם לקוח</label>
                        <asp:TextBox ID="TxtFname" runat="server" class="form-control" placeholder="נא הזן שם לקוח" />
                    </div>
                    <div class="col-md-6 mb-3">
                        <label for="TxtLname">שם משפחה</label>
                        <asp:TextBox ID="TxtLname" runat="server" class="form-control" placeholder="נא הזן שם משפחה" />
                    </div>
                    <div class="col-md-6 mb-3">
                        <label for="TxtID">מספר זהות</label>
                        <asp:TextBox ID="TxtID" runat="server" class="form-control" placeholder="נא הזן מספר זהות" />
                    </div>
                        <div class="col-md-6 mb-3">
                            <label for="DDLCity">עיר</label>
                            <asp:DropDownList ID="DDLCity" runat="server" class="form-control" />
                        </div>
                        <div class="col-md-6 mb-3">
                            <label for="TxtPhone">טלפון</label>
                            <asp:TextBox ID="TxtPhone" runat="server" class="form-control" placeholder="נא הזן מספר טלפון" />
                        </div>
                        <div class="col-md-6 mb-3">
                            <label for="TxtEmail">דואר אלקטרוני</label>
                            <asp:TextBox ID="TxtEmail" runat="server" class="form-control" placeholder="נא הזן דואר אלקטרוני" />
                        </div>
                        <asp:Panel ID="PassPanel" runat="server">
                            <div class="col-md-12 mb-3">
                                <label for="TxtPassword">סיסמה</label>
                                <asp:TextBox ID="TxtPassword" runat="server" class="form-control" TextMode="Password" placeholder="נא הזן סיסמה" />
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="ImgPanel" runat="server">
                            <div class="col-md-12 mb-3">
                                <asp:Image ID="PicName" Class="form-control" runat="server" Width="200" Height="175" />
                            </div>
                        </asp:Panel>
                    <br />
                        <div class="col-md-12 mb-3">
                            <label>תמונה</label>
                            <asp:FileUpload ID="UploadPic" Class="form-control" runat="server" />
                        </div>
                        <div class="col-md-6 mb-3">
                            <label for="DDLStatus">סטטוס</label>
                            <asp:DropDownList ID="DDLStatus" runat="server" class="form-control" />
                        </div>
                        <div class="col-md-6 mb-3">
                            <label for="TxtSubscriptionEndDate">תאריך סוף מנוי</label>
                            <asp:TextBox ID="TxtSubscriptionEndDate" runat="server" class="form-control" TextMode="Date" />
                        </div>
                        <div class="col-md-12 mb-3">
                            <asp:Button ID="BtnSave" runat="server" class="btn btn-success" OnClick="BtnSave_Click" Text="שמירה" />
                            <asp:Button ID="BtnDelete" runat="server" class="btn btn-danger" OnClick="BtnDelete_Click" Text="מחיקה" />
                        </div>

                </div>
            </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="UnderFooter" runat="server">
</asp:Content>
