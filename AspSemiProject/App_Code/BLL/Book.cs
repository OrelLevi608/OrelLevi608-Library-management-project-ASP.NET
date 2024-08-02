using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class Book
    {
        public int BId { get; set; }
        public string BTitle { get; set; }
        public string BAuthor { get; set; }
        public string BDesc { get; set; }
        public string BPicName { get; set; }
        public string ISBN { get; set; }
        public int CatId { get; set; }
        public string CatName { get; set; }
        public int Copies { get; set; } // מספר העותקים הכולל של הספר
        public int CopiesInStock { get; set; } // מספר העותקים הזמינים במלאי
        public int MaxLoan { get; set; } // מקסימום ימי השאלה לספר
        public DateTime AddDate { get; set; } // תאריך הוספת הספר למערכת

        public static List<Book> GetAll()
        {
            return BookDAL.GetAll();
        }
        public static Book GetById(int id)
        {
            return BookDAL.GetById(id);
        }
        public int Save()
        {
            return BookDAL.Save(this);
        }
        public static int Delete(int id)
        {
            return BookDAL.Delete(id);  
        }
        public static int GetMaxLoanById(int id)  /// פונקציה לחישוב אטומטי לזמן השאלה משואר
        {
            return BookDAL.GetMaxLoanById(id);
        }
    }
}