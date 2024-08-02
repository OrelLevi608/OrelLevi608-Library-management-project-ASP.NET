using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL
{
    public class Status
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string StatusDesc { get; set; }

        public static List<Status> GetAll()
        {
            return StatusDAL.GetAll();
        }
        public static Status GetById(int id)
        {
            return StatusDAL.GetById(id);
        }
        public int Save()
        {
            return StatusDAL.Save(this);
        }
        public static int Delete(int id)
        {
            return StatusDAL.Delete(id);
        }
    }
}