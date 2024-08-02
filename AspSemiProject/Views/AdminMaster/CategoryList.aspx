<%@ Page Title="" Language="C#" MasterPageFile="~/Views/AdminMaster/BackAdmin.Master" AutoEventWireup="true" CodeBehind="CategoryList.aspx.cs" Inherits="AspSemiProject.Views.AdminMaster.CategoryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/dataTables.bootstrap4.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
    <h1 class="mb-2 page-title">רשימת קטגוריות</h1>
    <div class="card shadow">
        <div class="card-body">
            <!-- table -->
            <table class="table datatables" id="MainTbl">
                <thead>
                    <tr>
                        <th>קוד קטגוריה</th>
                        <th>שם קטגוריה</th>
                        <th>תיאור</th>
                        <th>תמונה</th>
                        <th>תאריך הוספה</th>
                        <th>פעולות</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="RptCat" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("CatId") %></td>
                                <td><%#Eval("CatName") %></td>
                                <td><%#Eval("CatDesc") %></td>
                                <td class="center"><img src="/Uploads/Category/<%#Eval("PicName") %>" width="30" /></td>
                                <td><%#Eval("AddDate") %></td>
                                <td class="center"><a href="CategoryAddEdit.aspx?CatId=<%#Eval("CatId") %>">ערוך <span class="fe fe-edit-3 fe-16"></span></a></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
    <script src='js/jquery.dataTables.min.js'></script>
    <script src='js/dataTables.bootstrap4.min.js'></script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="UnderFooter" runat="server">
    <script>
        $('#MainTbl').DataTable(
            {
                autoWidth: true,
                "lengthMenu": [
                    [16, 32, 64, -1],
                    [16, 32, 64, "All"]
                ],
                language: {
                    url: '//cdn.datatables.net/plug-ins/2.1.2/i18n/he.json'
                }
            });
    </script>
</asp:Content>