using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test;
using test.Entities;

namespace DAL.Repositories
{
    class ReservationRepository : IRepository<Reservation>
    {
        private HotelContext _context;

        public ReservationRepository(HotelContext context)
        {
            _context = context;
        }

        public Reservation Create(Reservation t)
        {
            _context.Reservations.Add(t);
            return t;
        }

        public bool Delete(int Id)
        {
            Reservation g = GetById(Id);
            if (g != null)
            {
                _context.Reservations.Remove(g);
                return true;
            }
            else
            {
                return false;
            }

        }

        public IEnumerable<Reservation> GetAll()
        {
            return _context.Reservations.ToList();
        }

        public Reservation GetById(int Id)
        {
            Reservation g = _context.Reservations.FirstOrDefault(x => x.Id == Id);
            if (g != null)
            {
                return new Reservation { Rooms = g.Rooms, From = g.From, To = g.To, Guest = g.Guest, Id = g.Id };
            }
            else
                return null;
        }

        public Reservation Update(Reservation t)
        {

            return t;
        }
    }
}
