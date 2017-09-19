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
    class ReservationUoW : IUnitofWork<Reservation>
    {
        public IRepository<Reservation> Repository
        { get; internal set; }
        private HotelContext _context;

        public ReservationUoW()
        {
            _context = new HotelContext();
            Repository = new ReservationRepository(_context);
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
