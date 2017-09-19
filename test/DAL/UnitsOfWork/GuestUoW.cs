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
    class GuestUoW : IUnitofWork<Guest>
    {
        
        public IRepository<Guest> Repository
        { get; internal set; }
        private HotelContext _context;

        public GuestUoW()
        {
            _context = new HotelContext();
            Repository = new GuestRepository(_context);
        }


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
