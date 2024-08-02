using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspSemiProject.Views.AdminMaster
{
    public partial class AdminList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillData(); 
            }
        }
        public void FillData() // פונקציות לטעינת הנתונים ברשימת המנהלים
        {
            RptAdmin.DataSource = Admins.GetAll();
            RptAdmin.DataBind();
        }
    }
}