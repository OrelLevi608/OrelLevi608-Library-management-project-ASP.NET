using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }

        public static List<City> GetAll()
        {
            return CityDAL.GetAll();
        }
        public static City GetById(int id)
        {
            return CityDAL.GetById(id);
        }
        public int Save()
        {
            return CityDAL.Save(this);
        }
        public static int Delete(int id)
        {
            return CityDAL.Delete(id);
        }
    }
}