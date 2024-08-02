using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BLL;
using DATA;

namespace DAL
{
    public class LoanDAL
    {
        public static List<Loan> GetAll()
        {
            List<Loan> LoanList = new List<Loan>();
            DbContext db = new DbContext();
            //  שאילתה ששופלאת את כל ההשאלות עם מידע על הלקוחות והספרים 
            string sql = "SELECT L.*, C.Email, B.BTitle " +
                         "FROM T_Loan L " +
                         "INNER JOIN T_Client C ON L.ClientID = C.ClientID " +
                         "INNER JOIN T_Book B ON L.BId = B.BId ";                         
            DataTable Dt = db.Execute(sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Loan Tmp = new Loan()
                {
                    LoanId = int.Parse(Dt.Rows[i]["LoanId"] + ""),
                    ClientId = int.Parse(Dt.Rows[i]["ClientId"] + ""),
                    Email = Dt.Rows[i]["Email"] + "",
                    BId = int.Parse(Dt.Rows[i]["BId"] + ""),
                    BTitle = Dt.Rows[i]["BTitle"] + "",
                    LoanDate = DateTime.Parse(Dt.Rows[i]["LoanDate"] + ""), // תאריך ההשאלה
                    EstimatedReturnDate = DateTime.Parse(Dt.Rows[i]["EstimatedReturnDate"] + ""), // תאריך החזרה משוער
                    ActualReturnDate = DateTime.Parse(Dt.Rows[i]["ActualReturnDate"] + "") // תאריך החזרה בפועל
                };
                LoanList.Add(Tmp);
            }
            db.Close();
            return LoanList;
        }

        public static Loan GetById(int id)
        {
            DbContext db = new DbContext();
            // הקיים עם מידע על הלקוח והספר ID  שאילתה ששולפת את ההשאלה עם 
            string Sql = $"SELECT L.*, C.Email, B.BTitle " +
                         $"FROM T_Loan L " +
                         $"INNER JOIN T_Client C ON L.ClientID = C.ClientID " +
                         $"INNER JOIN T_Book B ON L.BId = B.BId " +
                         $"WHERE L.LoanId = {id}";
            DataTable Dt = db.Execute(Sql);
            Loan Tmp = null;
            if (Dt.Rows.Count > 0)
            {
                Tmp = new Loan()
                {
                    LoanId = int.Parse(Dt.Rows[0]["LoanId"] + ""),
                    ClientId = int.Parse(Dt.Rows[0]["ClientId"] + ""),
                    Email = Dt.Rows[0]["Email"] + "",
                    BId = int.Parse(Dt.Rows[0]["BId"] + ""),
                    BTitle = Dt.Rows[0]["BTitle"] + "",
                    LoanDate = DateTime.Parse(Dt.Rows[0]["LoanDate"] + ""),
                    EstimatedReturnDate = DateTime.Parse(Dt.Rows[0]["EstimatedReturnDate"] + ""),
                    ActualReturnDate = DateTime.Parse(Dt.Rows[0]["ActualReturnDate"] + "")
                };
            }
            db.Close();
            return Tmp;
        }

        public static int Save(Loan Tmp)
        {
            int RecCount = 0;
            DbContext db = new DbContext();
            string Sql = "";           
            if (Tmp.LoanId == -1)
            {
                Sql = $"INSERT INTO T_Loan (ClientId, BId, LoanDate, EstimatedReturnDate, ActualReturnDate) " +
                      $"VALUES ({Tmp.ClientId}, {Tmp.BId}, '{Tmp.LoanDate:yyyy-MM-dd}', '{Tmp.EstimatedReturnDate:yyyy-MM-dd}', '{Tmp.ActualReturnDate:yyyy-MM-dd}')";
            }
            else
            {
                Sql = $"UPDATE T_Loan SET " +
                      $"ClientID = {Tmp.ClientId}, " +
                      $"BId = {Tmp.BId}, " +
                      $"LoanDate = '{Tmp.LoanDate:yyyy-MM-dd}', " +
                      $"EstimatedReturnDate = '{Tmp.EstimatedReturnDate:yyyy-MM-dd}', " +
                      $"ActualReturnDate = '{Tmp.ActualReturnDate:yyyy-MM-dd}' " +
                      $"WHERE LoanID = {Tmp.LoanId}";
            }
            RecCount = db.ExecuteNonQuery(Sql);
            if (Tmp.LoanId == -1)
            {
                Tmp.LoanId = db.GetMaxId("T_Loan", "LoanId");
            }
            db.Close();
            return RecCount;
        }

        public static int Delete(int id)
        {
            DbContext db = new DbContext();
            string Sql = $"DELETE FROM T_Loan WHERE LoanId={id}";
            int RecCount = db.ExecuteNonQuery(Sql);
            db.Close();
            return RecCount;
        }
    }
}