﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/AdminMaster/BackAdmin.Master" AutoEventWireup="true" CodeBehind="CityAddEdit.aspx.cs" Inherits="AspSemiProject.Views.AdminMaster.CityAddEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
    <div class="col-md-12">
        <div class="card shadow mb-4">
            <div class="card-header">
                <strong class="card-title">הוספה/מחיקה עיר</strong>
            </div>
            <div class="card-body">
                <div class="form-row">
                    <div class="col-md-12 mb-3">
                        <asp:HiddenField ID="HidCityId" runat="server" Value="-1" />
                        <label for="TxtCityName">שם עיר</label>
                        <asp:TextBox ID="TxtCityName" runat="server" class="form-control" placeholder="נא הזן שם עיר" />
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