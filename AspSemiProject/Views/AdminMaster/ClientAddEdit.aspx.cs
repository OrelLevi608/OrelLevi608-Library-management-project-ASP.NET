using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspSemiProject.Views.AdminMaster
{
    public partial class ClientAddEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ClientId = Request["ClientId"] + "";
                if (string.IsNullOrEmpty(ClientId))
                {
                    ClientId = "-1";
                }
                BtnDelete.Visible = ClientId != "-1";
                PassPanel.Visible = ClientId == "-1";
                ImgPanel.Visible = ClientId != "-1";
                FillData(ClientId);
            }
        }
        public void FillData(string ClientId)
        {
            Client Tmp = null;
            if (string.IsNullOrEmpty(ClientId))
            {
                ClientId = "-1";
            }
            else
            {
                Tmp = Client.GetById(int.Parse(ClientId));  
                if(Tmp == null)
                {
                    ClientId = "-1";
                }
            }
            HidClientId.Value = ClientId;
            DDLCity.DataSource = City.GetAll();
            DDLCity.DataTextField = "CityName";
            DDLCity.DataValueField = "CityId";
            DDLCity.DataBind();
            DDLCity.Items.Insert(0, "בחר עיר");

            DDLStatus.DataSource = Status.GetAll();
            DDLStatus.DataTextField = "StatusName";
            DDLStatus.DataValueField = "StatusId";
            DDLStatus.DataBind();
            DDLStatus.Items.Insert(0, "בחר סטטוס");

            if(Tmp != null)
            {
                TxtFname.Text = Tmp.Fname;
                TxtLname.Text = Tmp.Lname;
                TxtID.Text = Tmp.ID.ToString();
                DDLCity.SelectedValue = Tmp.CityId+"";
                TxtPhone.Text = Tmp.Phone;
                TxtEmail.Text = Tmp.Email;
                TxtPassword.Text = Tmp.Password;
                PicName.ImageUrl = "/Uploads/Client/" + Tmp.PicName;
                DDLStatus.SelectedValue = Tmp.StatusId + "";
                TxtSubscriptionEndDate.Text = Tmp.SubscriptionEndDate.ToString("yyyy-MM-dd");
                HidClientId.Value = ClientId; // בשדה נסתר ID אחסון המשתנה לפי מספר ה
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string Picname = "";
            if (UploadPic.HasFile)
            {
                Picname = GlobFunc.GetRandStr(8);
                string OriginFileName = UploadPic.FileName;
                int index = OriginFileName.LastIndexOf('.');
                string Ext = OriginFileName.Substring(index);
                Picname += Ext;
                string FullPath = Server.MapPath("/Uploads/Client/");
                UploadPic.SaveAs(FullPath + Picname);
            }
            else
            {
                Picname = PicName.ImageUrl.Substring(PicName.ImageUrl.LastIndexOf('/') + 1);
            }
            Client Tmp = new Client() 
            {
                ClientId = int.Parse(HidClientId.Value),
                Fname = TxtFname.Text,
                Lname = TxtLname.Text,
                ID = int.Parse(TxtID.Text),
                CityId = int.Parse(DDLCity.SelectedValue),
                Phone = TxtPhone.Text,
                Email = TxtEmail.Text,
                Password = TxtPassword.Text,
                PicName = Picname,
                StatusId = int.Parse(DDLStatus.SelectedValue),
                SubscriptionEndDate = DateTime.Parse(TxtSubscriptionEndDate.Text), // תאריך סיום המנוי
            };
            Tmp.Save();
            Application["Client"] = Client.GetAll();
            Response.Redirect("ClientList.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            int clientid = int.Parse(HidClientId.Value);
            Client.Delete(clientid);
            Application["Client"] = Client.GetAll();
            Response.Redirect("ClientList.aspx");
        }
    }
}