using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelService.Models
{
    public class Boeking
    {
        public int Boeking_KamerNr { get; set; }
        public DateTime Startdatum { get; set; }
        public DateTime Einddatum { get; set; }
        public int Prijs { get; set; }
        public string Bankrekening { get; set; }
        public string FactuurAdres { get; set; }
        public string Status { get; set; }
        public int Boeking_KlantNr { get; set; }
        public int BoekingsNr { get; set; }
    }
}