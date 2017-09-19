using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test;
using test.Entities;

namespace DAL.UnitsOfWork
{
    class RoomUoW : IUnitofWork<Room>
    {
        private HotelContext _context;

        public RoomUoW()
        {
            _context = new HotelContext();
            Repository = new RoomRepository(_context);
        }

        public IRepository<Room> Repository
        { get; internal set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
