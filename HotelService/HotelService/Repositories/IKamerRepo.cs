using HotelService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Repositories
{
    public interface IKamerRepo
    {
        public IEnumerable<Kamer> GetAll();
        public void Add(Kamer kamer);
        public void Delete(Kamer kamer);
    }
}
