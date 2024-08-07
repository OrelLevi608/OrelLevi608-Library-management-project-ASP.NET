﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/AdminMaster/BackAdmin.Master" AutoEventWireup="true" CodeBehind="CategoryAddEdit.aspx.cs" Inherits="AspSemiProject.Views.AdminMaster.CategoryAddEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
    <div class="col-md-12">
        <div class="card shadow mb-4">
            <div class="card-header">
                <strong class="card-title">הוספה/מחיקה קטגוריה</strong>
            </div>
            <div class="card-body">
                <div class="form-row">
                    <div class="col-md-12 mb-3">
                        <asp:HiddenField ID="HidCatId" runat="server" Value="-1" />
                        <label for="TxtCatName">שם קטגוריה</label>
                        <asp:TextBox ID="TxtCatName" runat="server" class="form-control" placeholder="נא הזן שם קטגוריה" />
                    </div>
                    <div class="col-md-12 mb-3">
                        <label for="TxtCatDesc">פרטי קטגוריה</label>
                        <asp:TextBox ID="TxtCatDesc" runat="server" class="form-control" TextMode="MultiLine" Rows="10" Columns="40" placeholder="נא הזן פרטי קטגוריה" />
                    </div>
                    <asp:Panel ID="PicPanel" runat="server">
                        <div class="col-md-12 mb-3">
                            <asp:Image ID="CatImg" Class="form-control" runat="server" Width="200" Height="175" />
                        </div>
                    </asp:Panel>
                    <div class="col-md-12 mb-3">
                        <label>תמונת קטגוריה</label>
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