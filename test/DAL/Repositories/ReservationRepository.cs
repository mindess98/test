using System;
using System.Collections;
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
            return _context.Reservations.Add(t);
        }

        public bool Delete(int Id)
        {
            Reservation g = _context.Reservations.AsNoTracking().FirstOrDefault(x => x.Id == Id);
            if (g != null)
            {
                _context.Reservations.Attach(g);
                _context.Reservations.Remove(g);
                return true;
            }
            else
            {
                return false;
            }

        }

        public ICollection<Reservation> GetAll()
        {
            return _context.Reservations.Include("Rooms").Include("Guest").ToList();
        }

        public Reservation GetById(int Id)
        {
            Reservation g = _context.Reservations.Include("Rooms").Include("Guest").FirstOrDefault(x => x.Id == Id);
            if (g != null)
            {
                return new Reservation { Rooms = g.Rooms, From = g.From, To = g.To, Guest = g.Guest, Id = g.Id };
            }
            else
                return null;
        }

        public Reservation Update(Reservation t)
        {
            Reservation re = _context.Reservations.FirstOrDefault(x => x.Id == t.Id);
            re.Guest = t.Guest;
            re.GuestId = t.GuestId;
            re.Rooms = t.Rooms;
            re.From = t.From;
            re.To = t.To;

            return t;
        }
    }
}
