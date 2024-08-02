using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace AspSemiProject.Views.StartApp
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogIn_Click(object sender, EventArgs e)
        {
            string email = TxtEmail.Text; // קליטת הטקסט מהתיבה
            string password = TxtPassword.Text; // קליטת הטקסט מהתיבה
            List<Admins> LstAdmin = (List<Admins>)Application["Admins"];
            
            for(int i = 0; i < LstAdmin.Count; i++)  // לולאה שעוברת על כל המנהלים ברשימה
            {
                if (LstAdmin[i].Email == email && LstAdmin[i].Password == password)
                {
                    Session["AdminSession"] = LstAdmin[i]; // שמירה המנהל המחובר סשן
                    Response.Redirect("../AdminMaster/Default.aspx");
                }
            }
            LtlMsg.Text = "Wrog Email or Password"; // הצגת הודעה במקרה של פרטי התחברות לא נכנוים
        }
    }
}