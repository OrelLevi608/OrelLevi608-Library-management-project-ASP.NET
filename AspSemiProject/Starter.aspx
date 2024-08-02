<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Starter.aspx.cs" Inherits="AspSemiProject.Starter" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Library Project</title>
    <link rel='stylesheet' href='https://unpkg.com/@master/normal.css'>
</head>
<body>
    <img class="abs block w:full h:full left:0 top:0 object:cover pointer-events:none" src="https://wallpaper.forfun.com/fetch/64/645d7ccf870e16b0bc908b2dabdd6f8c.jpeg">
    <div class="abs block w:full h:full left:0 top:0 bg:radial-gradient(circle,rgba(0,0,0,.6)0%,rgba(0,0,0,0)100%)"></div>
    <div class="abs inset:0 h:fit m:auto font:white rel max-width:600 d:flex flex:col gap:10 p:50">
        <div class="d:flex bg:black/.3 b:1;solid;white/.1 p:10 r:10 bd:blur(30)">
            <div class="p:15">
                <div class="text:24 font:bold">הפרויקט הוא מערכת לניהול השאלות ספרים, שנבנתה ב-ASP.NET, המאפשרת למנהלים לנהל ספרים, קטגוריות, לקוחות והשאלות בצורה נוחה. המערכת כוללת שכבה עסקית לגישה לנתונים, ממשק משתמש קל לשימוש וממשק לניהול הרשאות משתמשים.</div>
                <div class="text:14 font:gray-20 lines:3 mt:8 mb:10">
                   ☻</div>
            </div>
            <img class="aspect:1/1 w:150 r:5 object:cover"
                src="https://images7.alphacoders.com/133/1338193.png">
        </div>
        <button class="bg:black/.3 bg:black/.15:hover ls:2 p:15 b:1;solid;white/.1 r:10 inline-block font:semibold bd:blur(30) font:14" onclick="window.location.href='/Views/AdminMaster/Default.aspx';">
            ENTER
        </button>
        <p class="font:12 text:center">
            
        </p>
    </div>
    <!-- partial -->
    <script src='https://cdn.jsdelivr.net/npm/@master/style'></script>
    <script src='https://cdn.jsdelivr.net/npm/@master/styles'></script>
</body>
</html>
