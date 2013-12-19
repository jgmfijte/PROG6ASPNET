using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelService.Models
{
    public class Kamer
    {
        public int KamerNummer { get; set; }
        public int AantalPersonen { get; set; }
        public int PrijsPerNacht { get; set; }

        public Kamer(int kamerNummer, int aantalPersonen, int prijsPerNacht)
        {
            KamerNummer = kamerNummer;
            AantalPersonen = aantalPersonen;
            PrijsPerNacht = prijsPerNacht;
        }
    }
}