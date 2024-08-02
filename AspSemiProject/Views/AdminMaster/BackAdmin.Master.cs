using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspSemiProject.Views.AdminMaster
{
    public partial class BackAdmin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminSession"] == null)  // Session בדיקה אם אין נתונים 
            {
                Response.Redirect("~/Views/StartApp/LogIn.aspx"); // מעבר המשתמש לדף התחברות אם אין נתונים
            }
            else
            {
                var admin = (Admins)Session["AdminSession"];  // Admins הנתונים מומרת לאובייקט מסוג  Session אם יש נתונים במשתנה
                imgProfile.ImageUrl = $"~/Uploads/Admin/{admin.APicName}";  // עדכון כתובת התמונה של פרופיל המנהל
            }
        }
    }
}