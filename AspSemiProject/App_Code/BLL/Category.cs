using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
namespace BLL
{
    public class Category
    {
        public int CatId { get; set; }
        public string CatName { get; set; }
        public string CatDesc { get; set; }
        public string PicName { get; set; }
        public DateTime AddDate { get; set; }

        public static List<Category> GetAll()
        {
            return CategoryDAL.GetAll();
        }
        public static Category GetById(int id) 
        { 
            return CategoryDAL.GetById(id);
        }
        public int Save()
        {
            return CategoryDAL.Save(this);
        }
        public static int Delete(int id)
        {
            return CategoryDAL.Delete(id);
        }
    }
}