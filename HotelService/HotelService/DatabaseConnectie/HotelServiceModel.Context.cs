﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PROG6ASPNETEntities : DbContext
    {
        public PROG6ASPNETEntities()
            : base("name=PROG6ASPNETEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Hotelkamers> Hotelkamers { get; set; }
        public virtual DbSet<Klanten> Klanten { get; set; }
        public virtual DbSet<Boekingen> Boekingen { get; set; }
    }
}
