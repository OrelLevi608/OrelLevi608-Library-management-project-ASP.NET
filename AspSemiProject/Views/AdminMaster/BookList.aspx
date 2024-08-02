<%@ Page Title="" Language="C#" MasterPageFile="~/Views/AdminMaster/BackAdmin.Master" AutoEventWireup="true" CodeBehind="BookList.aspx.cs" Inherits="AspSemiProject.Views.AdminMaster.BookList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/dataTables.bootstrap4.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
    <h1 class="mb-2 page-title">רשימת ספרים</h1>
    <div class="card shadow">
        <div class="card-body">
            <!-- table -->
            <table class="table datatables" id="MainTbl">
                <thead>
                    <tr>
                        <th>קוד ספר</th>
                        <th>שם ספר</th>
                        <th>מחבר</th>
                        <th>תיאור</th>
                        <th>תמונה</th>
                        <th>ISBN</th>
                        <th>קטגוריה</th>
                        <th>עותקים</th>
                        <th>עותקים במלאי</th>
                        <th>ימי השאלה</th>
                        <th>תאריך הוספה</th>
                        <th>פעולות</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="RptBook" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("BId") %></td>
                                <td><%#Eval("BTitle") %></td>
                                <td><%#Eval("BAuthor") %></td>
                                <td><%#Eval("BDesc") %></td>
                                <td class="center"><img src="/Uploads/Book/<%#Eval("BPicName") %>" width="30" /></td>
                                <td><%#Eval("ISBN") %></td>
                                <td><%#Eval("CatName") %></td>
                                <td><%#Eval("Copies") %></td>
                                <td><%#Eval("CopiesInStock") %></td>
                                <td><%#Eval("MaxLoan") %></td>
                                <td><%#Eval("AddDate") %></td>
                                <td class="center"><a href="BookAddEdit.aspx?BId=<%#Eval("BId") %>">ערוך <span class="fe fe-edit-3 fe-16"></span></a></td>
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