<%@ Page Title="" Language="C#" MasterPageFile="~/Views/AdminMaster/BackAdmin.Master" AutoEventWireup="true" CodeBehind="BookAddEdit.aspx.cs" Inherits="AspSemiProject.Views.AdminMaster.BookAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
    <div class="col-md-12">
        <div class="card shadow mb-4">
            <div class="card-header">
                <strong class="card-title">הוספה/מחיקה של ספר</strong>
            </div>
            <div class="card-body">
                <div class="form-row">
                    <div class="col-md-6 mb-3">
                        <asp:HiddenField ID="HidBId" runat="server" Value="-1" />
                        <label for="TxtBTitle">שם ספר</label>
                        <asp:TextBox ID="TxtBTitle" runat="server" class="form-control" placeholder="נא הזן שם ספר" />
                    </div>
                    <div class="col-md-6 mb-3">
                        <label for="TxtBAuthor">מחבר</label>
                        <asp:TextBox ID="TxtBAuthor" runat="server" class="form-control" placeholder="נא הזן שם מחבר" />
                    </div>
                    <div class="col-md-12 mb-3">
                        <label for="TxtBDesc">על הספר</label>
                        <asp:TextBox ID="TxtBDesc" runat="server" class="form-control" TextMode="MultiLine" Rows="10" Columns="40" placeholder="נא הזן תיאור" />
                    </div>
                    <asp:Panel ID="ImgPanel" runat="server">
                        <div class="col-md-12 mb-3">
                            <asp:Image ID="ImgCover" Class="form-control" runat="server" Width="200" Height="175" />
                        </div>
                    </asp:Panel>
                    <div class="col-md-12 mb-3">
                        <label>תמונה</label>
                        <asp:FileUpload ID="UploadPic" Class="form-control" runat="server" />
                    </div>
                    <div class="col-md-6 mb-3">
                        <label for="TxtISBN">ISBN</label>
                        <asp:TextBox ID="TxtISBN" runat="server" class="form-control" placeholder="נא הזן ISBN" />
                    </div>
                    <div class="col-md-6 mb-3">
                        <label for="DDLCategory">קטגוריה</label>
                        <asp:DropDownList ID="DDLCategory" runat="server" class="form-control" />
                    </div>
                    <div class="col-md-6 mb-3">
                        <label for="TxtCopies">עותקים</label>
                        <asp:TextBox ID="TxtCopies" runat="server" class="form-control" placeholder="הזן מספר עותקים" />
                    </div>
                    <div class="col-md-6 mb-3">
                        <label for="TxtCopiesInStock">עותקים במלאי</label>
                        <asp:TextBox ID="TxtCopiesInStock" runat="server" class="form-control" placeholder="הזן מספר עותקים במלאי" />
                    </div>
                    <div class="col-md-6 mb-3">
                        <label for="TxtMaxLoan">מקסימום ימי השאלה</label>
                        <asp:TextBox ID="TxtMaxLoan" runat="server" class="form-control" placeholder="הזן מקסימום ימי השאלה" />
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

