using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelService.Models
{
    public class Boeking
    {
        public int ID { get; set; }
        public int KamerNummer { get; set; }
        public DateTime Startdatum { get; set; }
        public DateTime Einddatum { get; set; }
        public int KlantID { get; set; }
    }
}