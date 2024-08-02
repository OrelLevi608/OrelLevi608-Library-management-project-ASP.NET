using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspSemiProject.Views.AdminMaster
{
    public partial class CategoryAddEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string CatId = Request["CatId"] + "";
                if (string.IsNullOrEmpty(CatId))
                {
                    CatId = "-1";
                }
                BtnDelete.Visible = CatId != "-1";
                PicPanel.Visible = CatId != "-1";
                FillData(CatId);
            }
            
        }
        public void FillData(string CatId)
        {
            Category Tmp = null;
            if (string.IsNullOrEmpty(CatId))
            {
                CatId = "-1";
            }
            else
            {
                Tmp = Category.GetById(int.Parse(CatId));
                if(Tmp == null )
                {
                    CatId = "-1";
                }
            }
            if(Tmp !=null)
            {
                TxtCatName.Text = Tmp.CatName;
                TxtCatDesc.Text = Tmp.CatDesc;
                CatImg.ImageUrl = "/Uploads/Category/" + Tmp.PicName;
                HidCatId.Value = CatId;
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
                string FullPath = Server.MapPath("/Uploads/Category/");
                UploadPic.SaveAs(FullPath + Picname);
            }
            else
            {
                Picname = CatImg.ImageUrl.Substring(CatImg.ImageUrl.LastIndexOf('/') + 1);
            }
            Category Tmp = new Category() 
            {
                CatId = int.Parse(HidCatId.Value),
                CatName = TxtCatName.Text,
                CatDesc = TxtCatDesc.Text,
                PicName = Picname,
            };
            Tmp.Save();
            Application["Category"] = Category.GetAll();
            Response.Redirect("CategoryList.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            if (HidCatId.Value != "-1")
            {
                int CatId = int.Parse(HidCatId.Value);
                Admins.Delete(CatId);
                Application["Category"] = Category.GetAll();
                Response.Redirect("CategoryList.aspx");
            }
        }
    }
}