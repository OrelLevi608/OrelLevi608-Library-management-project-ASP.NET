using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BLL;
using DATA;

namespace DAL
{
    public class CityDAL
    {
        public static List<City> GetAll()
        {
            List<City> CityList = new List<City>();
            DbContext db = new DbContext();
            string Sql = $"SELECT * FROM T_City ";
            DataTable Dt = db.Execute(Sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                City Tmp = new City()
                {
                    CityId = int.Parse(Dt.Rows[i]["CityID"] + ""),
                    CityName = Dt.Rows[i]["CityName"] + ""
                };

                CityList.Add(Tmp);
            }

            db.Close();
            return CityList;
        }
        public static City GetById(int id)
        {
            DbContext db = new DbContext();
            string Sql = $"Select * FROM T_City WHERE CityId={id}";
            DataTable Dt = db.Execute(Sql);

            City Tmp = null;

            if (Dt.Rows.Count > 0)
            {
                Tmp = new City()
                {
                    CityId = int.Parse(Dt.Rows[0]["CityID"] + ""),
                    CityName = Dt.Rows[0]["CityName"] + ""
                };
            }

            return Tmp;
        }
        public static int Save(City Tmp)
        {
            int RecCount = 0;
            DbContext db = new DbContext();
            string Sql = "";
            if (Tmp.CityId == -1)
            {
                Sql = $"INSERT INTO T_City (CityName) VALUES ";
                Sql += $"(N'{Tmp.CityName}')";
            }
            else
            {
                Sql = "UPDATE T_City set ";
                Sql += $"CityName=N'{Tmp.CityName}'";
                Sql += $"WHERE CityID ={Tmp.CityId}";
            }
            RecCount = db.ExecuteNonQuery(Sql);

            if (Tmp.CityId == -1)
            {
                Tmp.CityId = db.GetMaxId("T_City", "CityId");
            }
            return RecCount;
        }
        public static int Delete(int id)
        {
            City Tmp = null;
            DbContext db = new DbContext();
            string Sql = $"DELETE FROM T_City WHERE CityId={id}";
            int RecCount = 0;
            RecCount = db.ExecuteNonQuery(Sql);
            return RecCount;
        }
    }
}