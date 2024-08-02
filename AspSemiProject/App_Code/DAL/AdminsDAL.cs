using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BLL;
using DATA;

namespace DAL
{
    public class AdminsDAL
    {
        public static List<Admins> GetAll() // פונקציה שמחזירה רשימה של כל המנהלים מהמסד נתונים
        {
            List<Admins> AdminList = new List<Admins>();  // יצירת רשימה חדשה של מנהלים
            DbContext Db = new DbContext(); // DbContext יצירת אובייקט של מחלקת 
            string sql = "SELECT * FROM T_Admin"; // שאילתת לשליפת כל המנהלים
            DataTable Dt = Db.Execute(sql); // DataTable יצירת אובייק,ביצוע השאילתה והחזרת תוצאה כ
            for (int i = 0; i < Dt.Rows.Count; i++) // לולאה על כל השורות בטבלה
            {
                Admins Tmp = new Admins()  // יצירת אובייקט מנהל חדש
                {
                    AId = int.Parse(Dt.Rows[i]["AId"] + ""), // המרת מזהה המנהל למספר שלם
                    AName = Dt.Rows[i]["AName"] + "",  // שם המנהל
                    ALastName = Dt.Rows[i]["ALastName"] + "", // שם משפחה של המנהל
                    Email = Dt.Rows[i]["Email"]+"",  // דואר אלקטרוני של המנהל
                    Password = Dt.Rows[i]["Password"] + "", // סיסמת המנהל
                    APicName = Dt.Rows[i]["APicName"] + "", // שם הקובץ של תמונת המנהל
                    AddDate = DateTime.Parse(Dt.Rows[i]["AddDate"] + "")  // תאריך הוספת המנהל
                };
                AdminList.Add(Tmp);  // הוספת המנהל לרשימה
            }
            Db.Close(); // סגירת החיבור/הצינור
            return AdminList; // החזרת אובייקט
        }
        public static Admins GetById(int id) //  // ID פומקציה שמביאה מנהל לפי מזהה
        {
            DbContext Db = new DbContext();  // חיבור למסד הנתונים
            string sql = $"SELECT * FROM T_Admin WHERE AId={id}"; // ID שאיאלת שמביא את המנהל לפי 
            DataTable Dt = Db.Execute(sql);
            Admins Tmp = null;  // משתנה לאחסון המנהל שנמצא
            if (Dt.Rows.Count > 0)  // אם נמצא מנהל עם המזהה הנתון
            {
                Tmp = new Admins() //// (יצירת אובייקט (מנהל חדש
                {
                    AId = int.Parse(Dt.Rows[0]["AId"] + ""),
                    AName = Dt.Rows[0]["AName"] + "",
                    ALastName = Dt.Rows[0]["ALastName"] + "",
                    Email = Dt.Rows[0]["Email"] + "",
                    Password = Dt.Rows[0]["Password"] + "",
                    APicName = Dt.Rows[0]["APicName"] + "",
                    AddDate = DateTime.Parse(Dt.Rows[0]["AddDate"] + "")
                };
            }
            Db.Close(); // סגירת החיבור/הצינור
            return Tmp; // החזרת המנהל שנמצא
        }
        public static int Save (Admins Tmp)  // פונקציה ששומרת מנהל למסד הנתונים
        {
            int RecCount = 0; // משתנה זה מאפשר לנו לדעת האם המנהל קיים בסיס הנתונים שלנו, אם הוא יחזיר 0 זה אומר שהוא שהוא לא קיים
            DbContext db = new DbContext();
            string Sql = "";  // משתנה לשמירת השאילתה
            if (Tmp.AId == -1) // אם המנהל חדש (אין לו מספר מזהה עדיין) הוסף מנהל חדש
            {
                Sql = $"INSERT INTO T_Admin (AName, ALastName, Email, Password, APicName) VALUES";
                Sql += $"(N'{Tmp.AName}', N'{Tmp.ALastName}', N'{Tmp.Email}', N'{Tmp.Password}', N'{Tmp.APicName}')";
            }
            else  // אם המנהל כבר קיים
            {
                Sql = "UPDATE T_Admin SET "; // עדכון מנהל קיים
                Sql += $"AName = N'{Tmp.AName}',";
                Sql += $"ALastName = N'{Tmp.ALastName}',";
                Sql += $"Email = N'{Tmp.Email}',";
                Sql += $"Password = N'{Tmp.Password}',";
                Sql += $"APicName = N'{Tmp.APicName}'";
                Sql += $"WHERE AId = {Tmp.AId}";
            }
            RecCount = db.ExecuteNonQuery(Sql);

            if (Tmp.AId == -1) // אם המנהל חדש
            {
                Tmp.AId = db.GetMaxId("T_Admin", "AId"); // שליפת המזהה של המנהל שהתווסף
            }
            return RecCount;
        }
        public static int Delete(int id)  // ID פונקציה שמוחקת מנהל לפי
        {
            Admins Tmp = null;
            DbContext db = new DbContext();
            string sql = $"DELETE FROM T_Admin WHERE AId = {id}"; // ID שאילתה למחיקת מנהל לפי מספר מזהה
            int RecCount = 0;
            RecCount = db.ExecuteNonQuery(sql);
            return RecCount;
        }
    }
}