using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelService.Models
{
    public class SingletonDatabase : DatabaseClassesDataContext
    {
        private static SingletonDatabase instance;

        private SingletonDatabase() { }

        public static SingletonDatabase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonDatabase();
                }
                return instance;
            }
        }
    }
}