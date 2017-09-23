using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test;
using test.Entities;

namespace DAL.Repositories
{
    class RoomTypeRepository : IRepository<RoomType>
    {
        private HotelContext _context;

        public RoomTypeRepository(HotelContext context)
        {
            _context = context;
        }

        public RoomType Create(RoomType t)
        {
            _context.RoomTypes.Add(t);
            return t;
        }

        public bool Delete(int Id)
        {
            RoomType g = GetById(Id);
            if (g != null)
            {
                _context.RoomTypes.Remove(g);
                return true;
            }
            else
            {
                return false;
            }

        }

        public IEnumerable<RoomType> GetAll()
        {
            return _context.RoomTypes.Include("Rooms").ToList();
        }

        public RoomType GetById(int Id)
        {
            RoomType g = GetAll().FirstOrDefault(x => x.Id == Id);
            if (g != null)
            {
                return new RoomType { Name = g.Name, StarValue = g.StarValue, Id = g.Id };
            }
            else
                return null;
        }

        public RoomType Update(RoomType t)
        {
            RoomType rt = GetById(t.Id);
            rt.Name = t.Name;
            rt.Rooms = t.Rooms;
            rt.StarValue = t.StarValue;
            return t;
        }
    }
}
