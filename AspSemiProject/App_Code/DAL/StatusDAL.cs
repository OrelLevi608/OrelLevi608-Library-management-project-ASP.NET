using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BLL;
using DATA;

namespace DAL
{
    public class StatusDAL
    {
        public static List<Status> GetAll()
        {
            List<Status> StatusList = new List<Status>();
            DbContext db = new DbContext();
            string Sql = "SELECT * FROM T_Status";
            DataTable Dt = db.Execute(Sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Status Tmp = new Status()
                {
                    StatusId = int.Parse(Dt.Rows[i]["StatusId"] + ""),
                    StatusName = Dt.Rows[i]["StatusName"] + "",
                    StatusDesc = Dt.Rows[i]["StatusDesc"] + ""
                };
                StatusList.Add(Tmp);
            }
            db.Close();
            return StatusList;
        }
        public static Status GetById(int id)
        {
            DbContext db = new DbContext();
            string Sql = $"Select * FROM T_Status WHERE StatusId={id}";  // הקיים ID שאיאלת שמביא את הסטטוס לפי 
            DataTable Dt = db.Execute(Sql);
            Status Tmp = null;
            if (Dt.Rows.Count > 0)
            {
                Tmp = new Status()
                {
                    StatusId = int.Parse(Dt.Rows[0]["StatusId"] + ""),
                    StatusName = Dt.Rows[0]["StatusName"] + "",
                    StatusDesc = Dt.Rows[0]["StatusDesc"] + ""
                };
            }
            db.Close();
            return Tmp;
        }
        public static int Save(Status Tmp)
        {
            int RecCount = 0;
            DbContext db = new DbContext();
            string Sql = "";
            if (Tmp.StatusId == -1)
            {
                Sql = $"INSERT INTO T_Status (StatusName, StatusDesc) VALUES ";
                Sql += $"(N'{Tmp.StatusName}', N'{Tmp.StatusDesc}')";
            }
            else
            {
                Sql = "UPDATE T_Status set ";
                Sql += $"StatusName = N'{Tmp.StatusName}',";
                Sql += $"StatusDesc = N'{Tmp.StatusDesc}'";
                Sql += $"WHERE StatusID ={Tmp.StatusId}";
            }
            RecCount = db.ExecuteNonQuery(Sql);

            if (Tmp.StatusId == -1)
            {
                Tmp.StatusId = db.GetMaxId("T_Status", "StatusId");
            }
            return RecCount;
        }
        public static int Delete(int id)
        {
            Status Tmp = null;
            DbContext db = new DbContext();
            string Sql = $"DELETE FROM T_Status WHERE StatusId={id}";
            int RecCount = 0;
            RecCount = db.ExecuteNonQuery(Sql);
            return RecCount;
        }
    }
}