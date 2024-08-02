using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int ID { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PicName { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime SubscriptionEndDate { get; set; }

        public static List<Client> GetAll()
        {
            return ClientDAL.GetAll();
        }
        public static Client GetById(int id)
        {
            return ClientDAL.GetById(id);
        }
        public int Save()
        {
            return ClientDAL.Save(this);
        }
        public static int Delete(int id)
        {
            return ClientDAL.Delete(id);
        }
    }
}