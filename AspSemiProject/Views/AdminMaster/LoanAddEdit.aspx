<%@ Page Title="" Language="C#" MasterPageFile="~/Views/AdminMaster/BackAdmin.Master" AutoEventWireup="true" CodeBehind="LoanAddEdit.aspx.cs" Inherits="AspSemiProject.Views.AdminMaster.LoanAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
    <div class="col-md-12">
        <div class="card shadow mb-4">
            <div class="card-header">
                <strong class="card-title">הוספה/מחיקה של השאלה</strong>
            </div>
            <div class="card-body">
                <div class="form-row">
                    <div class="col-md-6 mb-3">
                        <asp:HiddenField ID="HidLoanId" runat="server" Value="-1" />
                        <label for="DDLClient">לקוח</label>
                        <asp:DropDownList ID="DDLClient" runat="server" class="form-control" />
                    </div>
                    <div class="col-md-6 mb-3">
                        <label for="DDLBook">ספר</label>
                        <asp:DropDownList ID="DDLBook" runat="server" class="form-control" />
                    </div>
                    <div class="col-md-6 mb-3">
                        <label for="TxtLoanDate">תאריך השאלה</label>
                        <asp:TextBox ID="TxtLoanDate" runat="server" class="form-control" TextMode="Date" />
                    </div>
                    <div class="col-md-6 mb-3">
                        <label for="TxtActualReturnDate">תאריך החזרה מעודכן</label>
                        <asp:TextBox ID="TxtActualReturnDate" runat="server" class="form-control" TextMode="Date" />
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
