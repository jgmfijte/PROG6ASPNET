//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelService.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Boekingen
    {
        public System.DateTime Startdatum { get; set; }
        public System.DateTime Einddatum { get; set; }
        public Nullable<decimal> Prijs { get; set; }
        public string FactuurAdres { get; set; }
        public Nullable<long> Bankrekening { get; set; }
        public string Status { get; set; }
        public int Boeking_KlantNr { get; set; }
        public int Boeking_KamerNr { get; set; }
    
        public virtual Hotelkamers Hotelkamers { get; set; }
        public virtual Klanten Klanten { get; set; }
    }
}
