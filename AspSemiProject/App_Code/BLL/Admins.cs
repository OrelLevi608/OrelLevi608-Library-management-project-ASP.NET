using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class Admins
    {
        public int AId { get; set; } // מזהה המנהל
        public string AName { get; set; } //  שם המנהל
        public string ALastName { get; set; } // שם המשפחה של המנהל
        public string Email {  get; set; } // דואר אלקטרוני של המנהל
        public string Password { get; set; } // סיסמת המנהל
        public string APicName {  get; set; }  // שם הקובץ של תמונת המנהל
        public DateTime AddDate { get; set; } // תאריך הוספת המנהל למערכת

        public static List<Admins> GetAll() // פונקציה שמחזירה את כל הרשימה של המנהלים מהמסד נתונים
        {
            return AdminsDAL.GetAll();
        }
        public static Admins GetById(int id)
        {
            return AdminsDAL.GetById(id);
        }
        public int Save()
        {
            return AdminsDAL.Save(this);
        }
        public static int Delete(int id)
        {
            return AdminsDAL.Delete(id);
        }
    }
}