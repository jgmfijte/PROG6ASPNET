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
        public int MinimumPrijs { get; set; }
        public int ActuelePrijs { get; set; }

        public Kamer(int kamerNummer, int aantalPersonen, int minimumPrijs, int actuelePrijs)
        {
            KamerNummer = kamerNummer;
            AantalPersonen = aantalPersonen;
            MinimumPrijs = minimumPrijs;
            ActuelePrijs = actuelePrijs;
        }
    }
}