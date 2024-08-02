using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspSemiProject.Views.AdminMaster
{
    public partial class StatusAddEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                string StatusId = Request["StatusId"] + "";
                if (string.IsNullOrEmpty(StatusId))
                {
                    StatusId = "-1";
                }
                BtnDelete.Visible = StatusId != "-1";
                FillData(StatusId);
            }
            
        }
        
        public void FillData(string StatusId)
        {
            Status Tmp = null;
            if(string.IsNullOrEmpty(StatusId))
            {
                StatusId = "-1";
            }
            else
            {
                Tmp = Status.GetById(int.Parse(StatusId));
                if(Tmp == null ) 
                {
                    StatusId = "-1";
                }
            }
            if( Tmp != null)
            {
                TxtStatusName.Text = Tmp.StatusName;
                TxtStatusDesc.Text = Tmp.StatusDesc;
                HidStatusId.Value = StatusId;
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            Status Tmp = new Status() 
            {
                StatusId = int.Parse(HidStatusId.Value),
                StatusName = TxtStatusName.Text,
                StatusDesc = TxtStatusDesc.Text,
            };
            Tmp.Save();
            Application["Status"] = Status.GetAll();
            Response.Redirect("StatusList.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            if (HidStatusId.Value != "-1")
            {
                int StatusId = int.Parse(HidStatusId.Value);
                Admins.Delete(StatusId);
                Application["Status"] = Status.GetAll();
                Response.Redirect("StatusList.aspx");
            }
        }
    }
}