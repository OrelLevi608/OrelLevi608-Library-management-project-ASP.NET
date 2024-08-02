using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BLL;
using DATA;

namespace DAL
{
    public class ClientDAL
    {
        public static List<Client> GetAll()
        {
            List<Client> ClientList = new List<Client>();
            DbContext db = new DbContext();
            // שאילתה ששולפת את כל הלקוחות עם שמות הערים והסטטוסים שלהם 
            string sql = "SELECT T_Client.*, T_City.CityName, T_Status.StatusName FROM T_Client " +
                         "INNER JOIN T_City ON T_Client.CityId = T_City.CityId " +
                         "INNER JOIN T_Status ON T_Client.StatusId = T_Status.StatusId"; 
            DataTable Dt = db.Execute(sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Client Tmp = new Client()
                {
                    ClientId = int.Parse(Dt.Rows[i]["ClientId"] + ""),
                    Fname = Dt.Rows[i]["Fname"] + "",
                    Lname = Dt.Rows[i]["Lname"] + "",
                    ID = int.Parse(Dt.Rows[i]["ID"] + ""),
                    CityId = int.Parse(Dt.Rows[i]["CityId"] + ""),
                    CityName = Dt.Rows[i]["CityName"] + "",
                    Phone = Dt.Rows[i]["Phone"] + "",
                    Email = Dt.Rows[i]["Email"] + "",
                    Password = Dt.Rows[i]["Password"] + "",
                    PicName = Dt.Rows[i]["PicName"] + "",
                    StatusId = int.Parse(Dt.Rows[i]["StatusId"] + ""),
                    StatusName = Dt.Rows[i]["StatusName"] + "", // שם הסטטוס של הלקוח
                    AddDate = DateTime.Parse(Dt.Rows[i]["AddDate"] + ""),  // תאריך הוספת הלקוח
                    SubscriptionEndDate = DateTime.Parse(Dt.Rows[i]["SubscriptionEndDate"] + "") // תאריך סיום המנוי של הלקוח
                };
                ClientList.Add(Tmp);
            }
            db.Close();
            return ClientList;
        }

        public static Client GetById(int id)
        {
            DbContext db = new DbContext();
            // הקיים שם העיר והסטטוס שלו ID שאילתה ששולפת את כל הלקוח עם  
            string Sql = $"SELECT T_Client.*, T_City.CityName, T_Status.StatusName FROM T_Client " +
                         $"INNER JOIN T_City ON T_Client.CityId = T_City.CityId " +
                         $"INNER JOIN T_Status ON T_Client.StatusId = T_Status.StatusId " +
                         $"WHERE T_Client.ClientId = {id}";
            DataTable Dt = db.Execute(Sql);
            Client Tmp = null;
            if (Dt.Rows.Count > 0)
            {
                Tmp = new Client()
                {
                    ClientId = int.Parse(Dt.Rows[0]["ClientId"] + ""),
                    Fname = Dt.Rows[0]["Fname"] + "",
                    Lname = Dt.Rows[0]["Lname"] + "",
                    ID = int.Parse(Dt.Rows[0]["ID"] + ""),
                    CityId = int.Parse(Dt.Rows[0]["CityId"] + ""),
                    CityName = Dt.Rows[0]["CityName"] + "",
                    Phone = Dt.Rows[0]["Phone"] + "",
                    Email = Dt.Rows[0]["Email"] + "",
                    Password = Dt.Rows[0]["Password"] + "",
                    PicName = Dt.Rows[0]["PicName"] + "",
                    StatusId = int.Parse(Dt.Rows[0]["StatusId"] + ""),
                    StatusName = Dt.Rows[0]["StatusName"] + "",
                    AddDate = DateTime.Parse(Dt.Rows[0]["AddDate"] + ""),
                    SubscriptionEndDate = DateTime.Parse(Dt.Rows[0]["SubscriptionEndDate"] + "")
                };
            }
            db.Close();
            return Tmp;
        }

        public static int Save(Client Tmp)
        {
            int RecCount = 0;
            DbContext db = new DbContext();

            string Sql = "";
            if (Tmp.ClientId == -1)
            {
                Sql = "INSERT INTO T_Client (Fname, Lname, ID, CityId, Phone, Email, Password, PicName, StatusId, SubscriptionEndDate) VALUES";
                Sql += $"(N'{Tmp.Fname}', N'{Tmp.Lname}', {Tmp.ID}, {Tmp.CityId}, '{Tmp.Phone}', '{Tmp.Email}', N'{Tmp.Password}', '{Tmp.PicName}', {Tmp.StatusId}, '{Tmp.SubscriptionEndDate.ToString("yyyy-MM-dd")}')";
            }
            else
            {
                Sql = "UPDATE T_Client SET ";
                Sql += $"Fname= N'{Tmp.Fname}',";
                Sql += $"Lname= N'{Tmp.Lname}',";
                Sql += $"ID= {Tmp.ID},";
                Sql += $"CityId= {Tmp.CityId},";
                Sql += $"Phone= '{Tmp.Phone}',";
                Sql += $"Email= '{Tmp.Email}',";
                Sql += $"Password= N'{Tmp.Password}',";
                Sql += $"PicName= '{Tmp.PicName}',";
                Sql += $"StatusId= {Tmp.StatusId},";
                Sql += $"SubscriptionEndDate= '{Tmp.SubscriptionEndDate.ToString("yyyy-MM-dd")}'";
                Sql += $"WHERE ClientID ={Tmp.ClientId}";
            }
            RecCount = db.ExecuteNonQuery(Sql);
            if (Tmp.ClientId == -1)
            {
                Tmp.ClientId = db.GetMaxId("T_Client", "ClientId");
            }
            return RecCount;
        }

        public static int Delete(int id)
        {
            Client Tmp = null;
            DbContext db = new DbContext();
            string Sql = $"DELETE FROM T_Client WHERE ClientId={id}";
            int RecCount = 0;
            RecCount = db.ExecuteNonQuery(Sql);
            return RecCount;
        }
    }
}