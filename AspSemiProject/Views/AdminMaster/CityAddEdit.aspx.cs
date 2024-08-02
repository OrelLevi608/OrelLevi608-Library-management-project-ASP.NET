using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspSemiProject.Views.AdminMaster
{
    public partial class CityAddEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string CityId = Request["CityId"] + "";
                if (string.IsNullOrEmpty(CityId))
                {
                    CityId = "-1";
                }
                BtnDelete.Visible = CityId != "-1";
                FillData(CityId);
            }
            
        }
        public void FillData(string CityId)
        {
            City Tmp = null;
            if(string.IsNullOrEmpty(CityId) )
            {
                CityId = "-1";
            }
            else
            {
                Tmp= City.GetById(int.Parse(CityId));
                if( Tmp == null )
                {
                    CityId = "-1";
                }
            }
            if(Tmp != null)
            {
                TxtCityName.Text = Tmp.CityName;
                HidCityId.Value = CityId;
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            City Tmp = new City() 
            {
                CityId = int.Parse(HidCityId.Value),
                CityName = TxtCityName.Text,
            };
            Tmp.Save();
            Application["City"] = City.GetAll(); // עדכון הרשימה בקבוץ גלובל של הערים
            Response.Redirect("CityList.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            if (HidCityId.Value != "-1")
            {
                int CityId = int.Parse(HidCityId.Value);
                Admins.Delete(CityId);
                Application["City"] = City.GetAll();
                Response.Redirect("CityList.aspx");
            }
        }
    }
}