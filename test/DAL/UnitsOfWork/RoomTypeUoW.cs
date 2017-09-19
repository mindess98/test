using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using test.Entities;
using test;

namespace DAL.UnitsOfWork
{
    class RoomTypeUoW : IUnitofWork<RoomType>
    {
        private HotelContext _context;

        public RoomTypeUoW()
        {
            _context = new HotelContext();
            Repository = new RoomTypeRepository(_context);
        }

        public IRepository<RoomType> Repository
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
