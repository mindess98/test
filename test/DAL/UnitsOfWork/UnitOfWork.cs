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
    public class UnitOfWork : IUoW
    {
        private HotelContext _context;

        public UnitOfWork()
        {
            _context = new HotelContext();
        }

        public IRepository<Guest> GuestRepository
        {
            get
            {
                return new GuestRepository(_context);
            }
        }

        public IRepository<Reservation> ReservationRepository
        {
            get
            {
                return new ReservationRepository(_context);
            }
        }

        public IRepository<Room> RoomRepository
        {
            get
            {
                return new RoomRepository(_context);
            }
        }

        public IRepository<RoomType> RoomTypeRepository
        {
            get
            {
                return new RoomTypeRepository(_context);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        
        int IUoW.Complete()
        {
            return _context.SaveChanges();
        }
    }
}
