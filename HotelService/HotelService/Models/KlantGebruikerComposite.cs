using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelService.Models
{
    public class KlantGebruikerComposite
    {
        public DataAccessLayer.Klanten Klanten { get; set; }
        public DataAccessLayer.Gebruiker Gebruikers { get; set; }
    }
}