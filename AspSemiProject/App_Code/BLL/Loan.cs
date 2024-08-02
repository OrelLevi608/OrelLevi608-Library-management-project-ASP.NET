using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL
{
    public class Loan
    {
        public int LoanId { get; set; }
        public int ClientId { get; set; }
        public string Email { get; set; }
        public int BId { get; set; }
        public string BTitle { get; set; }
        public int MaxLoan {  get; set; }  // בשביל לחשב אוטמטית את זמן השאלה משואר
        public DateTime LoanDate { get; set; }
        public DateTime EstimatedReturnDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }  // אם הספר לא הוחזר null  תאריך ההחזרה בפועל

        public static List<Loan> GetAll()
        {
            return LoanDAL.GetAll();
        }
        public static Loan GetById(int id)
        {
            return LoanDAL.GetById(id);
        }
        public int Save()
        {
            MaxLoan = Book.GetMaxLoanById(BId); // מחזיר את מקסימום ימי ההשאלה לספר לפי מזהה
            EstimatedReturnDate = LoanDate.AddDays(MaxLoan); // חישוב תאריך ההחזרה המשוער על פי מקסימום ימי ההשאלה
            return LoanDAL.Save(this); // שומר את ההשאלה
        }
        public static int Delete(int id)
        {
            return LoanDAL.Delete(id);
        }
    }
}