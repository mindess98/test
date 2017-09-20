using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.Entities;
using test;

namespace DAL.Repositories
{
    public class GuestRepository : IRepository<Guest>
    {
        private HotelContext _context;

        public GuestRepository(HotelContext context)
        {
            _context = context;
        }

        public Guest Create(Guest t)
        {
            _context.Guests.Add(t);
            return t;
        }

        public bool Delete(int Id)
        {
            Guest g = GetById(Id);
            if ( g != null){
                _context.Guests.Remove(g);
                return true;
            }
            else {
                return false;
            }
            
        }

        public IEnumerable<Guest> GetAll()
        {
            return _context.Guests.Include("Reservation").ToList();
        }

        public Guest GetById(int Id)
        {
            Guest g = GetAll().FirstOrDefault(x => x.Id == Id);
            if (g != null)
            {
                return new Guest { Name = g.Name, Reservation = g.Reservation , Id = g.Id };
            }
            else
                return null;
        }

        public Guest Update(Guest t)
        {

            return t;
        }
    }
}
