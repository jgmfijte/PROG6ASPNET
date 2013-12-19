using HotelService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelService.Repositories
{
    public class DummyKamerRepo : IKamerRepo
    {
        private List<Kamer> kamers = new List<Kamer>();

        public DummyKamerRepo()
        {
            Add(new Kamer(1, 2, 30));
            Add(new Kamer(2, 2, 30));
            Add(new Kamer(3, 2, 30));
            Add(new Kamer(4, 3, 45));
            Add(new Kamer(5, 3, 45));
            Add(new Kamer(6, 3, 45));
            Add(new Kamer(7, 5, 70));
            Add(new Kamer(8, 5, 70));
            Add(new Kamer(9, 5, 70));
            Add(new Kamer(10, 2, 80));
        }

        public virtual IEnumerable<Kamer> GetAll()
        {
            return kamers;
        }

        public virtual void Add(Kamer kamer)
        {
            kamers.Add(kamer);
        }

        public virtual void Delete(Kamer kamer)
        {
            kamers.Remove(kamer);
        }
    }
}