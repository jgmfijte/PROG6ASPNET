using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelService.Models
{
    public class Gast
    {
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public DateTime Geboortedatum { get; set; }
        public char Geslacht { get; set; }
        public string Adres { get; set; }
        public string Postcode {get; set; }
        public string Woonplaats { get; set; }
        public string Email { get; set; }
    }
}