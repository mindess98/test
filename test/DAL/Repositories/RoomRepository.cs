using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test;
using test.Entities;

namespace DAL.Repositories
{
    class RoomRepository : IRepository<Room>
    {
        private HotelContext _context;

        public RoomRepository(HotelContext context)
        {
            _context = context;
        }

        public Room Create(Room t)
        {
            _context.RoomTypes.Attach(t.Type);
            _context.Rooms.Add(t);
            return t;
        }

        public bool Delete(int Id)
        {
            Room g = _context.Rooms.AsNoTracking().FirstOrDefault(x => x.Id == Id);
            if (g != null)
            {
                _context.Rooms.Attach(g);
                _context.Rooms.Remove(g);
                return true;
            }
            else
            {
                return false;
            }

        }

        public ICollection<Room> GetAll()
        {
            return _context.Rooms.Include("Reservations").Include("Type").ToList();
        }

        public Room GetById(int Id)
        {
            Room g = _context.Rooms.Include("Reservations").Include("Type").FirstOrDefault(x => x.Id == Id);
            if (g != null)
            {
                return new Room { Name = g.Name, Capacity = g.Capacity,  Price = g.Price, Reservations = g.Reservations, Id = g.Id, Image = g.Image, Type = g.Type };
            }
            else
                return null;
        }

        public Room Update(Room t)
        {
            Room ro = _context.Rooms.FirstOrDefault(x => x.Id == t.Id);
            ro.Name = t.Name;
            ro.Price = t.Price;
            ro.Reservations = t.Reservations;
            ro.Type = t.Type;
            ro.Image = t.Image;
            ro.RoomTypeId = t.RoomTypeId;
            return t;
        }
    }
}
