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
    public partial class AdminAddEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) 
        {
            if (!IsPostBack) // (Postback) בדיקה אם הדף נטען בפעם הראשונה 
            {
                string AId = Request["AId"] + ""; // AId של המנהל למשתנהID פעולת השמה של ה
                if (string.IsNullOrEmpty(AId)) // אם הפרמטר ריק או לא קיים
                {
                    AId = "-1"; // -1 הגדרת ערך ברירת מחדל של 
                }
                BtnDelete.Visible = AId != "-1"; // -1 לא AId הצגת כפתור מחיקה רק אם
                PasswordPanel.Visible = AId == "-1"; // הוא מינוס 1 (מנהל חדש)ה AId הצגת הסיסמה רק אם
                PicPanel.Visible = AId != "-1";  // הוא לא מינוס 1 (מנהל קיים)ה AId הצגת התמונה רק אם
                FillData(AId); // מילוי הנתונים
            }
        }
        public void FillData(string AId) // פונקציה למילוי הנתונים בטבלה
        {
            Admins Tmp = null;   // משתנה לאחסון המנהל שנמצא
            if (string.IsNullOrEmpty(AId)) // null AId אם 
            {
                AId = "-1"; // -הגדרת ערך ברירת מחדל של 1
            }
            else
            {
                Tmp = Admins.GetById(int.Parse(AId)); // ID קריאה לפונקציה ששולפת מנהל לפי 
                if (Tmp == null) //הקיים ID אם לא נמצא מנהל עם
                {
                    AId = "-1"; // -הגדרת ערך ברירת מחדל של 1
                }
            }
            if (Tmp != null)  // אם נמצא מנהל אז מילוי השדות באופן אוטומטי
            {
                TxtAName.Text = Tmp.AName;
                TxtALastName.Text = Tmp.ALastName;
                TxtEmail.Text = Tmp.Email;  
                TxtPassword.Text = Tmp.Password;
                ImgProfile.ImageUrl = "/Uploads/Admin/" + Tmp.APicName;
                HidAId.Value = AId; // אחסון מזהה המנהל בשדה מוסתר
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string Picname = "";
            if (UploadPic.HasFile)  // אם נבחר קובץ להעלאה
            {
                Picname = GlobFunc.GetRandStr(8); // יצירת שם קובץ אקראי
                string OriginFileName = UploadPic.FileName; // שם הקובץ המקורי
                int index = OriginFileName.LastIndexOf('.'); // מציאת המיקום של הסיומת
                string Ext = OriginFileName.Substring(index); // שליפת הסיומת
                Picname += Ext; // חיבור השם האקראי שנוצר עם הסיומת
                string FullPath = Server.MapPath("/Uploads/Admin/"); // יצירת הנתיב המלא לתיקיית ההעלאות
                UploadPic.SaveAs(FullPath + Picname); // שמירת הקובץ
            }
            else
            {
                Picname = ImgProfile.ImageUrl.Substring(ImgProfile.ImageUrl.LastIndexOf('/') + 1);  // אם לא נבחר קובץ חדש, שמירת שם הקובץ הנוכחי
            }
            Admins Tmp = new Admins()  // יצירת אובייקט מנהל
            {
                AId = int.Parse(HidAId.Value),  // מזהה המנהל
                AName = TxtAName.Text, // שם המנהל
                ALastName = TxtALastName.Text, // שם המשפחה של המנהל
                Email = TxtEmail.Text, // דואר אלקטרוני של המנהל
                Password = TxtPassword.Text, // סיסמת המנהל
                APicName = Picname,  // שם הקובץ של תמונת המנהל
            };
            Tmp.Save(); // שמירת המנהל במסד הנתונים
            Application["Admins"] = Admins.GetAll();  // עדכון הרשימה בקובץ גלובל של המנהלים
            Response.Redirect("AdminList.aspx"); // מעבר לדף רשימת המנהלים
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            if(HidAId.Value != "-1") // -1 של המנהל לא ID אם 
            {
                int aid = int.Parse(HidAId.Value); // המרת מזהה המנהל למספר שלם
                Admins.Delete(aid); // מחיקת המנהל מהמסד נתונים
                Application["Admins"] = Admins.GetAll(); // עדכון הרשימה בקובץ גלובל של המנהלים
                Response.Redirect("AdminList.aspx"); // מעבר לדף רשימת המנהלים
            }
        }
    }
}