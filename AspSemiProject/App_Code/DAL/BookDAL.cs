using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BLL;
using DATA;

namespace DAL
{
    public class BookDAL
    {
        public static List<Book> GetAll()
        {
            List<Book> BookList = new List<Book>();
            DbContext db = new DbContext();
            string sql = "SELECT T_Book.*, T_Category.CatName FROM T_Book " + "INNER JOIN T_Category ON T_Book.CatId = T_Category.CatId"; // שאילתת שמביאה את כל הספרים עם שם הקטגוריה שלהם
            DataTable Dt = db.Execute(sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Book Tmp = new Book() // יצירת אובייקט ספר חדש
                {
                    BId = int.Parse(Dt.Rows[i]["BId"] + ""),
                    BTitle = Dt.Rows[i]["BTitle"] + "",
                    BAuthor = Dt.Rows[i]["BAuthor"] + "",
                    BDesc = Dt.Rows[i]["BDesc"] + "",
                    BPicName = Dt.Rows[i]["BPicName"] + "",
                    ISBN = Dt.Rows[i]["ISBN"] + "",
                    CatId = int.Parse(Dt.Rows[i]["CatId"] + ""),
                    CatName = Dt.Rows[i]["CatName"] + "",
                    Copies = int.Parse(Dt.Rows[i]["Copies"] + ""),
                    CopiesInStock = int.Parse(Dt.Rows[i]["CopiesInStock"] + ""),
                    MaxLoan = int.Parse(Dt.Rows[i]["MaxLoan"] + ""),
                    AddDate = DateTime.Parse(Dt.Rows[i]["AddDate"] + "")
                };
                BookList.Add(Tmp);
            }
            db.Close();
            return BookList;
        }
        public static Book GetById(int id)
        {
            DbContext db = new DbContext();
            // שקיים עם שם הקטגוריה שלו ID שאילתת שמביאה את הספר עם  
            string Sql = $"SELECT T_Book.*, T_Category.CatName FROM T_Book " + $"INNER JOIN T_Category ON T_Book.CatId = T_Category.CatId " + $"WHERE T_Book.BId = {id}";
            DataTable Dt = db.Execute(Sql);
            Book Tmp = null; // משתנה לאחסון הספר שנמצא
            if (Dt.Rows.Count > 0) // הקיים ID אם נמצא ספר עם המזהה 
            {
                Tmp = new Book() // יצירת אובייקט ספר חדש
                {
                    BId = int.Parse(Dt.Rows[0]["BId"] + ""),
                    BTitle = Dt.Rows[0]["BTitle"] + "",
                    BAuthor = Dt.Rows[0]["BAuthor"] + "",
                    BDesc = Dt.Rows[0]["BDesc"] + "",
                    BPicName = Dt.Rows[0]["BPicName"] + "",
                    ISBN = Dt.Rows[0]["ISBN"] + "",
                    CatId = int.Parse(Dt.Rows[0]["CatId"] + ""),
                    CatName = Dt.Rows[0]["CatName"] + "",
                    Copies = int.Parse(Dt.Rows[0]["Copies"] + ""),
                    CopiesInStock = int.Parse(Dt.Rows[0]["CopiesInStock"] + ""),
                    MaxLoan = int.Parse(Dt.Rows[0]["MaxLoan"] + ""),
                    AddDate = DateTime.Parse(Dt.Rows[0]["AddDate"] + "")
                };
            }
            db.Close();  // סגירת החיבור/הצינור
            return Tmp; // החזרת אובייקט הספר שנמצא
        }
        public static int Save(Book Tmp)
        {
            int RecCount = 0; // משתנה זה מאפשר לנו לדעת האם הספר קיים בסיס הנתונים שלנו, אם הוא יחזיר 0 זה אומר שהוא שהוא לא קיים
            DbContext db = new DbContext();
            string Sql = ""; // משתנה לשמירת השאילתה
            if (Tmp.BId == -1) // אם הספר חדש (אין לו מספר מזהה עדיין) הוסף ספר חדש
            {
                Sql = "INSERT INTO T_Book (BTitle, BAuthor, BDesc, BPicName, ISBN, CatId, Copies, CopiesInStock, MaxLoan) VALUES";
                Sql += $"(N'{Tmp.BTitle}', N'{Tmp.BAuthor}', N'{Tmp.BDesc}', '{Tmp.BPicName}', '{Tmp.ISBN}', {Tmp.CatId},  {Tmp.Copies}, {Tmp.CopiesInStock}, {Tmp.MaxLoan})";
            }
            else // אם הספר כבר קיים
            {
                Sql = "UPDATE T_Book SET "; // עדכון ספר קיים
                Sql += $"BTitle = N'{Tmp.BTitle}',";
                Sql += $"BAuthor = N'{Tmp.BAuthor}',";
                Sql += $"BDesc = N'{Tmp.BDesc}',";
                Sql += $"BPicName = '{Tmp.BPicName}',";
                Sql += $"ISBN = '{Tmp.ISBN}',";
                Sql += $"CatId = {Tmp.CatId},";
                Sql += $"Copies = {Tmp.Copies},";
                Sql += $"CopiesInStock = {Tmp.CopiesInStock},";
                Sql += $"MaxLoan = {Tmp.MaxLoan} ";
                Sql += $"WHERE BId = {Tmp.BId}";
            }
            RecCount = db.ExecuteNonQuery(Sql);
            if (Tmp.BId == -1) // אם הספר חדש
            {
                Tmp.BId = db.GetMaxId("T_Book", "BId"); // של הספר שהתווסף ID שליפת 
            }
            db.Close();// סגירת החיבור/הצינור
            return RecCount;
        }
        public static int Delete(int id)
        {
            Book Tmp = null;
            DbContext db = new DbContext();
            string Sql = $"DELETE FROM T_Book WHERE BId={id}"; // ID שאילת שמוחקת ספר לפי
            int RecCount = 0;
            RecCount = db.ExecuteNonQuery(Sql);
            return RecCount;
        }
        public static int GetMaxLoanById(int BId)
        {
            int maxLoan = 0;
            DbContext db = new DbContext();
            string sql = $"SELECT MaxLoan FROM T_Book WHERE BId = {BId}";
            DataTable dt = db.Execute(sql);
            if (dt.Rows.Count > 0) // אם נמצאה לפחות 1
            {
                maxLoan = int.Parse(dt.Rows[0]["MaxLoan"].ToString()); // המרת מקסימום ימי ההשאלה למספר שלם
            }
            db.Close(); // סגירת החיבור/הצינור
            return maxLoan; // החזרת מקסימום ימי ההשאלה
        }
    }
}