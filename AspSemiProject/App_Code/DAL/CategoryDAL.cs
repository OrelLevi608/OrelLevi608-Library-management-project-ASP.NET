using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BLL;
using DATA;

namespace DAL
{
    public class CategoryDAL
    {
        public static List<Category> GetAll() 
        {
            List<Category> CategoryList = new List<Category>(); // רשימה של קטגוריות
            DbContext db = new DbContext();
            string sql = "SELECT * FROM T_Category"; // שאילתה ששולפת את כל הקטגוריות
            DataTable Dt = db.Execute(sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Category Tmp = new Category()
                {
                    CatId = int.Parse(Dt.Rows[i]["CatId"] + ""),
                    CatName = Dt.Rows[i]["CatName"] + "",
                    CatDesc = Dt.Rows[i]["CatDesc"] + "",
                    PicName = Dt.Rows[i]["PicName"] + "",
                    AddDate = DateTime.Parse(Dt.Rows[i]["AddDate"] + "")
                };
                CategoryList.Add(Tmp);
            }
            db.Close();
            return CategoryList;
        }
        public static Category GetById(int id)
        {
            DbContext db = new DbContext();
            string Sql = $"Select * FROM T_Category WHERE CatId={id}";
            DataTable Dt = db.Execute(Sql);
            Category Tmp = null;
            if (Dt.Rows.Count > 0)
            {
                Tmp = new Category()
                {
                    CatId = int.Parse(Dt.Rows[0]["CatId"] + ""),
                    CatName = Dt.Rows[0]["CatName"] + "",
                    CatDesc = Dt.Rows[0]["CatDesc"] + "",
                    PicName = Dt.Rows[0]["PicName"] + "",
                    AddDate = DateTime.Parse(Dt.Rows[0]["AddDate"] + "")
                };
            }
            db.Close();
            return Tmp;
        }
        public static int Save(Category Tmp)
        {
            int RecCount = 0;
            DbContext db = new DbContext();
            string Sql = "";
            if (Tmp.CatId == -1)
            {
                Sql = "INSERT INTO T_Category (CatName, CatDesc, PicName) VALUES ";
                Sql += $"(N'{Tmp.CatName}', N'{Tmp.CatDesc}', N'{Tmp.PicName}')";
            }
            else
            {
                Sql = "UPDATE T_Category SET ";
                Sql += $"CatName= N'{Tmp.CatName}',";
                Sql += $"CatDesc= N'{Tmp.CatDesc}',";
                Sql += $"PicName= N'{Tmp.PicName}'";
                Sql += $"WHERE CatId ={Tmp.CatId}";
            }
            RecCount = db.ExecuteNonQuery(Sql);
            if (Tmp.CatId == -1)
            {
                Tmp.CatId = db.GetMaxId("T_Category", "CatId");
            }
            return RecCount;
        }
        public static int Delete(int id)
        {
            Category Tmp = null;
            DbContext db = new DbContext();
            string Sql = $"DELETE FROM T_Category WHERE CatId={id}";
            int RecCount = 0;
            RecCount = db.ExecuteNonQuery(Sql);
            return RecCount;
        }
    }
}