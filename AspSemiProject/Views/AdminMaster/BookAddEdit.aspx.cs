using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace AspSemiProject.Views.AdminMaster
{
    public partial class BookAddEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string BId = Request["BId"] + "";
                if (string.IsNullOrEmpty(BId))
                {
                    BId = "-1";
                }
                BtnDelete.Visible = BId != "-1"; // -1 לא BId הצגת כפתור מחיקה רק אם
                ImgPanel.Visible = BId != "-1"; // -1 לא BId הצגת התמונה רק אם
                FillData(BId);
            }
        }
        public void FillData(string BId)
        {
            Book Tmp = null;
            if (string.IsNullOrEmpty(BId))
            {
                BId = "-1";
            }
            else
            {
                Tmp = Book.GetById(int.Parse(BId));
                if (Tmp == null)
                {
                    BId = "-1";
                }
            }
            HidBId.Value = BId; // הספר בשדה מוסתר ID שומר/מאחסן 
            DDLCategory.DataSource = Category.GetAll();
            DDLCategory.DataTextField = "CatName"; // הגדרת השדה שמוצג ברשימה (שם הקטגוריה)ה
            DDLCategory.DataValueField = "CatId"; // הגדרת השדה שמחזיק את הערך ברשימה (מזהה הקטגוריה)ס
            DDLCategory.DataBind();
            DDLCategory.Items.Insert(0, "בחר קטגוריה"); // הוספת אפשרות ברירת מחדל לרשימה הנפתחת

            if (Tmp != null)
            {
                TxtBTitle.Text = Tmp.BTitle;
                TxtBAuthor.Text = Tmp.BAuthor;
                TxtBDesc.Text = Tmp.BDesc;
                ImgCover.ImageUrl = "/Uploads/Book/" + Tmp.BPicName;
                TxtISBN.Text = Tmp.ISBN;
                DDLCategory.SelectedValue = Tmp.CatId + "";
                TxtCopies.Text = Tmp.Copies+""; // מילוי מספר העותקים הכולל
                TxtCopiesInStock.Text = Tmp.CopiesInStock + "";  // מילוי מספר העותקים הזמינים במלאי
                TxtMaxLoan.Text = Tmp.MaxLoan + ""; // מילוי מקסימום ימי השאלה
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
                string FullPath = Server.MapPath("/Uploads/Book/"); // יצירת הנתיב המלא לתיקיית ההעלאות
                UploadPic.SaveAs(FullPath + Picname);
            }
            else
            {
                Picname = ImgCover.ImageUrl.Substring(ImgCover.ImageUrl.LastIndexOf('/') + 1); // אם לא נבחר קובץ חדש, שמירת שם הקובץ הקיים
            }
            Book Tmp = new Book() 
            {
                BId = int.Parse(HidBId.Value),
                BTitle = TxtBTitle.Text,
                BAuthor = TxtBAuthor.Text,
                BDesc = TxtBDesc.Text,
                BPicName = Picname,
                ISBN = TxtISBN.Text,
                CatId = int.Parse(DDLCategory.SelectedValue),
                Copies = int.Parse(TxtCopies.Text),
                CopiesInStock = int.Parse(TxtCopiesInStock.Text),
                MaxLoan = int.Parse(TxtMaxLoan.Text),
            };
            Tmp.Save();
            Application["Book"] = Book.GetAll();
            Response.Redirect("BookList.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            int BId = int.Parse(HidBId.Value);  // המרת מזהה הספר למספר שלם
            Book.Delete(BId); // מחיקת הספר מהמסד נתונים
            Application["Book"] = Book.GetAll();
            Response.Redirect("BookList.aspx");
        }
    }
}