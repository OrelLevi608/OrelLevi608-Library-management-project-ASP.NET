<%@ Page Title="" Language="C#" MasterPageFile="~/Views/AdminMaster/BackAdmin.Master" AutoEventWireup="true" CodeBehind="ClientList.aspx.cs" Inherits="AspSemiProject.Views.AdminMaster.ClientList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/dataTables.bootstrap4.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
    <h1 class="mb-2 page-title">רשימת לקוחות</h1>
    <div class="card shadow">
        <div class="card-body">
            <!-- table -->
            <table class="table datatables" id="MainTbl">
                <thead>
                    <tr>
                        <th>קוד לקוח</th>
                        <th>שם לקוח</th>
                        <th>שם משפחה</th>
                        <th>מס זהות</th>
                        <th>עיר</th>
                        <th>טלפון</th>
                        <th>דואר אלקטרוני</th>
                        <th>תמונת פרופיל</th>
                        <th>סטטוס</th>
                        <th>תאריך הוספה</th>
                        <th>תאריך סוף מנוי</th>
                        <th>פעולות</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="RptClient" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("ClientId") %></td>
                                <td><%#Eval("Fname") %></td>
                                <td><%#Eval("Lname") %></td>
                                <td><%#Eval("ID") %></td>
                                <td><%#Eval("CityName") %></td>
                                <td><%#Eval("Phone") %></td>
                                <td><%#Eval("Email") %></td>
                                <td class="avatar avatar-md"><img src="/Uploads/Client/<%#Eval("PicName") %>" class="avatar-img rounded-circle" width="30" /></td>
                                <td><%#Eval("StatusName") %></td>
                                <td><%#Eval("AddDate") %></td>
                                <td><%#Eval("SubscriptionEndDate") %></td>
                                <td class="center"><a href="ClientAddEdit.aspx?ClientId=<%#Eval("ClientId") %>">ערוך <span class="fe fe-edit-3 fe-16"></span></a></td>
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